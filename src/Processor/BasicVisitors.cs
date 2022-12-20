using Antlr4.Runtime.Misc;
using Sidl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://stackoverflow.com/questions/887205/tutorial-for-walking-antlr-asts-in-c
// https://tomassetti.me/best-practices-for-antlr-parsers/

namespace Sidl.Processor {
  public class StatementPrintVisitor : SidlParserBaseVisitor<object> {
    public override object VisitSet([NotNull] SidlParser.SetContext context) {
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

  public class ScopedSymbolTableVisitor : SidlParserBaseVisitor<object?> {

    public ScopedSymbolTable scopedSymbolTable;
    private Scope currentScope;

    public ScopedSymbolTableVisitor() {
      scopedSymbolTable = new ScopedSymbolTable();
      //currentScope = scopedSymbolTable.AddScope("gobal", null);
      currentScope = scopedSymbolTable.Global;
    }

    public override object? VisitSet([NotNull] SidlParser.SetContext context) {
      var statements = context.statement();
      foreach (var statement in statements) {
        Visit(statement);
      }
      return null;
    }

    public override object? VisitScopeStatement([NotNull] SidlParser.ScopeStatementContext context) {
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

    public override object VisitDeclarationStatement([NotNull] SidlParser.DeclarationStatementContext context) {
      var typecode = context.atomictype()?.Start.Type;
      var typename = context.typename()?.GetText();

      foreach (var variable in context.variablelist().variable()) {
        var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope);

        scopedSymbolTable.AddSymbol(variable.GetText(), type, currentScope);
      }
      return null;
    }

    public override object VisitDefinitionStatement([NotNull] SidlParser.DefinitionStatementContext context) {
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

    public override object VisitTypedefStatement([NotNull] SidlParser.TypedefStatementContext context) {
      var def = context.typedefstatement();
      var name = def.variable().GetText();
      var typecode = def.atomictype()?.Start.Type;
      var typename = def.typename()?.GetText();
      var type = Utils.CreateType(typecode, typename, scopedSymbolTable, currentScope);

      scopedSymbolTable.AddSymbol(name,type, currentScope, true);

      return null;
    }

    public override object VisitStructDefinitionStatement([NotNull] SidlParser.StructDefinitionStatementContext context) {

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

    public override object VisitMessageDefinitionStatement([NotNull] SidlParser.MessageDefinitionStatementContext context) {

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

    public override object VisitNodeDefinitionStatement([NotNull] SidlParser.NodeDefinitionStatementContext context) {

      
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

      }

      if(name != null && node != null)
        scopedSymbolTable.AddSymbol(name, node, currentScope, false);

      return null;
    }

    public override object VisitNodetypeDefinitionStatement([NotNull] SidlParser.NodetypeDefinitionStatementContext context) {
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

    public override object VisitNodeConnectionStatement([NotNull] SidlParser.NodeConnectionStatementContext context) {
      var stmt = context.nodeconnectionstatement();
      var sourceName = stmt.source.GetText();
      var sinkName = stmt.sink.GetText();

      Node source = null, sink = null;

      if (!string.IsNullOrWhiteSpace(sourceName) && scopedSymbolTable[currentScope, sourceName]?.Type is Node)
        source = (Node)scopedSymbolTable[currentScope, sourceName].Type;
      if (!string.IsNullOrWhiteSpace(sourceName) && scopedSymbolTable[currentScope, sinkName]?.Type is Node)
        sink = (Node)scopedSymbolTable[currentScope, sinkName].Type;

      if(source != null && sink != null) {
        source.Sinks.Add(sinkName);
        sink.Sources.Add(sourceName);
      }


      return null;
    }

    private void ReadNodeSignature(SidlParser.NodetypesignatureContext signature, Node node) {
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

    private void ReadNodeBody(SidlParser.NodebodyContext body, Node node) {             
      if (body.inout != null) {
        for (int i = 0; i < body.inout.messagetypelist().variable().Length; i++) {
          var aux = body.inout.AUX();
          var input = body.inout.INPUT();

          var msgname = body.inout.messagetypelist().variable(i).GetText();
          var msgtypename = body.inout.messagetypelist().messagetypename(i).GetText();
          var msgtype = Utils.GetMessageType(msgtypename, scopedSymbolTable, currentScope);


          if (input != null && aux == null) node.Inputs.Add(msgname, msgtype);
          else if (input != null && aux != null) node.AuxInputs.Add(msgname, msgtype);
          else if (input == null && aux == null) node.Outputs.Add(msgname, msgtype);
          else if (input == null && aux != null) node.AuxOutputs.Add(msgname, msgtype);
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
