﻿using Antlr4.Runtime.Misc;
using Ai.Hgb.Seidl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.Intrinsics.X86;
using System.Net.Http.Json;
using static Ai.Hgb.Seidl.Processor.SeidlParser;

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

  public class IdentifierVisitor : SeidlParserBaseVisitor<object?> {
    public string programTextUrl;
    public ScopedSymbolTable scopedSymbolTable;
    private Scope currentScope;
    public HttpClient RepositoryClient;

    public IdentifierVisitor() {
      scopedSymbolTable = new ScopedSymbolTable();
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


    public override object VisitNameDefinitionStatement([NotNull] SeidlParser.NameDefinitionStatementContext context) {
      var stmt = context.namedefstatement();
      string name = string.Join('.', stmt.field().variable().Select(x => x.GetText()));
      scopedSymbolTable.Name = name;
      return null;
    }

    public override object VisitTagDefinitionStatement([NotNull] SeidlParser.TagDefinitionStatementContext context) {
      var stmt = context.tagdefstatement();
      string tag = "latest";

      if (stmt.tag().versionnumber() != null) tag = string.Join('.', stmt.tag().versionnumber().number().Select(x => x.GetText()));
      else if (string.IsNullOrEmpty(stmt.tag().GetText())) tag = stmt.tag().GetText();

      scopedSymbolTable.Tag = tag;
      return null;
    }

    public override object VisitNametagDefinitionStatement([NotNull] SeidlParser.NametagDefinitionStatementContext context) {
      var ntctx = context.nametagdefstatement().nametagstatement();
      var nameTag = VisitorUtils.ProcessNameTagDefinitionStatement(ntctx);

      scopedSymbolTable.Name = nameTag.Item1;
      scopedSymbolTable.Tag = nameTag.Item2;
      return null;
    }

    public override object VisitPackageDefinitionStatement([NotNull] PackageDefinitionStatementContext context) {
      var stmt = context.packagedefstatement();

      var pkgIdentifier = VisitorUtils.ProcessNameTagDefinitionStatement(stmt.packageidentifier);
      var pkgContent = stmt.packagecontent.nametagstatement();

      var pkg = new PackageInformation(new VersionIdentifier() { Name = pkgIdentifier.Item1, Tag = pkgIdentifier.Item2 });

      foreach (var identifierCtx in pkgContent) {
        var identifier = VisitorUtils.ProcessNameTagDefinitionStatement(identifierCtx);
        pkg.DescriptionIdentifiers.Add(new VersionIdentifier() { Name = identifier.Item1, Tag = identifier.Item2 });
      }

      scopedSymbolTable.AddSymbol(pkg.GetIdentifier(), pkg, currentScope, false);

      return null;
    }
  }

  public class ScopedSymbolTableVisitor : SeidlParserBaseVisitor<object?> {

    public string programTextUrl;
    public ScopedSymbolTable scopedSymbolTable;
    private Scope currentScope;
    public HttpClient RepositoryClient;

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

        scopedSymbolTable.AddSymbol(variable.GetName(scopedSymbolTable, currentScope), type, currentScope);
      }
      return null;
    }

    public override object VisitDefinitionStatement([NotNull] SeidlParser.DefinitionStatementContext context) {
      if (context.variablelist().ChildCount != context.expressionlist().ChildCount && context.expressionlist().ChildCount != 1) {
        throw new ArgumentException($"The number of expressions does not match the number of variables. Alternatively a single expression for all variables can be used.");
      }
      bool singleExp = context.expressionlist().ChildCount == 1;
      var typecode = context.atomictype()?.Start.Type;
      var typename = context.typename()?.GetText();

      for (int i = 0; i < context.variablelist().variable().Length; i++) {
        var variable = context.variablelist().variable(i);
        var expression = context.expressionlist().expression(singleExp ? 0 : i);
        var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope, expression);
        // TODO: assign expression to looked up type (if typecode = atomictype, all done)

        scopedSymbolTable.AddSymbol(variable.GetName(scopedSymbolTable, currentScope), type, currentScope);
      }
      return null;
    }



    public override object VisitTypedefStatement([NotNull] SeidlParser.TypedefStatementContext context) {
      var def = context.typedefstatement();
      var name = def.variable().GetText();
      var typecode = def.atomictype()?.Start.Type;
      var typename = def.typename()?.GetText();
      var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope);

      scopedSymbolTable.AddSymbol(name, type, currentScope, true);

      return null;
    }

    public override object VisitStructDefinitionStatement([NotNull] SeidlParser.StructDefinitionStatementContext context) {

      var def = context.structdefinition();
      var name = def.variable().GetText();
      var data = new Struct();

      foreach (var property in def.structpropertylist().variable().Zip(def.structpropertylist().atomictypeortypename(), Tuple.Create)) {

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
      var mplist = def.messageparameterlist();
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
        var tn = typename.GetText();
        message.AddParameter(type, typename.GetText(), parametername, topic);
      }

      scopedSymbolTable.AddSymbol(name, message, currentScope, true);

      return null;
    }

    public override object VisitNodeDefinitionStatement([NotNull] SeidlParser.NodeDefinitionStatementContext context) {

      var def = context.nodedefinition();
      var name = def.variable()?.GetName(scopedSymbolTable, currentScope);
      var constructor = def.nodeconstructor();
      var typename = def.typename();

      if (name == null) return null;

      Node node = null;
      node = Utils.GetNodeType(typename.GetText(), scopedSymbolTable, currentScope);

      // alternative 3.1: with constructor        
      if (constructor != null) {
        var asslist = constructor.assignmentlist();
        if (asslist != null) {
          for (int i = 0; i < asslist.assignment().Length; i++) {
            var ass = asslist.assignment(i);
            var propertyName = ass.variable().GetText();
            var exp = ass.expression();

            // evaluate expression
            // skip incompatible options
            if (exp.functiondefinition() != null
              | exp.functioncall() != null
              | exp.importstatement() != null
              | exp.assignmentlist() != null
              | exp.variablelist() != null) continue;

            if (node.Properties.ContainsKey(propertyName)) {
              if (exp.variable() != null) {
                var variableName = exp.variable().GetText();
                var variableSymbol = scopedSymbolTable[currentScope, variableName];
                if (variableSymbol != null) node.Properties[propertyName] = variableSymbol.Type;
              }
              else {
                ProcessAssignment(node.Properties[propertyName], exp);
              }
            }
          }
        }
      }

      if (name != null && node != null)
        scopedSymbolTable.AddSymbol(name, node, currentScope, false);

      return null;
    }

    private void ProcessAssignment(IType target, ExpressionContext exp) {
      if (Utils.IsAtomicType(target)) {
        Utils.TryAssignExpression(target, exp);
      }
      else if (target is ISymbol) {
        ProcessAssignment((target as ISymbol).Type, exp);
      }
    }

    private void ProcessAssignment(IType target, string s) {
      if (Utils.IsAtomicType(target)) {
        Utils.TryAssignString(target, s);
      }
      else if (target is ISymbol) {
        ProcessAssignment((target as ISymbol).Type, s);
      }
    }

    public override object VisitAssignmentStatement([NotNull] AssignmentStatementContext context) {
      var varList = context.variablelist();
      var expList = context.expressionlist();
      var varListLength = varList.variable().Length;
      var expListLength = expList.expression().Length;

      if (varListLength == expListLength) {
        for (int i = 0; i < varListLength; i++) {
          // variable (left side)
          var variableName = varList.variable(i).GetText();
          var persistedVariable = scopedSymbolTable[currentScope, variableName];

          // expression (right side)
          var expression = expList.expression(i);
          string expressionString = null;
          if (expression.variable() != null) {
            var persistedExpVar = scopedSymbolTable[currentScope, expression.variable().GetText()];
            expressionString = persistedExpVar.GetValueString();
          }

          // assignment
          if (persistedVariable != null && expressionString != null) ProcessAssignment(persistedVariable, expressionString);
          else if (persistedVariable != null && expression != null) ProcessAssignment(persistedVariable, expression);

        }
      }
      else {
        // expression (right side)
        var expression = expList.expression().First();
        string expressionString = null;
        if (expression.variable() != null) {
          var persistedExpVar = scopedSymbolTable[currentScope, expression.variable().GetText()];
          expressionString = persistedExpVar.GetValueString();
        }

        foreach (var variable in varList.variable()) {
          // variable (left side)
          var variableName = variable.GetText();
          var persistedVariable = scopedSymbolTable[currentScope, variableName];

          // assignment
          if (persistedVariable != null && expressionString != null) ProcessAssignment(persistedVariable, expressionString);
          else if (persistedVariable != null && expression != null) ProcessAssignment(persistedVariable, expression);
        }
      }

      return null;
    }

    public override object VisitNodetypeDefinitionStatement([NotNull] SeidlParser.NodetypeDefinitionStatementContext context) {
      var def = context.nodetypedefinition();

      var name = def.nodetypename().GetText();
      var body = def.nodebody();

      Node node = new Node();

      if (body != null) {
        VisitorUtils.ReadNodeBody(body, node, scopedSymbolTable, currentScope);
      }

      scopedSymbolTable.AddSymbol(name, node, currentScope, true);

      return null;
    }

    public override object VisitNodeConnectionStatement([NotNull] SeidlParser.NodeConnectionStatementContext context) {
      var stmt = context.nodeconnectionstatement();

      // parse source and sink names (= nodes names with port names)
      var sourceNames = new List<Tuple<string, string>>();
      var sinkNames = new List<Tuple<string, string>>();

      foreach (var from in stmt.sources.field()) {
        if (from.variable().Length == 1) sourceNames.Add(Tuple.Create(from.variable(0).GetName(scopedSymbolTable, currentScope), ""));
        else sourceNames.Add(Tuple.Create(from.variable(0).GetName(scopedSymbolTable, currentScope), from.variable(1).GetText()));
      }
      foreach (var to in stmt.sinks.field()) {
        if (to.variable().Length == 1) sinkNames.Add(Tuple.Create(to.variable(0).GetName(scopedSymbolTable, currentScope), ""));
        else sinkNames.Add(Tuple.Create(to.variable(0).GetName(scopedSymbolTable, currentScope), to.variable(1).GetText()));
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
      if (stmt.ARROW() != null) edgeType = EdgeType.PubSub;
      else if (stmt.HEAVYARROW() != null) edgeType = EdgeType.ReqRes;
      else if (stmt.QUERYARROW_BEGIN() != null) edgeType = EdgeType.PubSubQuery;
      else if (stmt.QUERYHARROW_BEGIN() != null) edgeType = EdgeType.ReqResQuery;

      // parse query
      string query = null;
      if (edgeType == EdgeType.PubSubQuery || edgeType == EdgeType.ReqResQuery) {
        query = stmt.query().GetText();
      }

      var sources = new List<Node>(sourceNames.Count);
      var sinks = new List<Node>(sinkNames.Count);
      var checkedSourceNames = new List<Tuple<string, string>>(sourceNames.Count);
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
          //if (!source.Outputs.Keys.Contains(sourceName.Item2)) checkOk = false;
        }

        if (checkOk) {
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
          //if (!sink.Inputs.Keys.Contains(sinkName.Item2)) checkOk = false;
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
      foreach (var sourceName in checkedSourceNames) {
        foreach (var sinkName in checkedSinkNames) {
          var edge = new Edge(sourceName.Item1, sourceName.Item2, sinkName.Item1, sinkName.Item2, edgeType, query);
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

    public override object VisitNameDefinitionStatement([NotNull] SeidlParser.NameDefinitionStatementContext context) {
      var stmt = context.namedefstatement();
      string name = string.Join('.', stmt.field().variable().Select(x => x.GetText()));
      scopedSymbolTable.Name = name;
      return null;
    }

    public override object VisitTagDefinitionStatement([NotNull] SeidlParser.TagDefinitionStatementContext context) {
      var stmt = context.tagdefstatement();
      string tag = "latest";

      if (stmt.tag().versionnumber() != null) tag = string.Join('.', stmt.tag().versionnumber().number().Select(x => x.GetText()));
      else if (string.IsNullOrEmpty(stmt.tag().GetText())) tag = stmt.tag().GetText();

      scopedSymbolTable.Tag = tag;
      return null;
    }

    public override object VisitNametagDefinitionStatement([NotNull] SeidlParser.NametagDefinitionStatementContext context) {
      var ntctx = context.nametagdefstatement().nametagstatement();
      var nameTag = VisitorUtils.ProcessNameTagDefinitionStatement(ntctx);

      scopedSymbolTable.Name = nameTag.Item1;
      scopedSymbolTable.Tag = nameTag.Item2;
      return null;
    }

    public override object VisitImportStatement([NotNull] SeidlParser.ImportStatementContext context) {
      var stmt = context.importstatement();

      // read url
      var urlString = stmt.@string();
      //var url = stmt.STRINGLITERAL().GetText();                        

      // Option 1: url string      
      if (urlString != null) {
        var url = urlString.GetText().Trim('\"');
        string fp = url;
        if (!File.Exists(fp)) {
          string dir = Path.GetDirectoryName(Path.GetFullPath(programTextUrl));
          fp = Path.Combine(dir, url);
        }

        var programText = Utils.ReadFile(fp);
        var parser = Utils.TokenizeAndParse(programText);
        var linter = new Transformer(parser);
        linter.ProgramTextUrl = fp;

        var sst = linter.CreateScopedSymbolTable();
        VisitorUtils.ProcessImportedScopedSymbolTable(sst, currentScope);

      }
      else {
        // Option 2: name + tag

        // parse name and tag
        string packageName = "", packageTag = "latest";
        packageName = string.Join('.', stmt.field().variable().Select(x => x.GetText()));
        var tag = stmt.tag();
        if (tag != null) packageTag = tag.GetText();
        string packageId = $"{packageName}:{packageTag}";

        // ensure repository client is available
        if (RepositoryClient == null) return null;
        // request stored package
        var getResponse = RepositoryClient.GetAsync($"packages/find/{packageName}/{packageTag}").Result;
        if (getResponse.IsSuccessStatusCode) {
          Common.Entities.Package pkg = getResponse.Content.ReadFromJsonAsync<Common.Entities.Package>().Result;
          scopedSymbolTable.AddPackage(pkg);

          // process package
          foreach (var desc in pkg.Descriptions) {
            var descNameTag = $"{desc.Name}:{desc.Tag}";
            var parser = Utils.TokenizeAndParse(desc.Text);
            var linter = new Transformer(parser);
            linter.ProgramTextUrl = desc.Id;
            linter.RepositoryClient = this.RepositoryClient;

            var sst = linter.CreateScopedSymbolTable();
            VisitorUtils.ProcessImportedScopedSymbolTable(sst, currentScope);
          }
        }
      }

      return null;
    }

    public override object VisitPackageDefinitionStatement([NotNull] PackageDefinitionStatementContext context) {
      var stmt = context.packagedefstatement();

      var pkgIdentifier = VisitorUtils.ProcessNameTagDefinitionStatement(stmt.packageidentifier);
      var pkgContent = stmt.packagecontent.nametagstatement();

      var pkg = new PackageInformation(new VersionIdentifier() { Name = pkgIdentifier.Item1, Tag = pkgIdentifier.Item2 });

      foreach (var identifierCtx in pkgContent) {
        var identifier = VisitorUtils.ProcessNameTagDefinitionStatement(identifierCtx);
        pkg.DescriptionIdentifiers.Add(new VersionIdentifier() { Name = identifier.Item1, Tag = identifier.Item2 });
      }

      scopedSymbolTable.AddSymbol(pkg.GetIdentifier(), pkg, currentScope, false);

      return null;
    }

    public override object VisitLoopStatement([NotNull] LoopStatementContext context) {
      var stmt = context.loopstatement();

      var loopsignature = stmt.loopsignature();
      var iteratorName = loopsignature.iterator.GetText();
      var loopbody = stmt.loopbody();
      var statements = loopbody.statement();

      if (loopsignature.field() != null) {
        var collectionName = loopsignature.field().GetText();
        var elementName = loopsignature.variable().NAME().GetText();

        var collectionSymbol = scopedSymbolTable[currentScope, collectionName];        
        if(collectionSymbol != null && collectionSymbol.Type is Data.Array) {
          var collection = collectionSymbol.Type as Data.Array;

          foreach (IAtomicType iteratorType in collection.Elements) {
            // create and add iterator variable
            scopedSymbolTable.AddSymbol(iteratorName, iteratorType, currentScope);            

            // execute loop body
            foreach (var statement in statements) Visit(statement);

            // remove iterator variable        
            scopedSymbolTable.RemoveSymbol(iteratorName, currentScope);
          }
        }
      }
      else if (loopsignature.integerrange() != null) {
        var range = loopsignature.integerrange();
        var from = int.Parse(range.from.Text);
        var to = int.Parse(range.to.Text);

        // create iterator variable
        var iteratorType = Utils.InstanceAtomicType(SeidlLexer.INT, from.ToString());
        scopedSymbolTable.AddSymbol(iteratorName, iteratorType, currentScope);

        for (int i = from; i < to; i++) {
          // update iterator variable
          var iteratorSymbol = scopedSymbolTable[currentScope, iteratorName];
          (iteratorSymbol.Type as IAtomicType).Assign(i.ToString());

          // execute loop body
          foreach (var statement in statements) Visit(statement);
        }

        // remove iterator variable        
        scopedSymbolTable.RemoveSymbol(iteratorName, currentScope);

      }

      return null;
    }

    public override object VisitConditionalStatement([NotNull] ConditionalStatementContext context) {
      var stmt = context.conditionalstatement();
      List<StatementContext> statements = new List<StatementContext>();      
      var exp = stmt.expression();
      bool matchCase = false;

      // if case
      // matchCase = exp.evaluate();
      if(matchCase) {
        statements.AddRange(stmt.statement());
      } else {
        
        // else if case(s)
        if(stmt.conditionalelseif() != null) {
          var elseifBlocks = stmt.conditionalelseif();
          for(int i = 0; i < elseifBlocks.Length && !matchCase; i++) {
            var elseifBlock = elseifBlocks[i];
            //matchCase = elseifBlock.expression().evaluate();
            if (matchCase) statements.AddRange(elseifBlock.statement());
          }
        }

        // else case
        if(!matchCase && stmt.conditionalelse() != null) {
          statements.AddRange(stmt.conditionalelse().statement());
        }
      }

      foreach (var statement in statements) Visit(statement);

      return null;
    }

    public override object VisitArrayDefinitionStatement([NotNull] ArrayDefinitionStatementContext context) {
      var ctx = context.arraydefinition();

      if (ctx.variablelist().ChildCount != ctx.expressionlist().ChildCount && ctx.expressionlist().ChildCount != 1) {
        throw new ArgumentException($"The number of expressions does not match the number of variables. Alternatively a single expression for all variables can be used.");
      }
      
      var typecode = ctx.atomictype()?.Start.Type;
      bool singleExp = ctx.expressionlist().ChildCount == 1;      

      for (int i = 0; i < ctx.variablelist().variable().Length; i++) {
        var variable = ctx.variablelist().variable(i);
        var expression = ctx.expressionlist().expression(singleExp ? 0 : i);

        var type = Utils.CreateTypeArray(typecode, scopedSymbolTable, currentScope, expression);
        // TODO: assign expression to looked up type (if typecode = atomictype, all done)

        scopedSymbolTable.AddSymbol(variable.GetName(scopedSymbolTable, currentScope), type, currentScope);
      }
      return null;      
    }

  }

  public static class VisitorUtils {

    public static string GetName(this VariableContext variable, ScopedSymbolTable sst, Scope s) {
      string name = variable.GetText();

      if (variable.generatename() != null) {
        var ctx = variable.generatename();

        string text = "";
        if (ctx.VAR() != null) { // VAR keyword
          var nameListLength = ctx.concatelement().Length;
          for (int i = 0; i < nameListLength; i++) {
            var element = ctx.concatelement(i);

            if (element.NAME() != null) {
              var variableName = element.NAME().GetText();
              var persistedVariable = sst[s, variableName];
              text += persistedVariable.Type.GetValueString();
            }
            else if (element.STRINGLITERAL() != null) {
              text += Utils.UnwrapStringbody(element.STRINGLITERAL().GetText());
            }
          }
        } else {
          text += ctx.baseelement.Text;
          var elements = ctx.bracketinterpolationelement();
          var count = elements.Length;

          for (int i = 0; i < count; i++) {  
            if(elements[i].interpolation != null) {              
              var variableName = elements[i].NAME().GetText();
              var persistedVariable = sst[s, variableName];
              text += persistedVariable != null ? persistedVariable.Type.GetValueString() : variableName;
            } else if (elements[i].element != null) {
              text += elements[i].GetText();
            }              
          }
        }


          //else { // Interpolation v1                   
          //  if (ctx.baseinterpolation != null && ctx.baseelement.NAME() != null) {
          //    var persistedVariable = sst[s, ctx.baseelement.NAME().GetText()];
          //    text += persistedVariable != null ? persistedVariable.Type.GetValueString() : ctx.baseelement.NAME().GetText();
          //  } else if(ctx.baseelement.STRINGLITERAL() != null) {
          //    text += Utils.UnwrapStringbody(ctx.baseelement.STRINGLITERAL().GetText());
          //  } else text += ctx.baseelement.NAME().GetText();

          //  var listLength = ctx.interpolationlist().concatelement().Length;
          //  var list = ctx.interpolationlist();
          //  for (int i = 0; i < listLength; i++) {
          //    var element = list.concatelement(i);

          //    if(element.NAME() != null) {
          //      var variablename = element.NAME().GetText();
          //      var persistedVariable = sst[s, variablename];
          //      text += persistedVariable != null ? persistedVariable.Type.GetValueString() : variablename;
          //    } else if (element.STRINGLITERAL() != null) {
          //      text += Utils.UnwrapStringbody(element.STRINGLITERAL().GetText());
          //    }
          //  }
          //}


          name = text.Replace(' ', '_');
      }

      return name;
    }

    public static void ReadNodeBody(SeidlParser.NodebodyContext body, Node node, ScopedSymbolTable scopedSymbolTable, Scope currentScope) {

      // parse ports (publish, subscribe)
      if (body.inout != null) {
        for (int i = 0; i < body.nodebodyinout().Length; i++) {          
          var inout = body.nodebodyinout()[i];
          var msgname = inout.messagetypelist().variable(0).GetText();
          var msgtypename = inout.messagetypelist().messagetypename(0).GetText();
          var msgtype = Utils.GetMessageType(msgtypename, scopedSymbolTable, currentScope);

          if(inout.PUBLISH() != null) node.Publish.Add(msgname, msgtype);
          else if(inout.SUBSCRIBE() != null) node.Subscribe.Add(msgname, msgtype);  
          
          // TODO: req/res adden
        }
      }

      // parse properties
      foreach (var propertyCtx in body.nodebodyproperty()) {
        var typecode = propertyCtx.type()?.Start.Type;
        var typename = propertyCtx.typename()?.GetText();
        var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope);
        foreach (var v in propertyCtx.variablelist().variable()) {
          node.Properties.Add(v.GetText(), type);
        }
      }

      // depr:
      //if (body.property != null) {
      //  var typecode = body.property.type()?.Start.Type;
      //  var typename = body.property.typename()?.GetText();
      //  var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope);
      //  foreach (var v in body.property.variablelist().variable()) {
      //    node.Properties.Add(v.GetText(), type);
      //  }
      //}

      // image
      var imageCtxList = body.nodebodyimage();
      if (imageCtxList != null && imageCtxList.Length > 0) {
        var imageCtx = imageCtxList.Last();
        var nameTag = ProcessNameTagDefinitionStatement(imageCtx.nametagstatement());
        node.ImageName = nameTag.Item1;
        node.ImageTag = nameTag.Item2;
      }

      // command
      var commandCtxList = body.nodebodycommand();
      if(commandCtxList != null && commandCtxList.Length > 0) {
        var commandCtx = commandCtxList.Last();
        node.Command = commandCtx.command.Text;                
        node.WorkingDirectory = Utils.TrimStringbody(commandCtx.workingdirectory.Text); // TODO: check if dir exists/is accessable
        node.Arguments = Utils.TrimStringbody(commandCtx.arguments.Text); // TODO: use array instead of single string literal
      }
    }

    public static void ProcessImportedScopedSymbolTable(ScopedSymbolTable sst, Scope currentScope) {
      var readScope = sst.Global;

      // integrate read scope to current one
      foreach (var s in readScope.Symbols) currentScope.Symbols.Add(s.Key, s.Value);
      foreach (var s in readScope.ChildScopes) currentScope.ChildScopes.Add(s.Key, s.Value);
    }

    public static Tuple<string, string> ProcessNameTagDefinitionStatement(NametagstatementContext ctx) {
      string name = "", tag = "latest";

      name = string.Join('.', ctx.field().variable().Select(x => x.GetText()));
      if (ctx.tag() != null) {
        if (ctx.tag().versionnumber() != null) tag = string.Join('.', ctx.tag().versionnumber().number().Select(x => x.GetText()));
        else if (!string.IsNullOrEmpty(ctx.tag().GetText())) tag = ctx.tag().GetText();
      }

      return Tuple.Create(name, tag);
    }
  }
}
