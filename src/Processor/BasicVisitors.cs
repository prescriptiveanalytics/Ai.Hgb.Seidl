using Antlr4.Runtime.Misc;
using Ai.Hgb.Seidl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// https://stackoverflow.com/questions/887205/tutorial-for-walking-antlr-asts-in-c
// https://tomassetti.me/best-practices-for-antlr-parsers/

namespace Ai.Hgb.Seidl.Processor {
  public class StatementPrintVisitor : SeidlParserBaseVisitor<object> {
    public override object VisitSet([NotNull] SeidlParser.SetContext context) {
      var x = context.ChildCount;

      var statements = context.statement();
      foreach (var statement in statements) {
        Console.WriteLine(statement.GetText());
        foreach (var child in statement.children) {
          Console.WriteLine(child.GetText() + " ");
        }
      }
      return base.VisitSet(context);
    }
  }

  public class ScopedSymbolTableVisitor : SeidlParserBaseVisitor<object?> {

    public string programTextUrl;
    public ScopedSymbolTable scopedSymbolTable;
    private Scope currentScope;

    public ScopedSymbolTableVisitor() {
      scopedSymbolTable = new ScopedSymbolTable();
      //currentScope = scopedSymbolTable.AddScope("gobal", null);
      currentScope = scopedSymbolTable.Global;
    }

    public override object? VisitSet([NotNull] SeidlParser.SetContext context) {
      var statements = context.statement();
      foreach (var statement in statements) {
        Visit(statement);
      }
      return null;
    }

    public override object? VisitScopeStatement([NotNull] SeidlParser.ScopeStatementContext context) {
      var scopeVar = context.scope().variable();
      string scopeName = scopeVar?.GetText();

      var newScope = scopedSymbolTable.AddScope(scopeName, currentScope, context.Start.Line, context.Start.Column, context.Stop.Line, context.Stop.Column);
      var parentScope = currentScope;

      // step inside scope
      currentScope = newScope;
      Visit(context.scope().set());            

      // step outside scope (i.e. reset scope)
      currentScope = parentScope;
      return null;
    }

    public override object VisitDeclarationStatement([NotNull] SeidlParser.DeclarationStatementContext context) {
      var typecode = context.atomictype()?.Start.Type;
      var typename = context.typename()?.GetText();

      foreach (var variable in context.variablelist().variable()) {
        var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope);

        scopedSymbolTable.AddSymbol(variable.GetText(), type, currentScope);
      }
      return null;
    }

    public override object VisitDefinitionStatement([NotNull] SeidlParser.DefinitionStatementContext context) {
      if(context.variablelist().ChildCount != context.expressionlist().ChildCount && context.expressionlist().ChildCount != 1) {
        throw new ArgumentException($"The number of expressions does not match the number of variables. Alternatively a single expression for all variables can be used.");
      }
      bool singleExp = context.expressionlist().ChildCount == 1;
      var typecode = context.atomictype()?.Start.Type;
      var typename = context.typename()?.GetText();

      for(int i = 0; i < context.variablelist().variable().Length; i++) {
        var variable = context.variablelist().variable(i);
        var expression = context.expressionlist().expression(singleExp ? 0 : i);
        var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope, expression);
        // TODO: assign expression to looked up type (if typecode = atomictype, all done)

        scopedSymbolTable.AddSymbol(variable.GetText(), type, currentScope);
      }
      return null;
    }

    public override object VisitTypedefStatement([NotNull] SeidlParser.TypedefStatementContext context) {
      var def = context.typedefstatement();
      var name = def.variable().GetText();
      var typecode = def.atomictype()?.Start.Type;
      var typename = def.typename()?.GetText();
      var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope);

      scopedSymbolTable.AddSymbol(name,type, currentScope, true);

      return null;
    }

    public override object VisitStructDefinitionStatement([NotNull] SeidlParser.StructDefinitionStatementContext context) {

      var def = context.structdefinition();
      var name = def.variable().GetText();
      var data = new Struct();

      foreach(var property in def.structpropertylist().variable().Zip(def.structpropertylist().atomictypeortypename(), Tuple.Create)) { 

        var typecode = property.Item2.atomictype()?.Start.Type;
        var typename = property.Item2.typename()?.GetText();
        var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope);

        data.AddProperty(property.Item1.GetText(), type);
      }

      scopedSymbolTable.AddSymbol(name, data, currentScope, true);

      return null;
    }

    public override object VisitMessageDefinitionStatement([NotNull] SeidlParser.MessageDefinitionStatementContext context) {

      var def = context.messagedefinition();
      var name = def.messagetypename().GetText();
      var message = new Message();

      // parse message parameters
      var  mplist = def.messageparameterlist();
      for (int i = 0; i < mplist.variable().Length; i++) {
        var mpsignature = mplist.messageparametersignature(i);
        var topic = mpsignature.TOPIC() != null;
        var atype = mpsignature.atomictype(); // either atomic type ...
        var typename = mpsignature.typename(); // ... or custom type (=symbol) is declared
        var parametername = mplist.variable(i).GetText();

        IType type;
        if (atype != null) type = Utils.CreateAtomicType(atype.Start.Type, null);
        else {
          var t = scopedSymbolTable.GetSymbolAndCheckBaseType(currentScope, typename.GetText()); 
          if (t != null) type = t.ShallowCopy();
          else throw new ArgumentException($"The message parameter {typename} is not / derived from a base type and hence, not allowed.");
        }
        
        message.AddParameter(type, parametername, topic);
      }

      scopedSymbolTable.AddSymbol(name, message, currentScope, true);

      return null;      
    }

    public override object VisitNodeDefinitionStatement([NotNull] SeidlParser.NodeDefinitionStatementContext context) {

      
      var def = context.nodedefinition();
      var name = def.variable()?.GetText();
      var signature = def.nodetypesignature();
      var body = def.nodebody();
      var typename = def.typename();

      if (name == null) return null;

      Node node = null;

      if(body != null && signature == null) { // alternative 1
        node = new Node();
        ReadNodeBody(body, node);
      } else if(signature != null) { // alternative 2
        node = new Node();
        ReadNodeSignature(signature, node);
        // optional body:
        if (body != null) ReadNodeBody(body, node);

      } else { // alternative 3         
        node = Utils.GetNodeType(typename.GetText(), scopedSymbolTable, currentScope);

        // alternative 3.1: with constructor
        var constructor = def.nodeconstructor();
        if (constructor != null) {
          var asslist = constructor.assignmentlist();
          if(asslist != null) {
            for (int i = 0; i < asslist.assignment().Length; i++) {
              var ass = asslist.assignment(i);
              var varname = ass.variable().GetText();
              var exp = ass.expression();

              // TODO: evaluate expression, check compability, store value
            }
          }
        }

      }

      if(name != null && node != null)
        scopedSymbolTable.AddSymbol(name, node, currentScope, false);

      return null;
    }

    public override object VisitNodetypeDefinitionStatement([NotNull] SeidlParser.NodetypeDefinitionStatementContext context) {
      var def = context.nodetypedefinition();

      var name = def.nodetypename().GetText();
      var signature = def.nodetypesignature();
      var body = def.nodebody();

      Node node = new Node();

      if (signature == null && body != null) { // alternative 1
        ReadNodeBody(body, node);
      } else if(signature != null) { // alternative 2
        ReadNodeSignature(signature, node);
        // optional body:
        if (body != null) ReadNodeBody(body, node);
      }

      scopedSymbolTable.AddSymbol(name, node, currentScope, true);

      return null;
    }

    public override object VisitNodeConnectionStatement([NotNull] SeidlParser.NodeConnectionStatementContext context) {
      var stmt = context.nodeconnectionstatement();
      
      // parse source and sink names (= nodes names with port names)
      var sourceNames = new List<Tuple<string,string>>();
      var sinkNames = new List<Tuple<string, string>>();

      foreach(var from in stmt.sources.field()) {
        if (from.variable().Length == 1) sourceNames.Add(Tuple.Create(from.variable(0).GetText(), ""));
        else sourceNames.Add(Tuple.Create(from.variable(0).GetText(), from.variable(1).GetText()));
      }
      foreach (var to in stmt.sinks.field()) {
        if (to.variable().Length == 1) sinkNames.Add(Tuple.Create(to.variable(0).GetText(), ""));
        else sinkNames.Add(Tuple.Create(to.variable(0).GetText(), to.variable(1).GetText()));
      }




      //if (stmt.sources != null) { // list of type or property names
      //  sourceNames.AddRange(stmt.sources.variable().Select(x => x.GetText()));
      //  sinkNames.AddRange(stmt.sinks.variable().Select(x => x.GetText()));
      //}
      //else { // single typename
      //  sourceNames.Add(stmt.source.GetText());
      //  sinkNames.Add(stmt.sink.GetText());
      //}

      // parse edge type
      string edgeType = null;
      if (stmt.ARROW != null) edgeType = EdgeType.PubSub;
      else if (stmt.HEAVYARROW != null) edgeType = EdgeType.ReqRes;
      else if (stmt.QUERYARROW_BEGIN != null) edgeType = EdgeType.PubSubQuery;
      else if (stmt.QUERYHARROW_BEGIN != null) edgeType = EdgeType.ReqResQuery;

      // parse query
      string query = null;
      if(edgeType == EdgeType.PubSubQuery || edgeType == EdgeType.ReqResQuery) {
        query = stmt.query().Start.Text;
      }

      var sources = new List<Node>(sourceNames.Count);
      var sinks = new List<Node>(sinkNames.Count);
      var checkedSourceNames = new List<Tuple<string,string>>(sourceNames.Count);
      var checkedSinkNames = new List<Tuple<string, string>>(sinkNames.Count);            

      // check and collect valid nodes and node fields
      // sources
      foreach (var sourceName in sourceNames) {
        Node source = null;
        bool checkOk = true;
        var n = scopedSymbolTable[currentScope, sourceName.Item1];
        if (n != null && n.Type is Node) source = (Node)n.Type;
        else checkOk = false;

        if (!string.IsNullOrEmpty(sourceName.Item2) && checkOk) {
          if (!source.Outputs.Keys.Contains(sourceName.Item2)) checkOk = false;                    
        }        

        if(checkOk) {
          sources.Add(source);
          checkedSourceNames.Add(sourceName);
        }
      }
      // sinks
      foreach (var sinkName in sinkNames) {
        Node sink = null;
        bool checkOk = true;
        var n = scopedSymbolTable[currentScope, sinkName.Item1];
        if (n != null && n.Type is Node) sink = (Node)n.Type;
        else checkOk = false;

        if (!string.IsNullOrEmpty(sinkName.Item2) && checkOk) {
          if (!sink.Inputs.Keys.Contains(sinkName.Item2)) checkOk = false;                    
        }

        if (checkOk) {
          sinks.Add(sink);
          checkedSinkNames.Add(sinkName);
        }
      }
      // old
      //foreach (var sinkName in sinkNames) {
      //  if (scopedSymbolTable[currentScope, sinkName]?.Type is Node) {
      //    sinks.Add((Node)scopedSymbolTable[currentScope, sinkName].Type);
      //    checkedSinkNames.Add(sinkName);
      //  }
      //}

      // perform connection
      foreach (var source in sources) source.Sinks.AddRange(checkedSinkNames.Select(x => x.Item1));
      foreach (var sink in sinks) sink.Sources.AddRange(checkedSourceNames.Select(x => x.Item1));

      // collect and persist edges
      foreach(var sourceName in checkedSourceNames) {
        foreach(var sinkName in checkedSinkNames) {
          var edge =new Edge(sourceName.Item1, sourceName.Item2, sinkName.Item1, sinkName.Item2, edgeType, query);
          ((Node)scopedSymbolTable[currentScope, sourceName.Item1].Type).Edges.Add(edge);
          ((Node)scopedSymbolTable[currentScope, sinkName.Item1].Type).Edges.Add(edge);
          var name = sourceName.Item1 + "." + sourceName.Item2 + edgeType + sinkName.Item1 + "." + sinkName.Item2;
          scopedSymbolTable.AddSymbol(name, edge, currentScope, false);
        }
      }


      // old
      //var sourceName = stmt.source.GetText();
      //var sinkName = stmt.sink.GetText();

      //Node source = null, sink = null;

      //if (!string.IsNullOrWhiteSpace(sourceName) && scopedSymbolTable[currentScope, sourceName]?.Type is Node)
      //  source = (Node)scopedSymbolTable[currentScope, sourceName].Type;
      //if (!string.IsNullOrWhiteSpace(sourceName) && scopedSymbolTable[currentScope, sinkName]?.Type is Node)
      //  sink = (Node)scopedSymbolTable[currentScope, sinkName].Type;

      //if (source != null && sink != null) {
      //  source.Sinks.Add(sinkName);
      //  sink.Sources.Add(sourceName);
      //}

      return null;
    }

    public override object VisitImportStatement([NotNull] SeidlParser.ImportStatementContext context) {
      var stmt = context.importstatement();
      //var url = stmt.STRINGLITERAL().GetText();
      var url = stmt.@string().GetText().Trim('\"');

      if (!string.IsNullOrWhiteSpace(url)) {
        string fp = url;
        if(!File.Exists(fp)) {
          string dir = Path.GetDirectoryName(Path.GetFullPath(programTextUrl));
          fp = Path.Combine(dir, url);
        }

        var programText = Utils.ReadFile(fp);
        var parser = Utils.TokenizeAndParse(programText);
        var linter = new Linter(parser);
        linter.ProgramTextUrl = fp;

        var sst = linter.CreateScopedSymbolTable();
        var readScope = sst.Global;

        // integrate read scope to current one
        foreach (var s in readScope.Symbols) currentScope.Symbols.Add(s.Key, s.Value);
        foreach (var s in readScope.ChildScopes) currentScope.ChildScopes.Add(s.Key, s.Value); 
      }

      return null;
    }

    private void ReadNodeSignature(SeidlParser.NodetypesignatureContext signature, Node node) {
      for (int i = 0; i < signature.inputs.variable().Length; i++) {
        var msgname = signature.inputs.variable(i).GetText();
        var msgtypename = signature.inputs.messagetypename(i).GetText();
        node.Inputs.Add(msgname, Utils.GetMessageType(msgtypename, scopedSymbolTable, currentScope));
      }
      for (int i = 0; i < signature.outputs.variable().Length; i++) {
        var msgname = signature.outputs.variable(i).GetText();
        var msgtypename = signature.outputs.messagetypename(i).GetText();
        node.Outputs.Add(msgname, Utils.GetMessageType(msgtypename, scopedSymbolTable, currentScope));
      }
    }

    private void ReadNodeBody(SeidlParser.NodebodyContext body, Node node) {             
      if (body.inout != null) {
        for (int i = 0; i < body.inout.messagetypelist().variable().Length; i++) {
          
          var input = body.inout.INPUT();

          var msgname = body.inout.messagetypelist().variable(i).GetText();
          var msgtypename = body.inout.messagetypelist().messagetypename(i).GetText();
          var msgtype = Utils.GetMessageType(msgtypename, scopedSymbolTable, currentScope);


          if (input != null) node.Inputs.Add(msgname, msgtype);
          else if (input == null) node.Outputs.Add(msgname, msgtype);
        }
      } else if (body.include != null) {
        // TODO ?!: only if meta-structures will be implemented.
      } else {
        var typecode = body.property.type()?.Start.Type;
        var typename = body.property.typename()?.GetText();
        var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope);
        foreach (var v in body.property.variablelist().variable()) {
          node.Properties.Add(v.GetText(), type);
        }
      }
    }
  }
}
