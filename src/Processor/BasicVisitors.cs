using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://stackoverflow.com/questions/887205/tutorial-for-walking-antlr-asts-in-c
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
      var typeString = context.atomictype().GetText();
      
      foreach (var variable in context.variablelist().variable()) {                
        scopedSymbolTable.AddSymbol(variable.GetText(), Utils.CreateAtomicType(typeString), currentScope);
      }

      return null;
    }

    public override object VisitDefinitionStatement([NotNull] SidlParser.DefinitionStatementContext context) {
      if(context.variablelist().ChildCount != context.expressionlist().ChildCount && context.expressionlist().ChildCount != 1) {
        throw new ArgumentException($"The number of expressions does not match the number of variables. Alternatively a single expression for all variables can be used.");
      }
      bool singleExp = context.expressionlist().ChildCount == 1;
      var typeString = context.atomictype().GetText();

      for(int i = 0; i < context.variablelist().variable().Length; i++) {
        var variable = context.variablelist().variable(i);
        var expression = context.expressionlist().expression(singleExp ? 0 : i);

        scopedSymbolTable.AddSymbol(
          variable.GetText(),
          Utils.CreateAtomicType(typeString, expression),
          currentScope);
      }

      // note: initializations are currently not properly handled...
      //foreach(var variable in context.variablelist().variable()) {
      //  var exp = context.expressionlist().GetText();

      //  scopedSymbolTable.AddSymbol(
      //    variable.GetText(),
      //    Utils.CreateAtomicType(typeString, exp),
      //    currentScope);               
      //}

      return null;
    }

    public override object VisitMessageDefinitionStatement([NotNull] SidlParser.MessageDefinitionStatementContext context) {

      var def = context.messagedefinition();
      var name = def.messagetypename();
      //Console.WriteLine(name.GetText());

      var  varlist = def.topiccustomtypedvariablelist();
      for (int i = 0; i < varlist.variable().Length; i++) { 
        var topic = varlist.TOPIC(i);
        var type = varlist.atomictype(i); // either atomic type ...
        var typename = varlist.typename(i); // ... or custom type is declared
        var variable = varlist.variable(i);        

        //Console.WriteLine($"{topic?.GetText()+" "}{type?.GetText()+" "}{typename?.GetText() + " "}{variable.NAME()}");
      }     


      return null;
      //return base.VisitMessageDefinitionStatement(context);
    }

    public override object VisitNodeDefinitionStatement([NotNull] SidlParser.NodeDefinitionStatementContext context) {
      return null;
    }
  }
}
