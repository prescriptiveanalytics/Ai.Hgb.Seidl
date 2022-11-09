using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidl.Processor {

  public interface ISymbol : IType {
    string Name { get; set; }
    IScope Parent { get; set; }
    IType Type { get; set; }
  }

  public  interface IScope : ISymbol {
    Dictionary<string, IScope> ChildScopes { get; set; }
    Dictionary<string, ISymbol> Symbols { get; set; }    
  }

  public class Symbol : Type, ISymbol {
    public string Name { get; set; }
    public IType Type { get; set; }
    public IScope Parent { get; set; }   

    public Symbol(string name, IType type, IScope scope) {
      Name = name;
      Type = type;
      Parent = scope;      
    }
    
    public override string ToString() {
      return $"{Type.GetIdentifier()} {Name} = {Type.GetValueString()}";
    }

    public override IType Clone() {
      var s = new Symbol(Name, Type.Clone(), (IScope)Parent.Clone());
      return s;
    }

    public override string GetIdentifier() {
      return Name;
    }

    public override string GetValueString() {
      return Type.GetValueString();
    }
  }

  public class Scope : Type, IScope {
    public string Name { get; set; }

    public IType Type { get; set; }

    public int Level { get; set; }

    public IScope Parent { get; set; }

    public Dictionary<string, IScope> ChildScopes { get; set; }

    public Dictionary<string, ISymbol> Symbols { get; set; }


    public Scope() {
      Type = this;
      ChildScopes = new Dictionary<string, IScope>();
      Symbols = new Dictionary<string, ISymbol>();
    }

    public Scope(string name, IScope scope) {
      ChildScopes = new Dictionary<string, IScope>();
      Symbols = new Dictionary<string, ISymbol>();
      Name = name;
      Parent = scope;
    }

    public override string ToString() {
      //return $"{Name} (${this.GetHashCode()})";
      return $"{Name} ({this.GetHashCode()}) child scopes: [{System.String.Join(", ", ChildScopes.Select(x => x.Value.GetHashCode()))}]";
    }

    public override IType Clone() {
      var s = new Scope(Name, Parent);
      foreach (var cs in ChildScopes) s.ChildScopes.Add(cs.Key, (IScope)cs.Value.Clone());
      foreach (var sy in Symbols) s.Symbols.Add(sy.Key, (ISymbol)sy.Value.Clone());
      return s;
    }

    public override string GetIdentifier() {
      return Name;
    }

    public override string GetValueString() {
      return "";
    }
  }


  public class ScopedSymbolTable {

    private Scope global;

    public Scope Global { get { return global; } }

    public IEnumerable<IScope> Scopes {
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

    public Scope AddScope(string name, IScope parent) {
      string newScopeName = name, newScopeIdentifier = name;
      if(string.IsNullOrWhiteSpace(name)) {
        newScopeName = "anonymous";
        newScopeIdentifier = "anonymous" + "_" + Guid.NewGuid();
      }
      
      if(parent.ChildScopes.ContainsKey(newScopeIdentifier)) {
        throw new Exception("The defined name is already present in this scope.");
      }

      var newScope = new Scope(newScopeName, parent);
      if (parent != null) parent.ChildScopes.Add(newScopeIdentifier, newScope); // TODO
      return newScope;
    }

    public Symbol AddSymbol(string name, IType type, IScope parent) {
      if (parent.Symbols.ContainsKey(name)) {
        throw new Exception("The defined name is already present in this scope.");
      } else {
        var s = new Symbol(name, type, parent);
        parent.Symbols.Add(name, s);
        return s;
      }
    }

    //public Declaration AddDeclaration(Scope scope, Type type, string name) {
    //  if (scope.Symbols.ContainsKey(name)) {
    //    throw new Exception("The defined name is already present in this scope.");
    //  } else {
    //    var declaration = new Declaration(name, type, scope);
    //    scope.Symbols.Add(name, declaration);
    //    return declaration;
    //  }
    //}

    //public Definition AddDefinition(Scope scope, Type type, string name, object value) {
    //  if (scope.Symbols.ContainsKey(name)) {
    //    throw new Exception("The defined name is already present in this scope.");
    //  } else {
    //    var definition = new Definition(name, type, scope, value);
    //    scope.Symbols.Add(name, definition);
    //    return definition;
    //  }
    //}

    public void Assign(string name, object value, Scope scope) {
      // TODO
    }

    public ISymbol this[IScope scope, string name] {
      get {
        return GetSymbolsUpstream().Where(x => x.Name == name).First();
      }
    }

    public IEnumerable<ISymbol> this[IScope scope] {
      get { return GetSymbolsUpstream(scope); }
    }

    public IEnumerable<IScope> GetScopesUpstream(IScope scope = null) {
      IEnumerable<IEnumerable<IScope>> ScopeLookup(IScope currentScope) {
        if (currentScope.Parent == null) yield return new List<IScope>() { currentScope };
        else {
          yield return new List<IScope>() { currentScope };
          yield return ScopeLookup(currentScope.Parent).SelectMany(x => x);
        }
      }

      if (scope == null) scope = global;
      return ScopeLookup(scope).SelectMany(x => x);
    }

    public IEnumerable<ISymbol> GetSymbolsUpstream(IScope scope = null) {
      IEnumerable<IEnumerable<ISymbol>> SymbolLookup(IScope currentScope) {
        if (currentScope.Parent == null) yield return currentScope.Symbols.Values;
        else {
          yield return currentScope.Symbols.Values;
          yield return SymbolLookup(currentScope.Parent).SelectMany(x => x);
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

    public IEnumerable<IScope> GetScopesDownstream(IScope scope = null) {
      IEnumerable<IEnumerable<IScope>> ScopeDFS(IScope currentScope) {
        yield return new List<IScope> { currentScope };
        foreach (var childScope in currentScope.ChildScopes) {
          yield return ScopeDFS(childScope.Value).SelectMany(x => x).Prepend(currentScope);
        }
      }

      if (scope == null) scope = global;
      return ScopeDFS(scope).SelectMany(x => x).Distinct();
    }

    public IEnumerable<ISymbol> GetSymbolsDownstream(IScope scope = null) {
      IEnumerable<IEnumerable<ISymbol>> SymbolDFS(IScope currentScope) {
        foreach (var childScope in currentScope.ChildScopes) {
          yield return currentScope.Symbols.Values.Concat(SymbolDFS(childScope.Value).SelectMany(x => x));
        }
      }

      if (scope == null) scope = global;
      return SymbolDFS(scope).SelectMany(x => x).Distinct();
    }


    public StringBuilder Print(IScope parent) {
      if (parent == null) {
        var currentScope = Scopes.Where(x => x.Parent == parent).First();
        return Print(currentScope, 0);
      } else {
        var sb = new StringBuilder();
        foreach (var scope in Scopes.Where(x => x.Parent == parent)) {
          sb.Append(Print(scope, 0));
        }
        return sb;
      }

    }

    public StringBuilder Print(IScope currentScope, int scopeLevel) {
      var sb = new StringBuilder();
      string indent = "  ";
      for (int i = 0; i < scopeLevel; i++) indent += "  ";

      sb.AppendLine($"\n{indent}scope l{scopeLevel}: {currentScope}");
      foreach (var symbol in this[currentScope]) {
        sb.AppendLine($"{indent}{symbol}");
      }

      foreach (var sc in this.Scopes.Where(x => x.Parent == currentScope)) {
        sb.Append(Print(sc, scopeLevel + 1));
      }
      return sb;
    }

  }


}
