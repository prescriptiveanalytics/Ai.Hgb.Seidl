using Ai.Hgb.Common.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ai.Hgb.Seidl.Processor {
  public class RuntimeTests {

    public string demoTextFilePath = @"../../../../Samples/resinet_democombined.3l";
    public static string baseDir = @"G:/My Drive/FHHAGENBERG/FE/Publications/2023_EMSS/Material/experiments/";
    public string baseFileSidl = Path.Combine(baseDir, @"base.3l");
    public string baseFileYaml = Path.Combine(baseDir, @"base.yaml");
    public string baseFileJson = Path.Combine(baseDir, @"base.json");
    public int runs = 10; // 100
    public int burnIn = 20;// 20
    public int timeoutBase = 0; // 150
    public int timeoutAddOnUpperBound = 0; // 50
    public List<int> nodes = new List<int>() { 10 };
    //public List<int> nodes = new List<int>() { 1, 10, 100, 1000, 10000, 100000 };

    public RuntimeTests() {

    }

    public void Run() {
      // Sidl
      var filesSidl = TestRun_GenerateRuntimeExperiment(nodes, true);
      var resultsSidl = TestRun_SidlRuntime(filesSidl);

      // Yaml
      var filesYaml = TestRun_GenerateRuntimeExperiment_Yaml(nodes, true);
      var resultsYaml = TestRun_YamlRuntime(filesYaml);

      // Json
      var filesJson = TestRun_GenerateRuntimeExperiment_Json(nodes, true);
      var resultsJson = TestRun_JsonRuntime(filesJson);

      var results = new List<ResultRow>();
      results.AddRange(resultsSidl);
      results.AddRange(resultsYaml);
      results.AddRange(resultsJson);
      PrintResults(results, Path.Combine(baseDir, @"results.csv"), false);
    }


    public List<ResultRow> TestRun_SidlRuntime(List<Tuple<string, string, int>> files) {
      var swatch = new Stopwatch();
      var rnd = new Random();
      var results = new List<ResultRow>();

      foreach (var file in files) {
        string fp = Path.GetFullPath(file.Item1);
        swatch.Start();
        string programText = Utils.ReadFile(fp);
        swatch.Stop();
        //Console.WriteLine($"\n\nswatch: {swatch.Elapsed.TotalMilliseconds:f4}\n\n");
        var row = new ResultRow($"{file.Item2}_{file.Item3}", runs, file.Item2, file.Item3,
          programText.Length, CountSpecialCharacters(programText), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

        var runtimes = new List<double>();
        for (int i = 0 - burnIn; i < runs; i++) {
          Thread.Sleep(timeoutBase + rnd.Next(0, timeoutAddOnUpperBound));
          swatch.Restart();

          // do work
          SeidlParser parser = Utils.TokenizeAndParse(programText);
          Linter linter = new Linter(parser);
          linter.ProgramTextUrl = fp;
          var table = linter.CreateScopedSymbolTableSecured();

          swatch.Stop();
          if (i >= 0) runtimes.Add(swatch.Elapsed.TotalMilliseconds);
        }

        row.runtime = runtimes.Sum();
        row.mean = runtimes.Mean();
        row.median = runtimes.Median();
        row.min = runtimes.Min();
        row.max = runtimes.Max();
        row.sd = runtimes.StandardDeviation();

        Console.WriteLine(row);
        results.Add(row);
      }
      return results;
    }

    public List<ResultRow> TestRun_YamlRuntime(List<Tuple<string, string, int>> files) {
      var swatch = new Stopwatch();
      var rnd = new Random();
      var parser = new YamlParser();
      var results = new List<ResultRow>();

      foreach (var file in files) {
        string fp = Path.GetFullPath(file.Item1);        
        string programText = Utils.ReadFile(fp);                
        var row = new ResultRow($"{file.Item2}_{file.Item3}", runs, file.Item2, file.Item3,
          programText.Length, CountSpecialCharacters(programText), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

        var runtimes = new List<double>();
        for (int i = 0 - burnIn; i < runs; i++) {
          Thread.Sleep(timeoutBase + rnd.Next(0, timeoutAddOnUpperBound));
          swatch.Restart();

          // do work
          var g = parser.Parse<Graph>(programText); 

          swatch.Stop();
          if (i >= 0) runtimes.Add(swatch.Elapsed.TotalMilliseconds);
        }

        row.runtime = runtimes.Sum();
        row.mean = runtimes.Mean();
        row.median = runtimes.Median();
        row.min = runtimes.Min();
        row.max = runtimes.Max();
        row.sd = runtimes.StandardDeviation();

        Console.WriteLine(row);
        results.Add(row);
      }
      return results;
    }

    public List<ResultRow> TestRun_JsonRuntime(List<Tuple<string, string, int>> files) {
      var swatch = new Stopwatch();
      var rnd = new Random();
      var parser = new JsonParser();
      var results = new List<ResultRow>();

      foreach (var file in files) {
        string fp = Path.GetFullPath(file.Item1);
        string programText = Utils.ReadFile(fp);
        var row = new ResultRow($"{file.Item2}_{file.Item3}", runs, file.Item2, file.Item3,
          programText.Length, CountSpecialCharacters(programText), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);

        var runtimes = new List<double>();
        for (int i = 0 - burnIn; i < runs; i++) {
          Thread.Sleep(timeoutBase + rnd.Next(0, timeoutAddOnUpperBound));
          swatch.Restart();

          // do work
          var g = parser.Parse<Graph>(programText);

          swatch.Stop();
          if (i >= 0) runtimes.Add(swatch.Elapsed.TotalMilliseconds);
        }

        row.runtime = runtimes.Sum();
        row.mean = runtimes.Mean();
        row.median = runtimes.Median();
        row.min = runtimes.Min();
        row.max = runtimes.Max();
        row.sd = runtimes.StandardDeviation();

        Console.WriteLine(row);
        results.Add(row);
      }
      return results;
    }

    public List<Tuple<string, string, int>> TestRun_GenerateRuntimeExperiment(List<int> nodes, bool generateData) {
      var files = new List<Tuple<string, string, int>>() { };

      foreach (var nodeCount in nodes) {
        string programText = Utils.ReadFile(baseFileSidl);
        StringBuilder sb = new StringBuilder(nodeCount * 200);
        sb.Append(programText);

        var nodeNames = new List<string>(nodeCount);
        for (int i = 0; i < nodeCount; i++) {
          nodeNames.Add($"system{i + 1}");
          var nodeInstance = $"node inverter system{i + 1} ( pos=systemPosition, zip=4470, pvPeakProductionPower=6800, housetype=\"house\", area=135, residents=2 )";
          sb.Append("\n" + nodeInstance);
        }
        sb.Append("\n");

        // v1
        sb.Append(string.Join(",", nodeNames) + " --> " + string.Join(",", nodeNames));

        // v2
        //foreach (var from in nodeNames) {
        //  foreach(var to in nodeNames) {
        //    sb.Append($"{from} --> {to}\n");
        //  }
        //}
        sb.Append("\n");

        var newFilePath = Path.Combine(baseDir, @"" + "sidl_nodes" + nodeCount + ".3l");
        if (generateData) File.WriteAllText(newFilePath, sb.ToString());
        files.Add(Tuple.Create(newFilePath, "Sidl", nodeCount));
      }
      return files;
    }

    public List<Tuple<string, string, int>> TestRun_GenerateRuntimeExperiment_Yaml(List<int> nodes, bool generateData) {
      var files = new List<Tuple<string, string, int>>() { };

      foreach (var nodeCount in nodes) {
        string programText = Utils.ReadFile(baseFileYaml);
        StringBuilder sb = new StringBuilder(nodeCount * 200);
        sb.Append(programText);        

        var nodeNames = new List<string>(nodeCount);
        for (int i = 0; i < nodeCount; i++) {
          nodeNames.Add($"system{i + 1}");
          //var nodeInstance = $"node inverter system{i + 1} ( pos=systemPosition, zip=4470, pvPeakProductionPower=6800, housetype=\"house\", area=135, residents=2 )";
          var nodeInstance = $"  - name: system{i + 1}\r\n    type: inverter\r\n    members:\r\n      - name: pos\r\n        value: systemPosition\r\n      - name: zip\r\n        value: 4470\r\n      - name: pvPeakProductionPower\r\n        value: 6800\r\n      - name: housetype\r\n        value: house\r\n      - name: area\r\n        value: 135\r\n      - name: residents\r\n        value: 2";
          sb.Append(nodeInstance + "\n");
        }
        sb.Append("\n");

        // v1
        var edges = $"edges:\r\n  from: [ {string.Join(",", nodeNames)} ]\r\n  to: [ {string.Join(",", nodeNames)} ]";
        sb.Append(edges);

        // v2
        //sb.Append("edges:\r\n");
        //foreach (var from in nodeNames) {
        //  foreach (var to in nodeNames) {
        //    sb.Append($"  - from: {from}\r\n    to: {to}\r\n");
        //  }
        //}

        sb.Append("\n");

        var newFilePath = Path.Combine(baseDir, @"" + "yaml_nodes" + nodeCount + ".yaml");
        if (generateData) File.WriteAllText(newFilePath, sb.ToString());
        files.Add(Tuple.Create(newFilePath, "Yaml", nodeCount));
      }
      return files;
    }

    public List<Tuple<string, string, int>> TestRun_GenerateRuntimeExperiment_Json(List<int> nodes, bool generateData) {
      var files = new List<Tuple<string, string, int>>() { };

      foreach (var nodeCount in nodes) {
        string programText = Utils.ReadFile(baseFileJson);
        StringBuilder sb = new StringBuilder(nodeCount * 200);
        sb.Append(programText);

        var nodeNames = new List<string>(nodeCount);
        sb.Append("\n");
        //sb.Append("\"nodes\": [");
        for (int i = 0; i < nodeCount; i++) {
          nodeNames.Add($"system{i + 1}");
          //var nodeInstance = $"node inverter system{i + 1} ( pos=systemPosition, zip=4470, pvPeakProductionPower=6800, housetype=\"house\", area=135, residents=2 )";
          var nodeInstance = "{\r\n    \"name\": \"system" + (i+1) + "\",\r\n    \"type\": \"inverter\",\r\n    \"members\": [ {\"name\": \"pos\", \"value\": \"systemPosition\"}, {\"name\": \"zip\", \"value\": \"4470\" }, { \"name\": \"pvPeakProductionPower\", \"value\": \"6800\"}, {\"name\": \"housetype\", \"value\": \"house\"}, {\"name\": \"area\", \"value\": \"135\"}, {\"name\": \"residents\", \"value\": \"2\"}]\r\n}";
          sb.Append(nodeInstance);
          if (i+1 < nodeCount) sb.Append(",");
          sb.Append("\n");
        }
        sb.Append("\n],\n");

        // v1
        var edgelist = string.Join(",", nodeNames.Select(x => "\"" + x + "\""));
        var edges = "\"edges\": {\r\n    \"from\": [" + edgelist + "],\r\n    \"to\": [" + edgelist + "]\r\n}";
        sb.Append(edges);

        // v2
        //bool init = true;
        //sb.Append("\"edges\": [\r\n");
        //foreach(var from in nodeNames) {
        //  foreach(var to in nodeNames) {
        //    if (init) { init = false; sb.Append("    "); }
        //    else sb.Append("\r\n    ,");

        //    sb.Append("{ \"from\":\"" + from + "\", \"to\":\"" + to + "\" }");            
        //  }
        //}
        //sb.Append("]");
        sb.Append("\n}");

        var newFilePath = Path.Combine(baseDir, @"" + "json_nodes" + nodeCount + ".json");
        if (generateData) File.WriteAllText(newFilePath, sb.ToString());
        files.Add(Tuple.Create(newFilePath, "Json", nodeCount));
      }
      return files;
    }

    public int CountSpecialCharacters(string programText) {
      var specials = new List<char>() { '\"', '\'', '\n', '\r',
        ',', ';', '.', ':', '(', ')', '[', ']', '{', '}', '/', '\\',
        '>', '<', '-', '+', '*', '#', '&', '!', '$', '?'};
      int count = 0;
      foreach (var special in specials) {
        count += programText.Count(x => x == special);
      }

      return count;
    }

    public void PrintResults(List<ResultRow> results, string fp, bool append = false) {
      using (var sw = new StreamWriter(fp, append)) {
        if (!append) sw.WriteLine(ResultRow.GetTitleRow());
        foreach (var row in results) {
          sw.WriteLine(row.ToString());
        }
      }
    }

    public class ResultRow {

      public string id;
      public int runs;
      public string language;
      public int nodes;
      public int characters;
      public int specialcharacters;
      public double runtime;
      public double mean, median, min, max, sd;

      public ResultRow() { }

      public ResultRow(string id, int runs, string language, int nodes, int characters, int specialcharacters, double runtime, double mean, double median, double min, double max, double sd) {
        this.id = id;
        this.runs = runs;
        this.language = language;
        this.nodes = nodes;
        this.characters = characters;
        this.specialcharacters = specialcharacters;
        this.runtime = runtime;
        this.mean = mean;
        this.median = median;
        this.min = min;
        this.max = max;
        this.sd = sd;
      }

      public override string ToString() {
        return $"{id};{runs};{language};{nodes};{characters};{specialcharacters};{runtime};{mean};{median};{min};{max};{sd}";
      }

      public static string GetTitleRow() {
        return "Run Id;Runs;Language;Nodes;Characters;Special Characters;Runtime;Mean;Median;Min;Max;StdDev";
      }

    }

    public class Graph {
      public Info info { get; set; }
      public List<Variable> typedefinitions { get; set; } 
      public List<StructDef> structdefinitions { get; set; }
      public List<MessageDef> messagedefinitions { get; set; }
      public List<NodetypeDef> nodetypedefinitions { get; set; }  
      public List<Variable> variables { get; set; }
      public List<NodeInstance> nodes { get; set; }
      public EdgeList edges { get; set; } // v1
      //public List<EdgeInstance> edges { get; set; } // v2

      public Graph() {
        typedefinitions = new List<Variable>();
        structdefinitions = new List<StructDef>();
        messagedefinitions = new List<MessageDef>();
        nodetypedefinitions = new List<NodetypeDef>();
        variables = new List<Variable>();
        nodes = new List<NodeInstance>();
        edges = new EdgeList(); // v1
        //edges = new List<EdgeInstance>();
      }  
    }

    public class StructDef {
      public string name { get; set; }
      public List<Variable> members { get; set; }
      public StructDef() {
        members = new List<Variable>();
      }  
    }

    public class MessageDef {
      public string name { get; set; }
      public List<Variable> members { get; set; }
      public MessageDef() {
        members = new List<Variable>();
      }
    }

    public class NodetypeDef {
      public string name { get; set; }
      public List<Variable> members { get; set; }
      public NodetypeDef() {
        members = new List<Variable>();
      }
    }

    public class NodeInstance {
      public string name { get; set; }
      public string type { get; set; }
      public List<Variable> members { get; set; }
      public NodeInstance() {
        members = new List<Variable>();
      }
    }

    public class EdgeInstance {
      public string from { get; set; }
      public string to { get; set; }
    }

    public class EdgeList {
      public List<string> from { get; set; }
      public List<string> to { get; set; }
    }

    public class Variable {
      public string name { get; set; }
      public string type { get; set; }
      public string qualifier { get; set; }
      public string value { get; set; }


      public Variable() { }
    }

    public class Info {
      public string host { get; set; } 
      public int port { get; set; } 
      public string basetopic { get; set; } 

      public Info() { }
    }
  }

}
