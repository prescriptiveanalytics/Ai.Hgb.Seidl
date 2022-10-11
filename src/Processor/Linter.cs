using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidl.Processor {
  public class Linter {

    public SidlParser Parser { 
      get { return _parser; } 
      set { _parser = value; } 
    }

    private SidlParser _parser;

    public Linter(SidlParser parser) {
      _parser = parser; 
    }

    public ScopedSymbolTable CreateScopedSymbolTable() {
      var scopedSymbolTableVisitor = new ScopedSymbolTableVisitor();
      SidlParser.RootContext rootContext = _parser.root();
      scopedSymbolTableVisitor.Visit(rootContext);

      var scopedSymbolTable = scopedSymbolTableVisitor.scopedSymbolTable;
      return scopedSymbolTable;
    }

    public void AnalyzeScopeSymbolDeclarations() {
      WeakScopeSymbolDeclarationVisitor declarationVisitor = new WeakScopeSymbolDeclarationVisitor();
      SidlParser.RootContext rootContext = _parser.root();
      declarationVisitor.Visit(rootContext);

      var scopeSymbolStore = declarationVisitor.DeclarationStore;
      CompleteScopeSymbolDependencies(scopeSymbolStore); // generate child dependencies

      var global = scopeSymbolStore.Keys.Where(x => x.ParentScope == null).First();
      Console.WriteLine("\nScope-Symbol declarations:\n");
      PrintScopeSymbolStore(scopeSymbolStore, global, 0);

      var scopeSymbolDuplicateStore = CheckScopeSymbolDuplicates(scopeSymbolStore);
      global = scopeSymbolDuplicateStore.Keys.Where(x => x.ParentScope == null).First();
      Console.WriteLine("\nScope-Symbol duplicates:\n");
      PrintScopeSymbolStore(scopeSymbolDuplicateStore, global, 0);

      Console.WriteLine("\nTest strict Scope-Symbol Visitor:\n");
      ScopeSymbolDeclarationVisitor strictDeclarationVisitor = new ScopeSymbolDeclarationVisitor();
      
      try {
        strictDeclarationVisitor.Visit(rootContext);
      } catch (Exception exc) {
        Console.WriteLine("Linter: " + exc.Message);
      }
    }

    
    public void CompleteScopeSymbolDependencies(Dictionary<Scope, List<Declaration>> scopeSymbolStore) {
      foreach (var scope in scopeSymbolStore.Keys.Where(x => x.ParentScope != null)) {
        scope.ParentScope.ChildScopes.Add(scope.Name, scope);        
      }
    }

    public Dictionary<Scope, Dictionary<string, int>> CheckScopeSymbolDuplicates(Dictionary<Scope, List<Declaration>> scopeSymbolStore) {
      // check uniqueness of each declaration per scope (allow shadowing)
      var scopeSymbolDuplicateStore = new Dictionary<Scope, Dictionary<string, int>>();
      foreach (var scopedDecls in scopeSymbolStore) {
        scopeSymbolDuplicateStore.Add(scopedDecls.Key, new Dictionary<string, int>());
        foreach(var declaration in scopedDecls.Value) {
          if (scopeSymbolDuplicateStore[scopedDecls.Key].ContainsKey(declaration.Name)) scopeSymbolDuplicateStore[scopedDecls.Key][declaration.Name]++;
          else scopeSymbolDuplicateStore[scopedDecls.Key].Add(declaration.Name, 1);
        }
        foreach(var item in scopeSymbolDuplicateStore[scopedDecls.Key].Where(x => x.Value == 1).ToList()) {
          scopeSymbolDuplicateStore[scopedDecls.Key].Remove(item.Key);
        }
      }
      return scopeSymbolDuplicateStore;
    }
    

    public static void PrintScopeSymbolStore(Dictionary<Scope, List<Declaration>> scopeSymbolStore, Scope currentScope, int scopeLevel) {
      string indent = "  ";
      for (int i = 0; i < scopeLevel; i++) indent += "  ";

      Console.WriteLine($"\n{indent}scope l{scopeLevel}: {currentScope}");
      foreach (var declaration in scopeSymbolStore[currentScope]) {
        Console.WriteLine(indent + declaration);
      }

      foreach (var kvp in scopeSymbolStore.Where(x => x.Key.ParentScope == currentScope)) {
        PrintScopeSymbolStore(scopeSymbolStore, kvp.Key, scopeLevel + 1);
      }
    }

    public static void PrintScopeSymbolStore(Dictionary<Scope, Dictionary<string, int>> scopeSymbolStore, Scope currentScope, int scopeLevel) {
      string indent = "  ";
      for (int i = 0; i < scopeLevel; i++) indent += "  ";

      Console.WriteLine($"\n{indent}scope l{scopeLevel}: {currentScope}");
      foreach (var declaration in scopeSymbolStore[currentScope]) {
        Console.WriteLine($"{indent}{declaration.Key}: {declaration.Value}");
      }

      foreach (var kvp in scopeSymbolStore.Where(x => x.Key.ParentScope == currentScope)) {
        PrintScopeSymbolStore(scopeSymbolStore, kvp.Key, scopeLevel + 1);
      }
    }
    
    public static void PrintProgramFormatted(string programText) {
      Console.WriteLine(programText);
    }

  }
}
