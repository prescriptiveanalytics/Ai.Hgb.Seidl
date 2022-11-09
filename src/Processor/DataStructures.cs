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

    string GetIdentifier();

    string GetValueString(); 
  }

  public interface IBaseType : IType { 
    new IBaseType Clone();
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

    public virtual string GetIdentifier() {
      return "Type";
    }

    public virtual string GetValueString() {
      return "";
    }
  }


  public class String : Type, IAtomicType {
    string _value;
    public string Value { 
      get => _value; 
      set {
        _initialized = true;
        _value = value;
      } 
    }

    public String(string value = null) {
      Value = value;
    }

    public String(bool initialize, string value = null) {
      _initialized = initialize;
      _value = value;
    }

    public override IBaseType Clone() {
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

    public Integer(int? value = null) {
      Value = value;
    }

    public Integer(bool initialize, string value = null) {
      _initialized = initialize;

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
    public float? Value { get; set; }

    public Float(float? value = null) {
      Value = value;
    }

    public Float(bool initialize, string value = null) {
      _initialized = initialize;

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
    public bool? Value { get; set; }

    public Bool(bool? value = null) {
      Value = value;
    }

    public Bool(bool initialize, string value = null) {
      _initialized = initialize;

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
    private Dictionary<string, IBaseType> Properties { get; set; } // TODO: allow ITypes (i.e. aliases) not only IBaseTypes 

    public Struct() {
      Properties = new Dictionary<string, IBaseType>();      
    }

    public void AddProperty(string name, IBaseType type) {
      Properties.Add(name, type);
    }

    public override IBaseType Clone() {
      var s = new Struct();
      foreach (var p in Properties) s.Properties.Add(p.Key, p.Value.Clone());
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
    IBaseType Type { get; set; }

    public string Name { get; set; }
    public bool Topic { get; set; }    

    public MessageParameter() { }

    public MessageParameter(IBaseType type, string name, bool topic = false) {
      Type = type;
      Name = name;
      Topic = topic;
    }

    public override IType Clone() {
      return new MessageParameter(Type.Clone(), Name, Topic);            
    }

  }

  public class Message : Type, IGraphType {
    public Dictionary<string, MessageParameter> Parameters { get; set; }

    public Message() {
      Parameters = new Dictionary<string, MessageParameter>();
    }

    public void AddParameter(IBaseType type, string name, bool topic = false) {
      Parameters.Add(name, new MessageParameter(type, name, topic));
    }

    public override IType Clone() {
      var m = new Message();
      foreach(var p in Parameters) m.Parameters.Add(p.Key, (MessageParameter)p.Value.Clone());
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

    public override string GetIdentifier() {
      return "node";
    }

    public override string GetValueString() {
      return "";
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

    public override string GetIdentifier() {
      return "meta";
    }

    public override string GetValueString() {
      return Properties != null && Properties.Keys.Count > 0 ? string.Join(", ", Properties.Keys) : "";
    }
  }

  #endregion data structures
}


