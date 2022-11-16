using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidl.Processor {

  #region data structure interfaces

  public interface IType {
    bool Initialized { get; }
    IType Clone();

    IType Copy();

    string GetIdentifier();

    string GetValueString(); 
  }

  public interface IBaseType : IType { 
    new IBaseType Clone();

    new IBaseType Copy();
  }

  public interface IAtomicType : IBaseType { }
  public interface IComplexType : IBaseType { }
  public interface IGraphType : IType { }

  #endregion data structure interfaces

  #region data structures

  public abstract class Type : IType {

    protected bool _initialized = false;

    //private string name;

    public bool Initialized { get { return _initialized; } }

    //public string Name { get { return name; } }

    public abstract IType Clone();

    public abstract IType Copy();

    public virtual string GetIdentifier() {
      return "Type";
    }

    public virtual string GetValueString() {
      return "";
    }
  }


  public class String : Type, IAtomicType {
    string? _value;
    public string Value { 
      get => _value; 
      set {
        _initialized = true;
        _value = value;
      } 
    }

    public String() {
      _initialized = false;
      _value = null;
    }

    public String(string value) {
      _initialized = true;
      _value = value;
    }

    public override IBaseType Clone() {
      return new String();
    }

    public override IBaseType Copy() {
      return new String(Value);
    }

    public override string GetIdentifier() {
      return "string";
    }

    public override string GetValueString() {
      return Initialized ? (Value != null ? Value : "null") : "";
    }
  }

  public class Integer : Type, IAtomicType {
    private int? _value;
    public int? Value {
      get => _value;
        set {
        _initialized = true;
        _value = value;
      }
    }

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

    public override IBaseType Clone() {
      return new Integer();
    }

    public override IBaseType Copy() {
      return new Integer(Value);
    }

    public override string GetIdentifier() {
      return "int";
    }

    public override string GetValueString() {
      return Initialized ? (Value.HasValue ? Value.Value.ToString() : "null") : "";
    }
  }

  public class Float : Type, IAtomicType {
    private float? _value;
    public float? Value {
      get => _value;
      set {
        _initialized = true;
        _value = value;
      }
    }

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

    public override IBaseType Clone() {
      return new Float();
    }

    public override IBaseType Copy() {
      return new Float(Value);
    }

    public override string GetIdentifier() {
      return "float";
    }

    public override string GetValueString() {
      return Initialized ? (Value.HasValue ? Value.Value.ToString() : "null") : "";
    }
  }

  public class Bool : Type, IAtomicType {
    private bool? _value;
    public bool? Value {
      get => _value;
      set {
        _initialized = true;
        _value = value;
      }
    }

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

    public override IBaseType Clone() {
      return new Bool();
    }

    public override IBaseType Copy() {
      return new Bool(Value);
    }

    public override string GetIdentifier() {
      return "bool";
    }

    public override string GetValueString() {
      return Initialized ? (Value.HasValue ? Value.Value.ToString() : "null") : "";
    }
  }

  public class Struct : Type, IComplexType { // TODO: idea: implement IScope and generalize using symbols
    private Dictionary<string, IType> Properties { get; set; } // TODO: allow ITypes (i.e. aliases) not only IBaseTypes 

    public Struct() {
      Properties = new Dictionary<string, IType>();      
    }

    public void AddProperty(string name, IType type) {
      Properties.Add(name, type);
    }

    public override IBaseType Clone() {
      var s = new Struct();
      foreach (var p in Properties) s.Properties.Add(p.Key, p.Value.Clone());
      return s;
    }

    public override IBaseType Copy() {
      var s = new Struct();
      foreach (var p in Properties) s.Properties.Add(p.Key, p.Value.Copy());
      return s;
    }

    public override string GetIdentifier() {
      return "struct";
    }

    public override string GetValueString() {
      return Properties != null && Properties.Keys.Count > 0 ? string.Join(", ", Properties.Keys) : "";
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

    public override IType Clone() {
      return new MessageParameter(Type.Clone(), Name, Topic);            
    }

    public override IType Copy() {
      return new MessageParameter(Type.Copy(), Name, Topic);
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

    public override IType Clone() {
      var m = new Message();
      foreach(var p in Parameters) m.Parameters.Add(p.Key, (MessageParameter)p.Value.Clone());
      return m;
    }

    public override IType Copy() {
      var m = new Message();
      foreach (var p in Parameters) m.Parameters.Add(p.Key, (MessageParameter)p.Value.Copy());
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
    
    public Dictionary<string, IBaseType> Properties { get; set; }

    public Dictionary<string, Message> Inputs { get; set; }
    public Dictionary<string, Message> Outputs { get; set; }
            

    public Node() {
      Properties = new Dictionary<string, IBaseType>();
      Inputs = new Dictionary<string, Message>();
      Outputs = new Dictionary<string, Message>();
      AddDefaultMetaProperties();
    }

    private void AddDefaultMetaProperties() {
      Properties.Add("name", new String());
      Properties.Add("description", new String());
    }

    public override IType Clone() {
      var n = new Node();
      foreach (var p in Properties) n.Properties.Add(p.Key, p.Value.Clone());
      foreach (var i in Inputs) n.Inputs.Add(i.Key, (Message)i.Value.Clone());
      foreach (var i in Outputs) n.Outputs.Add(i.Key, (Message)i.Value.Clone());

      return n;
    }

    public override IType Copy() {
      var n = new Node();
      foreach (var p in Properties) n.Properties.Add(p.Key, p.Value.Copy());
      foreach (var i in Inputs) n.Inputs.Add(i.Key, (Message)i.Value.Copy());
      foreach (var i in Outputs) n.Outputs.Add(i.Key, (Message)i.Value.Copy());

      return n;
    }

    public override string GetIdentifier() {
      return "node";
    }

    public override string GetValueString() {      
      return $"{string.Join(", ", Inputs.Keys)} --> {string.Join(", ", Outputs.Keys)}";
    }
  }

  public class Meta : Type, IGraphType {
    public Dictionary<string, IBaseType> Properties { get; set; }

    public Meta() {
      Properties = new Dictionary<string, IBaseType>();
    }

    public override IType Clone() {
      var m = new Meta();
      foreach (var p in Properties) m.Properties.Add(p.Key, p.Value.Clone());
      return m;
    }

    public override IType Copy() {
      var m = new Meta();
      foreach (var p in Properties) m.Properties.Add(p.Key, p.Value.Copy());
      return m;
    }

    public override string GetIdentifier() {
      return "meta";
    }

    public override string GetValueString() {
      return Properties != null && Properties.Keys.Count > 0 ? string.Join(", ", Properties.Keys) : "";
    }
  }

  #endregion data structures
}


