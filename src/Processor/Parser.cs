using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.Text.Json;

namespace Sidl.Processor {

  public class YamlParser {

    private ISerializer ser;
    private IDeserializer dser;

    public YamlParser() {
      ser = new SerializerBuilder()
        //.WithNamingConvention(CamelCaseNamingConvention.Instance)
        .IgnoreFields()
        .Build();

      dser = new DeserializerBuilder()
        //.WithNamingConvention(CamelCaseNamingConvention.Instance)
        .IgnoreFields()
        .IgnoreUnmatchedProperties()
        .Build();

    }

    public T Parse<T>(string doc) {
      var config = dser.Deserialize<T>(doc);

      return config;
    }
  }

  public class JsonParser {
    public T Parse<T>(string doc) {
      //JsonSerializerOptions options = new() { WriteIndented = true };
      //var config = JsonSerializer.Deserialize<T>(doc, options);
      var config = JsonSerializer.Deserialize<T>(doc);
      return config;
    }
  }

}
