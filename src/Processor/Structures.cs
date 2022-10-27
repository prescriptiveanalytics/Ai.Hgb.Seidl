using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidl.Processor {

  public interface ISymbol {
    string Name { get; set; }
    Scope Scope { get; set; }
  }

  public class Declaration : ISymbol {
    public string Name { get; set; }
    public Type Type { get; set; }
    public Scope Scope { get; set; }   

    public Declaration(string name, Type type, Scope scope) {
      Name = name;
      Type = type;
      Scope = scope;
    }

    public override string ToString() {
      return $"{Type.Name} {Name}";
    }
  }

  public class Definition : Declaration {

    public object Value { get; set; }        

    public Definition(string name, Type type, Scope scope, object value) 
      : base(name, type, scope) {
      Value = value;
    }

    public override string ToString() {
      return $"{Type.Name} {Name} = {Value}";
    }
  }

  public class Scope {
    public string Name { get; set; }

    public int Level { get; set; }

    public Scope ParentScope { get; set; }

    public Dictionary<string, Scope> ChildScopes { get; set; }

    public Dictionary<string, ISymbol> Symbols { get; set; }

    public Scope() {
      ChildScopes = new Dictionary<string, Scope>();
      Symbols = new Dictionary<string, ISymbol>();
    }

    public Scope(string name, Scope scope) {
      ChildScopes = new Dictionary<string, Scope>();
      Symbols = new Dictionary<string, ISymbol>();
      Name = name;
      ParentScope = scope;
    }

    public override string ToString() {
      //return $"{Name} (${this.GetHashCode()})";
      return $"{Name} ({this.GetHashCode()}) child scopes: [{String.Join(", ", ChildScopes.Select(x => x.Value.GetHashCode()))}]";
    }
  }


  public class ScopedSymbolTable {

    private Scope global;

    public Scope Global { get { return global; } }
    
    public IEnumerable<Scope> Scopes {
      get {
        return GetScopesDownstream(global);
      }
    }

    public IEnumerable<ISymbol> Symbols {
      get {
        return GetSymbolsDownstream(global);
      }
    }

    public ScopedSymbolTable() {
      global = new Scope("global", null);
    }

    public Scope AddScope(string name, Scope parent) {
      var newScope = new Scope(name, parent);      
      if (parent != null) parent.ChildScopes.Add(name + "_" + Guid.NewGuid(), newScope); // TODO
      return newScope;
    }

    public Declaration AddDeclaration(Scope scope, Type type, string name) {
      if (scope.Symbols.ContainsKey(name)) {
        throw new Exception("The defined name is already present in this scope.");
      } else {
        var declaration = new Declaration(name, type, scope);
        scope.Symbols.Add(name, declaration);
        return declaration;
      }
    }

    public Definition AddDefinition(Scope scope, Type type, string name, object value) {      
      if (scope.Symbols.ContainsKey(name)) {
        throw new Exception("The defined name is already present in this scope.");
      } else {
        var definition = new Definition(name, type, scope, value);
        scope.Symbols.Add(name, definition);
        return definition;
      }
    }

    public void Assign(string name, object value, Scope scope) {
      // TODO
    }

    public ISymbol this[Scope scope, string name] {
      get {
        return GetSymbolsUpstream().Where(x => x.Name == name).First();
      }
    }

    public IEnumerable<ISymbol> this[Scope scope] {
      get { return GetSymbolsUpstream(scope); }
    }

    public IEnumerable<Scope> GetScopesUpstream(Scope scope = null) {
      IEnumerable<IEnumerable<Scope>> ScopeLookup(Scope currentScope) {
        if (currentScope.ParentScope == null) yield return new List<Scope>() { currentScope };
        else {
          yield return new List<Scope>() { currentScope };
          yield return ScopeLookup(currentScope.ParentScope).SelectMany(x => x);
        }
      }

      if (scope == null) scope = global;
      return ScopeLookup(scope).SelectMany(x => x);
    }

    public IEnumerable<ISymbol> GetSymbolsUpstream(Scope scope = null) {
      IEnumerable<IEnumerable<ISymbol>> SymbolLookup(Scope currentScope) {
        if (currentScope.ParentScope == null) yield return currentScope.Symbols.Values;
        else {
          yield return currentScope.Symbols.Values;
          yield return SymbolLookup(currentScope.ParentScope).SelectMany(x => x);
        }
      }

      if (scope == null) scope = global;
      
      // V1: complete return
      //return SymbolLookup(scope).SelectMany(x => x);
      // V2: deferred return
      foreach (var symbol in SymbolLookup(scope).SelectMany(x => x)) yield return symbol;

      // V1 vs V2 facts: V1 returns iterator (not a real collection), returned lists are not huge/infinite

      // V3: LINQ-less deferred return
      //foreach (var symbols in SymbolLookup(scope)) {
      //  foreach(var symbol in symbols) yield return symbol;
      //}
    }

    public IEnumerable<Scope> GetScopesDownstream(Scope scope = null) {      
      IEnumerable<IEnumerable<Scope>> ScopeDFS(Scope currentScope) {
        yield return new List<Scope> { currentScope };
        foreach (var childScope in currentScope.ChildScopes) {
          yield return ScopeDFS(childScope.Value).SelectMany(x => x).Prepend(currentScope);
        }
      }

      if (scope == null) scope = global;
      return ScopeDFS(scope).SelectMany(x => x).Distinct();
    }

    public IEnumerable<ISymbol> GetSymbolsDownstream(Scope scope = null) {
      IEnumerable<IEnumerable<ISymbol>> SymbolDFS(Scope currentScope) {
        foreach (var childScope in currentScope.ChildScopes) {
          yield return currentScope.Symbols.Values.Concat(SymbolDFS(childScope.Value).SelectMany(x => x));
        }
      }

      if (scope == null) scope = global;
      return SymbolDFS(scope).SelectMany(x => x).Distinct();
    }
    

    public StringBuilder Print(Scope parent) {
      if (parent == null) {
        var currentScope = Scopes.Where(x => x.ParentScope == parent).First();
        return Print(currentScope, 0);
      } else {
        var sb = new StringBuilder();
        foreach (var scope in Scopes.Where(x => x.ParentScope == parent)) {
          sb.Append(Print(scope, 0));
        }
        return sb;
      }

    }

    public StringBuilder Print(Scope currentScope, int scopeLevel) {
      var sb = new StringBuilder();
      string indent = "  ";
      for (int i = 0; i < scopeLevel; i++) indent += "  ";

      sb.AppendLine($"\n{indent}scope l{scopeLevel}: {currentScope}");
      foreach (var declaration in this[currentScope]) {
        sb.AppendLine($"{indent}{declaration}");
      }

      foreach (var sc in this.Scopes.Where(x => x.ParentScope == currentScope)) {
        sb.Append(Print(sc, scopeLevel + 1));
      }
      return sb;
    }

  }

  public class Parameter {
    public string Name { get; set; }
    public string Typename { get; set; }

    public Type Type { get; set; }
    public bool Topic { get; set; }
  }

  public class Message : Type {
    public string Name { get; set; }
    public List<Parameter> Parameters { get; set; }

    public Message(string name) {
      this.Name = name;
    }
  }

  #region depr

  public class ScopedSymbolTableDeprecated {

    private HashSet<Scope> scopes;
    private Dictionary<(string, Scope), ISymbol> symbols;

    public HashSet<Scope> Scopes { get { return scopes; } }

    public ScopedSymbolTableDeprecated() {
      scopes = new HashSet<Scope>();
      symbols = new Dictionary<(string, Scope), ISymbol>();
    }

    public Scope AddScope(string name, Scope parent) {
      var newScope = new Scope(name, parent);
      scopes.Add(newScope);
      if (parent != null) parent.ChildScopes.Add(name + Guid.NewGuid(), newScope);
      return newScope;
    }

    public Declaration AddDeclaration(Scope scope, Type type, string name) {
      var tuple = new ValueTuple<string, Scope>(name, scope);
      if (!scopes.Contains(scope)) {
        throw new Exception("The defined scope is not available.");
      } else if (symbols.ContainsKey(tuple)) {
        throw new Exception("The defined name is already present in this scope.");
      } else {
        var declaration = new Declaration(name, type, scope);
        symbols.Add(tuple, declaration);
        return declaration;
      }
    }

    public Definition AddDefinition(Scope scope, Type type, string name, object value) {
      var tuple = new ValueTuple<string, Scope>(name, scope);
      if (!scopes.Contains(scope)) {
        throw new Exception("The defined scope is not available.");
      } else if (symbols.ContainsKey(tuple)) {
        throw new Exception("The defined name is already present in this scope.");
      } else {
        var definition = new Definition(name, type, scope, value);
        symbols.Add(tuple, definition);
        return definition;
      }
    }

    public void Assign(string name, object value, Scope scope) {
      // TODO
    }

    public ISymbol this[string name, Scope scope] {
      get {
        return symbols[(name, scope)];
      }
    }

    public IEnumerable<ISymbol> this[Scope scope] {
      get { return GetSymbols(scope); }
    }

    public IEnumerable<ISymbol> GetSymbols(Scope scope) {
      return symbols.Where(x => x.Key.Item2 == scope).Select(x => x.Value);
    }

    public StringBuilder Print(Scope parent) {
      if (parent == null) {
        var currentScope = Scopes.Where(x => x.ParentScope == parent).First();
        return Print(currentScope, 0);
      } else {
        var sb = new StringBuilder();
        foreach (var scope in Scopes.Where(x => x.ParentScope == parent)) {
          sb.Append(Print(scope, 0));
        }
        return sb;
      }

    }

    public StringBuilder Print(Scope currentScope, int scopeLevel) {
      var sb = new StringBuilder();
      string indent = "  ";
      for (int i = 0; i < scopeLevel; i++) indent += "  ";

      sb.AppendLine($"\n{indent}scope l{scopeLevel}: {currentScope}");
      foreach (var declaration in this[currentScope]) {
        sb.AppendLine($"{indent}{declaration}");
      }

      foreach (var sc in this.Scopes.Where(x => x.ParentScope == currentScope)) {
        sb.Append(Print(sc, scopeLevel + 1));
      }
      return sb;
    }

  }

  #endregion depr
}
