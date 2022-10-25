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

  public class WeakScopeSymbolDeclarationVisitor : SidlParserBaseVisitor<object?> {

    public Dictionary<Scope, List<Declaration>> DeclarationStore;    
    private Scope currentScope;

    public WeakScopeSymbolDeclarationVisitor() {
      DeclarationStore = new Dictionary<Scope, List<Declaration>>();
      currentScope = new Scope() { Name = "global", ParentScope = null };
      DeclarationStore.Add(currentScope, new List<Declaration>());
    }

    public override object? VisitSet([NotNull] SidlParser.SetContext context) {
      var statements = context.statement();
      foreach (var statement in statements) {
        Visit(statement);
      }      
      return null;
    }

    public override object? VisitScopeStatement([NotNull] SidlParser.ScopeStatementContext context) {
      var newScope = new Scope() { ParentScope = currentScope, Name = "anonymous" };
      var parentScope = currentScope;
      currentScope = newScope;
      DeclarationStore.Add(currentScope, new List<Declaration>());

      Visit(context.scope().set());

      // reset scope
      currentScope = parentScope;

      return null;
    }


    public override object? VisitDeclarationStatement([NotNull] SidlParser.DeclarationStatementContext context) {
      var typeString = context.type().GetText();
      foreach (var variable in context.variablelist().variable()) {
        var newDeclaration = new Declaration(variable.GetText(), Utils.GetType(typeString), currentScope);        
        DeclarationStore[currentScope].Add(newDeclaration);
      }      
      return null;
    }

    public override object? VisitDefinitionStatement([NotNull] SidlParser.DefinitionStatementContext context) {
      var typeString = context.type().GetText();

      // note: initializations are ignored
      foreach (var variable in context.variablelist().variable()) {
        var newDeclaration = new Declaration(variable.GetText(), Utils.GetType(typeString), currentScope);
        DeclarationStore[currentScope].Add(newDeclaration);
      }
      
      return null;
    }
  }

  public class ScopeSymbolDeclarationVisitor : SidlParserBaseVisitor<object?> {

    public Dictionary<Scope, Dictionary<string, Declaration>> DeclarationStore;
    private Scope currentScope;    

    public ScopeSymbolDeclarationVisitor() {
      DeclarationStore = new Dictionary<Scope, Dictionary<string, Declaration>>();
      currentScope = new Scope("gloabl", null);      
      DeclarationStore.Add(currentScope, new Dictionary<string, Declaration>());      
    }

    public override object? VisitSet([NotNull] SidlParser.SetContext context) {
      var statements = context.statement();
      foreach (var statement in statements) {
        Visit(statement);
      }
      return null;
    }

    public override object? VisitScopeStatement([NotNull] SidlParser.ScopeStatementContext context) {      
      var newScope = new Scope("anonymous", currentScope);
      var parentScope = currentScope;
      currentScope = newScope;
      DeclarationStore.Add(currentScope, new Dictionary<string, Declaration>());

      Visit(context.scope().set());

      // reset scope
      currentScope = parentScope;

      return null;
    }


    public override object? VisitDeclarationStatement([NotNull] SidlParser.DeclarationStatementContext context) {
      var typeString = context.type().GetText();
      foreach (var variable in context.variablelist().variable()) {
        var newDeclaration = new Declaration(variable.GetText(), Utils.GetType(typeString), currentScope);
        try {
          DeclarationStore[currentScope].Add(newDeclaration.Name, newDeclaration);
        }
        catch (ArgumentException ex) {
          throw new Exception($"The variable name '{newDeclaration.Name}' has already been used for another declaration inside this scope. Please choose another name.");
        }
      }
      return null;
    }

    public override object? VisitDefinitionStatement([NotNull] SidlParser.DefinitionStatementContext context) {
      var typeString = context.type().GetText();

      // note: initializations are ignored
      foreach (var variable in context.variablelist().variable()) {
        var newDeclaration = new Declaration(variable.GetText(), Utils.GetType(typeString), currentScope);
        try {
          DeclarationStore[currentScope].Add(newDeclaration.Name, newDeclaration);
        } catch (ArgumentException ex) {
          throw new Exception($"The variable name '{newDeclaration.Name}' has already been used for another declaration inside this scope. Please choose another name.");
        }        
      }

      return null;
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
      string scopeName = scopeVar != null ? scopeVar.GetText() : "anonymous";

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
      var typeString = context.type().GetText();
      
      foreach (var variable in context.variablelist().variable()) {        
        scopedSymbolTable.AddDeclaration(currentScope, Utils.GetType(typeString), variable.GetText());
      }

      return null;
    }

    public override object VisitDefinitionStatement([NotNull] SidlParser.DefinitionStatementContext context) {
      var typeString = context.type().GetText();

      // note: initializations are currently not properly handled...
      foreach(var variable in context.variablelist().variable()) {
        var exp = context.expressionlist().GetText();
        scopedSymbolTable.AddDefinition(currentScope, Utils.GetType(typeString), variable.GetText(), exp);        
      }

      return null;
    }

    public override object VisitMessageDefinitionStatement([NotNull] SidlParser.MessageDefinitionStatementContext context) {

      var def = context.messagedefinition();
      var name = def.messagetypename();
      //Console.WriteLine(name.GetText());

      var  varlist = def.topiccustomtypedvariablelist();
      for (int i = 0; i < varlist.variable().Length; i++) { 
        var topic = varlist.TOPIC(i);
        var type = varlist.type(i);
        var typename = varlist.typename(i);
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
