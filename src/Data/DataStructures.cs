using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ai.Hgb.Seidl.Data {

  #region data structure interfaces

  public interface IType {
    bool Initialized { get; }
    IType ShallowCopy();

    IType DeepCopy();

    string GetIdentifier();

    string GetValueString(); 
  }

  public interface IBaseType : IType { 
    new IBaseType ShallowCopy();

    new IBaseType DeepCopy();
  }

  public interface IAtomicType : IBaseType {
    public void Assign(string value);
  }
  public interface IComplexType : IBaseType {
    public void Assign(string value);
  }
  public interface IGraphType : IType { }

  #endregion data structure interfaces

  #region data structures

  public abstract class Type : IType {

    protected bool _initialized = false;

    //private string name;

    public bool Initialized { get { return _initialized; } }

    //public string Name { get { return name; } }    

    public abstract IType ShallowCopy();

    public abstract IType DeepCopy();

    public virtual string GetIdentifier() {
      return "Type";
    }

    public virtual string GetValueString() {
      return "";
    }    
  }

  public abstract class AtomicType<T> : Type, IAtomicType {
    protected T? _value;
    public T? Value {
      get => _value;
      set {
        _initialized = true;
        _value = value;
      }
    }

    IBaseType IBaseType.DeepCopy() {
      throw new NotImplementedException();
    }

    IBaseType IBaseType.ShallowCopy() {
      throw new NotImplementedException();
    }

    public abstract void Assign(string value);
  }

  public class String : AtomicType<string?> {

    public String() {
      _initialized = false;
      _value = null;
    }

    public String(string value) {
      _initialized = true;
      _value = value;
    }

    public override IBaseType ShallowCopy() {
      return new String();
    }

    public override IBaseType DeepCopy() {
      return new String(Value);
    }

    public override string GetIdentifier() {
      return "string";
    }

    public override string GetValueString() {
      return Initialized ? (Value != null ? Value : "null") : "";
    }

    public override void Assign(string value) {
      _initialized = true;
      _value = value;
    }
  }

  public class Integer : AtomicType<int?> {

    public Integer() {
      _initialized = false;
      _value = null;
    }

    public Integer(int? value) {
      Value = value;
      _initialized = true;
    }

    public Integer(string value) {     
      if (value != null) {
        int parsedValue;
        if (int.TryParse(value, out parsedValue)) {
          Value = parsedValue;
        } else {
          throw new ArgumentException("The given value can not be converted to an integer.");
        }
      }      
    }

    public override IBaseType ShallowCopy() {
      return new Integer();
    }

    public override IBaseType DeepCopy() {
      return new Integer(Value);
    }

    public override string GetIdentifier() {
      return "int";
    }

    public override string GetValueString() {
      return Initialized ? (Value.HasValue ? Value.Value.ToString() : "null") : "";
    }

    public override void Assign(string value) {
      if (value != null) {
        int parsedValue;
        if (int.TryParse(value, out parsedValue)) {
          Value = parsedValue;
        }
        else {
          throw new ArgumentException("The given value can not be converted to an integer.");
        }
      }
    }
  }

  public class Float : AtomicType<float?> {

    public Float() {
      _initialized = false;
      _value = null;
    }

    public Float(float? value) {
      _value = value;
      _initialized = true;
    }

    public Float(string value) {
      if (value != null) {
        float parsedValue;
        if (float.TryParse(value, out parsedValue)) {
          Value = parsedValue;
        } else {
          throw new ArgumentException("The given value can not be converted to a float.");
        }
      }
    }

    public override IBaseType ShallowCopy() {
      return new Float();
    }

    public override IBaseType DeepCopy() {
      return new Float(Value);
    }

    public override string GetIdentifier() {
      return "float";
    }

    public override string GetValueString() {
      return Initialized ? (Value.HasValue ? Value.Value.ToString() : "null") : "";
    }

    public override void Assign(string value) {
      if (value != null) {
        float parsedValue;
        if (float.TryParse(value, out parsedValue)) {
          Value = parsedValue;
        }
        else {
          throw new ArgumentException("The given value can not be converted to a float.");
        }
      }
    }
  }

  public class Bool : AtomicType<bool?> {

    public Bool() {
      _initialized = false;
      _value = null;
    }

    public Bool(bool? value) {
      _value = value;
      _initialized = true;
    }

    public Bool(string value) {
      if (value != null) {
        bool parsedValue;
        if (bool.TryParse(value, out parsedValue)) {
          Value = parsedValue;
        } else {
          throw new ArgumentException("The given value can not be converted to a bool.");
        }
      }
    }

    public override IBaseType ShallowCopy() {
      return new Bool();
    }

    public override IBaseType DeepCopy() {
      return new Bool(Value);
    }

    public override string GetIdentifier() {
      return "bool";
    }

    public override string GetValueString() {
      return Initialized ? (Value.HasValue ? Value.Value.ToString() : "null") : "";
    }

    public override void Assign(string value) {
      if (value != null) {
        bool parsedValue;
        if (bool.TryParse(value, out parsedValue)) {
          Value = parsedValue;
        }
        else {
          throw new ArgumentException("The given value can not be converted to a bool.");
        }
      }
    }
  }

  public class Struct : Type, IComplexType { // TODO: idea: implement IScope and generalize using symbols
    public Dictionary<string, IType> Properties { get; set; } 

    public Struct() {
      Properties = new Dictionary<string, IType>();      
    }

    public void AddProperty(string name, IType type) {
      Properties.Add(name, type);
    }

    public override IBaseType ShallowCopy() {
      var s = new Struct();
      foreach (var p in Properties) s.Properties.Add(p.Key, p.Value.ShallowCopy());
      return s;
    }

    public override IBaseType DeepCopy() {
      var s = new Struct();
      foreach (var p in Properties) s.Properties.Add(p.Key, p.Value.DeepCopy());
      return s;
    }

    public override string GetIdentifier() {
      return "struct";
    }

    public override string GetValueString() {
      return Properties != null && Properties.Keys.Count > 0 ? string.Join(", ", Properties.Keys) : "";
    }

    public void Assign(string value) {
      throw new NotImplementedException();
    }
  }

  public class MessageParameter : Type, IType {
    IType Type { get; set; }

    public string Name { get; set; }
    public bool Topic { get; set; }    

    public MessageParameter() { }

    public MessageParameter(IType type, string name, bool topic = false) {
      Type = type;
      Name = name;
      Topic = topic;
    }

    public override IType ShallowCopy() {
      return new MessageParameter(Type.ShallowCopy(), Name, Topic);            
    }

    public override IType DeepCopy() {
      return new MessageParameter(Type.DeepCopy(), Name, Topic);
    }

  }

  public class Message : Type, IGraphType {
    public Dictionary<string, MessageParameter> Parameters { get; set; }

    public Message() {
      Parameters = new Dictionary<string, MessageParameter>();      
    }

    public void AddParameter(IType type, string name, bool topic = false) {
      Parameters.Add(name, new MessageParameter(type, name, topic));
    }

    public override IType ShallowCopy() {
      var m = new Message();
      foreach(var p in Parameters) m.Parameters.Add(p.Key, (MessageParameter)p.Value.ShallowCopy());
      return m;
    }

    public override IType DeepCopy() {
      var m = new Message();
      foreach (var p in Parameters) m.Parameters.Add(p.Key, (MessageParameter)p.Value.DeepCopy());
      return m;
    }

    public override string GetIdentifier() {
      return "message";
    }

    public override string GetValueString() {
      return Parameters != null && Parameters.Keys.Count > 0 ? string.Join(", ", Parameters.Keys) : "";
    }
  }  

  public class Node : Type, IGraphType {
    
    public string ImageName { get; set; }
    public string ImageTag { get; set; }

    public Dictionary<string, IType> Properties { get; set; }

    public Dictionary<string, Message> Inputs { get; set; }
    public Dictionary<string, Message> Outputs { get; set; }

    public List<string> Sources { get; set; }
    public List<string> Sinks { get; set; }

    public List<Edge> Edges { get; set; }
    

    public Node(bool addDefaultMetaProperties = true) {
      Properties = new Dictionary<string, IType>();
      Inputs = new Dictionary<string, Message>();
      Outputs = new Dictionary<string, Message>();
      Sources = new List<string>();
      Sinks = new List<string>();
      Edges = new List<Edge>();
      if (addDefaultMetaProperties) AddDefaultMetaProperties();
    }

    private void AddDefaultMetaProperties() {
      Properties.Add("name", new String());
      Properties.Add("description", new String());
    }

    public override IType ShallowCopy() {
      var n = new Node(false);
      n.ImageName = ImageName;
      n.ImageTag = ImageTag;
      foreach (var p in Properties) n.Properties.Add(p.Key, p.Value.ShallowCopy());
      foreach (var i in Inputs) n.Inputs.Add(i.Key, (Message)i.Value.ShallowCopy());
      foreach (var i in Outputs) n.Outputs.Add(i.Key, (Message)i.Value.ShallowCopy());
      foreach (var i in Sources) n.Sources.Add(i);
      foreach (var i in Sinks) n.Sinks.Add(i);

      return n;
    }

    public override IType DeepCopy() {
      var n = new Node();
      n.ImageName = ImageName;
      n.ImageTag = ImageTag;
      foreach (var p in Properties) n.Properties.Add(p.Key, p.Value.DeepCopy());
      foreach (var i in Inputs) n.Inputs.Add(i.Key, (Message)i.Value.DeepCopy());
      foreach (var i in Outputs) n.Outputs.Add(i.Key, (Message)i.Value.DeepCopy());
      foreach (var i in Sources) n.Sources.Add(i);
      foreach (var i in Sinks) n.Sinks.Add(i);

      return n;
    }

    public override string GetIdentifier() {
      return "node";
    }

    public override string GetValueString() {      
      return $"{string.Join(", ", Inputs.Keys)} --> {string.Join(", ", Outputs.Keys)}";
    }
  }

  public class Edge : Type, IGraphType {

    public string FromNode { get; set; }
    public string FromPort { get; set; }
    public string ToNode { get; set; }
    public string ToPort { get; set; }
    public string Type { get; set; }
    public string Query { get; set; }

    public Edge(string fromNode, string fromPort, string toNode, string toPort, string type, string query) {
      FromNode = fromNode;
      FromPort = fromPort;
      ToNode = toNode;
      ToPort = toPort;
      Type = type;
      Query = query;
    }

    public override IType DeepCopy() {
      return new Edge(this.FromNode, this.FromPort, this.ToNode, this.ToPort, this.Type, this.Query);
    }

    public override IType ShallowCopy() {
      return new Edge(this.FromNode, this.FromPort, this.ToNode, this.ToPort, this.Type, this.Query);
    }

    public override string GetIdentifier() {
      return "edge";
    }

    public override string GetValueString() {
      return $"{FromNode}.{FromPort}{Type}{Query}{ToNode}.{ToPort}";
    }
  }

  public static class EdgeType {
    public static readonly string PubSub = "-->";
    public static readonly string ReqRes = "==>";
    public static readonly string PubSubQuery = "-[]->";
    public static readonly string ReqResQuery = "=[]=>";
  }

  public class Meta : Type, IGraphType {
    public Dictionary<string, IBaseType> Properties { get; set; }

    public Meta() {
      Properties = new Dictionary<string, IBaseType>();
    }

    public override IType ShallowCopy() {
      var m = new Meta();
      foreach (var p in Properties) m.Properties.Add(p.Key, p.Value.ShallowCopy());
      return m;
    }

    public override IType DeepCopy() {
      var m = new Meta();
      foreach (var p in Properties) m.Properties.Add(p.Key, p.Value.DeepCopy());
      return m;
    }

    public override string GetIdentifier() {
      return "meta";
    }

    public override string GetValueString() {
      return Properties != null && Properties.Keys.Count > 0 ? string.Join(", ", Properties.Keys) : "";
    }
  }

  public class PackageInformation : Type { 

    public VersionIdentifier Identifier { get; set; }

    public List<VersionIdentifier> DescriptionIdentifiers { get; set; }

    public PackageInformation() {
      DescriptionIdentifiers = new List<VersionIdentifier>();
    }

    public PackageInformation(string name, string tag) {
      Identifier = new VersionIdentifier() { Name = name, Tag = tag };
      DescriptionIdentifiers = new List<VersionIdentifier>();
      _initialized = true;
    }

    public PackageInformation(VersionIdentifier identifier) {
      Identifier = identifier;
      DescriptionIdentifiers = new List<VersionIdentifier>();
      _initialized = true;
    }

    public PackageInformation(VersionIdentifier identifier, List<VersionIdentifier> descriptionIdentifiers) : this(identifier) {
      DescriptionIdentifiers = descriptionIdentifiers;
      _initialized = true;
    }

    public override IType DeepCopy() {
      var pi = new PackageInformation();
      pi.Identifier = Identifier;
      foreach(var di in DescriptionIdentifiers) pi.DescriptionIdentifiers.Add(di);
      return pi;
    }

    public override IType ShallowCopy() {
      return new PackageInformation(Identifier);
    }

    public override string GetIdentifier() {
      return $"{Identifier.Name}:{Identifier.Tag}";
    }

    public override string GetValueString() {
      return $"{Identifier.Name}:{Identifier.Tag}";
    }
  }

  //public class EdgeType : Enumeration {
  //  public static EdgeType PubSub => new(1, "-->");
  //  public static EdgeType ReqRes => new(2, "==>");

  //  public EdgeType(int id, string name)
  //      : base(id, name) {
  //  }
  //}

  public abstract class Enumeration : IComparable {
    public string Name { get; private set; }

    public int Id { get; private set; }

    protected Enumeration(int id, string name) => (Id, Name) = (id, name);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object obj) {
      if (obj is not Enumeration otherValue) {
        return false;
      }

      var typeMatches = GetType().Equals(obj.GetType());
      var valueMatches = Id.Equals(otherValue.Id);

      return typeMatches && valueMatches;
    }

    public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

    // Other utility methods ...
  }

  public struct VersionIdentifier {
    public string Name { get; set; }
    public string Tag { get; set; }
  }

  #endregion data structures
}


