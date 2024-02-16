using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai.Hgb.Seidl.Data {

  public interface ISymbol : IType {
    string Name { get; set; }
    IType Type { get; set; }
    IScope Parent { get; set; }
    bool IsTypedef { get; }
  }

  public  interface IScope : ISymbol {
    Dictionary<string, IScope> ChildScopes { get; set; }
    Dictionary<string, ISymbol> Symbols { get; set; }        
  }

  public struct TextPosition {
    public int Line;
    public int Character;
  }

  public struct ScopeLocation {
    public TextPosition Start;
    public TextPosition End;

    public ScopeLocation(int startLine, int startCharacter, int endLine, int endCharacter) {
      Start = new TextPosition { Line = startLine, Character = startCharacter };
      End = new TextPosition { Line = endLine, Character = endCharacter };
    }
  }

  public class Symbol : Type, ISymbol {    
    public string Name { get; set; }
    public IType Type { get; set; }
    public IScope Parent { get; set; }
    public bool IsTypedef { get; set; }

    public Symbol(string name, IType type, IScope scope, bool isTypedef = false) {
      Name = name;
      Type = type;
      Parent = scope;
      IsTypedef = isTypedef;
    }
    
    public override string ToString() {
      return $"{Type.GetIdentifier()} {Name} = {Type.GetValueString()}";
    }

    public override IType ShallowCopy() {
      //var s = new Symbol(Name, Type.Clone(), (IScope)Parent.Clone());
      var s = new Symbol(Name, Type.ShallowCopy(), Parent);
      return s;
    }

    public override IType DeepCopy() {      
      var s = new Symbol(Name, Type.DeepCopy(), Parent);
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

    public IScope Parent { get; set; }
    public bool IsTypedef { get; private set; }
    public int Level { get; set; }

    public ScopeLocation Location { get; set; }


    public Dictionary<string, IScope> ChildScopes { get; set; }

    public Dictionary<string, ISymbol> Symbols { get; set; }


    public Scope() {
      Type = this;
      ChildScopes = new Dictionary<string, IScope>();
      Symbols = new Dictionary<string, ISymbol>();
      IsTypedef = false;
      Location = new ScopeLocation();
    }

    public Scope(string name, IScope scope, 
      int startLine = 0, int startCharacter = 0, int endLine = int.MaxValue, int endCharacter = int.MaxValue) {
      ChildScopes = new Dictionary<string, IScope>();
      Symbols = new Dictionary<string, ISymbol>();
      Name = name;
      Parent = scope;
      IsTypedef = false;
      Location = new ScopeLocation(startLine, startCharacter, endLine, endCharacter);
    }

    public override string ToString() {
      //return $"{Name} (${this.GetHashCode()})";
      return $"{Name} ({this.GetHashCode()}) child scopes: [{System.String.Join(", ", ChildScopes.Select(x => x.Value.GetHashCode()))}]";
    }

    public override IType ShallowCopy() {
      var s = new Scope(Name, Parent);
      s.Level = Level;      
      foreach (var cs in ChildScopes) s.ChildScopes.Add(cs.Key, (IScope)cs.Value.ShallowCopy());
      foreach (var sy in Symbols) s.Symbols.Add(sy.Key, (ISymbol)sy.Value.ShallowCopy());
      return s;
    }

    public override IType DeepCopy() {
      var s = new Scope(Name, Parent);
      s.Level = Level;
      foreach (var cs in ChildScopes) s.ChildScopes.Add(cs.Key, (IScope)cs.Value.DeepCopy());
      foreach (var sy in Symbols) s.Symbols.Add(sy.Key, (ISymbol)sy.Value.DeepCopy());
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

    // import info (TODO: move this to scope)
    public string Name { get; set; }
    public string Tag { get; set; }

    private List<Common.Entities.Package> packages;
    public IEnumerable<Common.Entities.Package> Packages {
      get {
        return packages;
      }
    }


    public ScopedSymbolTable() {
      global = new Scope("global", null);

      // import info
      Name = Guid.NewGuid().ToString();
      Tag = "latest";
      packages = new List<Common.Entities.Package>();
    }

    public Scope AddScope(string name, IScope parent,
      int startLine = 0, int startCharacter = 0, int endLine = int.MaxValue, int endCharacter = int.MaxValue) {
      string newScopeName = name, newScopeIdentifier = name;
      if(string.IsNullOrWhiteSpace(name)) {
        newScopeName = "anonymous";
        newScopeIdentifier = "anonymous" + "_" + Guid.NewGuid();
      }
      
      if(parent.ChildScopes.ContainsKey(newScopeIdentifier)) {
        throw new Exception("The defined name is already present in this scope.");
      }

      var newScope = new Scope(newScopeName, parent, startLine, startCharacter, endLine, endCharacter);
      if (parent != null) parent.ChildScopes.Add(newScopeIdentifier, newScope); // TODO
      return newScope;
    }

    public Symbol AddSymbol(string name, IType type, IScope parent, bool isTypedef = false) {
      if (parent.Symbols.ContainsKey(name)) {
        throw new Exception("The defined name is already present in this scope.");
      } else {
        var s = new Symbol(name, type, parent, isTypedef);
        parent.Symbols.Add(name, s);
        return s;
      }
    }

    public void AddPackage(Common.Entities.Package package) {
      packages.Add(package);
    }

    public void Assign(string name, object value, Scope scope) {
      // TODO
    }

    public ISymbol? this[IScope scope, string name] {
      get {
        return GetSymbolsUpstream(scope).Where(x => x.Name == name).FirstOrDefault();
      }
    }

    public IEnumerable<ISymbol> this[IScope scope] {
      get { return GetSymbolsUpstream(scope); }
    }

    public ISymbol GetSymbolAndCheckBaseType(IScope scope, string name) {
      ISymbol symbol = GetSymbolsUpstream().Where(x => x.Name == name).First();
      ISymbol drilldownSymbol = symbol;

      while (drilldownSymbol != null
        && drilldownSymbol.Type is not IBaseType
        && drilldownSymbol.Type is not IGraphType) {
        drilldownSymbol = GetSymbolsUpstream().Where(x => x.Name == drilldownSymbol.Name).First();
      }
          

      return symbol;
    }

    public ISymbol ResolveBaseType(IScope scope, string name) {
      ISymbol symbol;      

      do {
        symbol = GetSymbolsUpstream().Where(x => x.Name == name).First();
        name = symbol.Name;
      } while (symbol != null
        && symbol.Type is not IBaseType
        && symbol.Type is not IGraphType);

      return symbol;
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

    public Scope GetScope(int line, int character) {
      Scope selected = global;      

      // drill down from global to nested scopes
      foreach(var s in GetScopesDownstream().Select(x => (Scope)x).ToList()) {       
        if(
          (
            (line == s.Location.Start.Line && character > s.Location.Start.Character)
            || (line > s.Location.Start.Line)
          )
          &&
          (
            (line == s.Location.End.Line && character < s.Location.End.Character)
            || (line < s.Location.End.Line)
          )
          ) {
          
          selected = s;
        }
      }

      return selected;
    }

    public GraphRecord GetGraph() {
      var nodeRecs = new List<NodeRecord>();
      var edgeRecs = new HashSet<EdgeRecord>();

      var nodes = GetSymbolsDownstream()
        .Where(x => x.Type is Node && !x.IsTypedef);        

      var edges = GetSymbolsDownstream()
        .Where(x => x.Type is Edge && !x.IsTypedef);


      foreach(var nodeSymbol in nodes) {
        nodeRecs.Add(new NodeRecord(nodeSymbol.Name));
        var nodeValue = (Node)nodeSymbol.Type;

        //foreach (var source in nodeValue.Sources) {
        //  string id = $"{source}-->{nodeSymbol.Name}";
        //  string payload = ""; // nodeValue.Inputs.Select(x => x.Value.GetValueString()).First()
        //  edgeRecs.Add(new EdgeRecord(id, source, nodeSymbol.Name, payload));
        //}

        //foreach (var sink in nodeValue.Sinks) {
        //  string id = $"{nodeSymbol.Name}-->{sink}";
        //  string payload = ""; // nodeValue.Outputs.Select(x => x.Value.GetValueString()).First()
        //  edgeRecs.Add(new EdgeRecord(id, nodeSymbol.Name, sink, payload));
        //}
      }

      var edgesDist = edges.Distinct();
      foreach (var edgeSymbol in edges.Distinct()) {
        var edge = (Edge)edgeSymbol.Type;
        string id = $"{edgeSymbol.Name}";
        string payload = "";
        edgeRecs.Add(new EdgeRecord(id, edge.FromNode, edge.ToNode, edge.Type, payload));
      }

      return new GraphRecord(nodeRecs, edgeRecs);
    }

    public StringBuilder Print(IScope parent) {

      if (parent == null) {
        var currentScope = Scopes.Where(x => x.Parent == parent).First();
        return Print(currentScope, 0);
      } else {
        var sb = new StringBuilder();
        if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Tag)) sb.AppendLine($"{Name}:{Tag}\n");
        foreach (var scope in Scopes.Where(x => x.Parent == parent)) {
          sb.Append(Print(scope, 0));
        }
        return sb;
      }

    }

    public StringBuilder Print(IScope currentScope, int scopeLevel) {
      var sb = new StringBuilder();
      if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Tag)) sb.AppendLine($"{Name}:{Tag}");

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
