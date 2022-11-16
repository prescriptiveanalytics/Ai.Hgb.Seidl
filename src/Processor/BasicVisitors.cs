using Antlr4.Runtime.Misc;
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

      var newScope = scopedSymbolTable.AddScope(scopeName, currentScope);
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
      var typename = context.typename();

      foreach (var variable in context.variablelist().variable()) {
        IType type = null;
        if (typecode != null && typecode.HasValue) {
          if (Utils.IsAtomicType(typecode.Value)) type = Utils.CreateAtomicType(typecode.Value, null);
          else throw new ArgumentException("The stated type is not a valid atomic type");
        } else if (typename != null) {
          type = scopedSymbolTable[currentScope, typename.GetText()]; // search for symbol (i.e. struct or graph types)
        }

        scopedSymbolTable.AddSymbol(
          variable.GetText(), 
          type, 
          currentScope);
      }
      return null;
    }

    public override object VisitDefinitionStatement([NotNull] SidlParser.DefinitionStatementContext context) {
      if(context.variablelist().ChildCount != context.expressionlist().ChildCount && context.expressionlist().ChildCount != 1) {
        throw new ArgumentException($"The number of expressions does not match the number of variables. Alternatively a single expression for all variables can be used.");
      }
      bool singleExp = context.expressionlist().ChildCount == 1;
      var typecode = context.atomictype()?.Start.Type;
      var typename = context.typename();

      for(int i = 0; i < context.variablelist().variable().Length; i++) {
        var variable = context.variablelist().variable(i);
        var expression = context.expressionlist().expression(singleExp ? 0 : i);

        IType type = null;
        if (typecode.HasValue) {
          if (Utils.IsAtomicType(typecode.Value)) type = Utils.CreateAtomicType(typecode.Value, expression);
          else throw new ArgumentException("The stated type is not a valid atomic type");
        } else if (typename != null) {
          type = scopedSymbolTable[currentScope, typename.GetText()]; // search for symbol (i.e. struct or graph types)
        }                

        scopedSymbolTable.AddSymbol(
          variable.GetText(),
          type,
          currentScope);
      }
      return null;
    }

    public override object VisitTypedefStatement([NotNull] SidlParser.TypedefStatementContext context) {

      var def = context.typedefstatement();
      IType type;
      if (def.atomictype() != null) type = Utils.CreateAtomicType(def.atomictype().Start.Type, null);
      else type = scopedSymbolTable[currentScope, def.typename().GetText()].Clone(); // TODO clone -> copy

      var name = def.variable().GetText();

      scopedSymbolTable.AddSymbol(
        name,
        type,
        currentScope);

      return null;
    }

    public override object VisitStructDefinitionStatement([NotNull] SidlParser.StructDefinitionStatementContext context) {

      var def = context.structdefinition();
      var name = def.variable().GetText();
      var data = new Struct();

      foreach(var property in def.structpropertylist().variable().Zip(def.structpropertylist().atomictypeortypename(), Tuple.Create)) { 

        var typecode = property.Item2.atomictype()?.Start.Type;
        var typename = property.Item2.typename();

        IType type = null;
        if(typecode.HasValue) {
          if (Utils.IsAtomicType(typecode.Value)) type = Utils.CreateAtomicType(typecode.Value, null);
          else type = scopedSymbolTable[currentScope, typename.GetText()].Clone(); // TODO clone -> copy

        }        

        data.AddProperty(property.Item1.GetText(), type);
      }

      scopedSymbolTable.AddSymbol(
          name,
          data,
          currentScope);

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
          if (t != null) type = t.Clone();
          else throw new ArgumentException($"The message parameter {typename} is not / derived from a base type and hence, not allowed.");
        }
        
        message.AddParameter(type, parametername, topic);
      }

      scopedSymbolTable.AddSymbol(
        name,
        message,
        currentScope);

      return null;      
    }

    private Message ParseMessage(string msgtypename) {
      var symbol = scopedSymbolTable[currentScope, msgtypename];
      if (symbol == null) throw new ArgumentException($"The specified message type {msgtypename} does not exist in this context.");
      else if (symbol.Type is not Message) throw new ArgumentException($"The specified type {msgtypename} is not a message.");
      return (Message)symbol.Type.Clone();
    }


    public override object VisitNodeDefinitionStatement([NotNull] SidlParser.NodeDefinitionStatementContext context) {

      var def = context.nodedefinition();
      var name = def.variable().GetText();
      var signature = def.nodetypesignature();
      var body = def.nodebody();

      var node = new Node();      

      if(signature != null) {        
        for (int i = 0; i < signature.inputs.variable().Length; i++) {
          var msgname = signature.inputs.variable(i).GetText();
          var msgtypename = signature.inputs.messagetypename(i).GetText();
          node.Inputs.Add(msgname, ParseMessage(msgtypename));
        }
        for (int i = 0; i < signature.outputs.variable().Length; i++) {
          var msgname = signature.outputs.variable(i).GetText();
          var msgtypename = signature.outputs.messagetypename(i).GetText();
          node.Outputs.Add(msgname, ParseMessage(msgtypename));
        }
      }

      if(body != null) {

      }
      


      scopedSymbolTable.AddSymbol(
        name,
        node,
        currentScope);

      return null;
    }
  }
}
