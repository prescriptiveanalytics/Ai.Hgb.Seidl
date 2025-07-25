﻿using Ai.Hgb.Common.Entities;
using Ai.Hgb.Seidl.Data;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;

namespace Ai.Hgb.Seidl.Processor // Note: actual namespace depends on the project name.
{
  internal class Program {
    //public static string demoTextFilePath = @"..\..\..\..\..\..\Ai.Hgb.Runtime\src\DemoApps\Texts\demo5.3l";
    public static string demoTextFilePath = @"..\..\..\..\..\..\Ai.Hgb.Runtime\src\DemoApps\Texts\procon.3l";
    public static string generateResultPathRoot = @"..\..\..\..\";

    public static string repositoryHost = "127.0.0.1";
    public static int repositoryPort = 8001;
    public static Uri repositoryUri = new Uri($"http://{repositoryHost}:{repositoryPort}");
    public static HttpClient repositoryClient = null;

    static void Main(string[] args) {
      TestRun();
      //new RuntimeTests().Run();
    }

    public static void TestRun() {
      // setup repository client
      HttpClientHandler clientHandler = new HttpClientHandler();
      clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
      repositoryClient = new HttpClient(clientHandler);
      repositoryClient.BaseAddress = repositoryUri;
      //SetupPackages().Wait();

      string fp = Path.GetFullPath(demoTextFilePath);

      Console.WriteLine("DSL Processor Demo\n");
      Console.WriteLine(" - Reading file...");
      string programText = Utils.ReadFile(fp);

      Console.WriteLine(" - Parsing program...");
      SeidlParser parser = Utils.TokenizeAndParse(programText);


      Console.WriteLine(" - Analyzing program...");
      Transformer linter = new Transformer(parser);
      linter.ProgramTextUrl = fp;
      linter.RepositoryClient = repositoryClient;
      

      var table = linter.CreateScopedSymbolTableSecured();
      var gr = table.GetGraph();
      Console.WriteLine(string.Join(", ", gr.nodes));
      //var table = linter.IdentifyScopedSymbolTable();                  
      //var pkgIs = table[null].Where(x => x.Type is PackageInformation).Select(x => x.Type as PackageInformation).ToList();      
      //Console.WriteLine(string.Join(", ", pkgIs.Select(x => x.Identifier.Name)));

      Console.WriteLine("\n\n");

      var text = table.Print(null);
      Console.WriteLine(text.ToString());

      // node types:
      Console.WriteLine("\n\nNodetypes:");
      var nodeTypes = table[table.Global].Where(x => x.Type is Node && x.IsTypedef);
      foreach (var n in nodeTypes) {
        Console.WriteLine("node: " + n.Name);
        var nt = (Node)n.Type;
        Console.WriteLine(nt.ImageName + ":" + nt.ImageTag);
        Console.WriteLine(nt.Command + "\t" + nt.Arguments + "\tin: " + nt.WorkingDirectory);
        Console.WriteLine("\n");
      }
      Console.WriteLine("\n\n");

      // properties:
      Console.WriteLine("\n\nNodes:");
      var nodeSymbols = table[table.Global].Where(x => x.Type is Node && !x.IsTypedef);
      foreach(var n in nodeSymbols) {
        Console.WriteLine("node: " + n.Name);
        var nt = (Node)n.Type;
        foreach (var prop in nt.Properties) {
          Console.WriteLine(prop.Key + " = " + prop.Value.GetValueString());
        }
        Console.WriteLine("\n");
      }
      Console.WriteLine("\n\n");

      // routing table:
      Console.WriteLine("Routing Table:");
      var rt = table.GetRoutingTable();
      Console.WriteLine("points: " + string.Join(' ', rt.Points.Select(x => x.Id)));
      Console.WriteLine("routes: " + string.Join(' ', rt.Routes.Select(x => x.Id)));
      Console.WriteLine("\n");
      var rtText = JsonSerializer.Serialize(rt);
      Console.WriteLine(rtText);
      Console.WriteLine("\n");
      
      var rtNew = JsonSerializer.Deserialize<RoutingTable>(rtText);
      Console.WriteLine("points: " + string.Join(' ', rtNew.Points.Select(x => x.Id)));
      Console.WriteLine("routes: " + string.Join(' ', rtNew.Routes.Select(x => x.Id)));

      // generate solution
      Console.WriteLine($"\n\nGenerate solution: {table.Name}.{table.Tag}");
      var generator = new Generator();
      generator.GenerateSolution(table, generateResultPathRoot, true);

      Console.WriteLine("\n\n\nEnd of processing.");
    }

    public static async Task SetupPackages() {
      try {

        string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string packagesDir = Path.Join(currentPath, "packages");

        var packageInformations = new List<PackageInformation>();

        foreach (var dir in Directory.GetDirectories(packagesDir)) {
          foreach (var file in Directory.GetFiles(dir, "*.3l")) {
            var descName = Path.GetFileNameWithoutExtension(file);
            var descTag = "latest";

            var programText = Utils.ReadFile(file);
            var sst = IdentifySST(programText);
            if (!string.IsNullOrEmpty(sst.Name)) descName = sst.Name;
            if (!string.IsNullOrEmpty(sst.Tag)) descTag = sst.Tag;

            var desc = new Description() { Name = sst.Name, Tag = sst.Tag };
            desc.Text = programText;

            // check if description = package description
            var pkgIs = sst[null].Where(x => x.Type is PackageInformation).Select(x => x.Type as PackageInformation);

            if (pkgIs != null && pkgIs.Any()) {
              packageInformations.AddRange(pkgIs);
            }
            //else {
            // persist description
            var postResponse = await repositoryClient.PostAsJsonAsync("descriptions", desc);
            if (postResponse.IsSuccessStatusCode) Console.WriteLine("Persisted description.");
            else Console.WriteLine(postResponse.ReasonPhrase);
            //}
          }
        }

        // persist package(s)
        foreach (var pkgi in packageInformations) {
          var pkg = new Package() { Name = pkgi.Identifier.Name, Tag = pkgi.Identifier.Tag };
          var postResponse = await repositoryClient.PostAsJsonAsync("packages", pkg);
          if (postResponse.IsSuccessStatusCode) {
            Console.WriteLine("Persisted package.");
            var pkgId = await postResponse.Content.ReadFromJsonAsync<string>();

            // add descriptions
            var descNameTags = pkgi.DescriptionIdentifiers.Select(x => Tuple.Create(x.Name, x.Tag));
            var postResponse2 = await repositoryClient.PostAsJsonAsync($"packages/{pkgId}/descriptions", descNameTags);
            if (postResponse2.IsSuccessStatusCode) Console.WriteLine("Added descriptions to package.");
            else Console.WriteLine(postResponse2.ReasonPhrase);
          }
        }
      }
      catch (Exception exc) {        
        Console.WriteLine(exc.Message);
      }
    }

    public static ScopedSymbolTable ParseSST(string programText) {
      SeidlParser parser = Utils.TokenizeAndParse(programText);
      Transformer transformer = new Transformer(parser);
      transformer.RepositoryClient = repositoryClient;
      return transformer.CreateScopedSymbolTable();
    }

    public static ScopedSymbolTable IdentifySST(string programText) {
      SeidlParser parser = Utils.TokenizeAndParse(programText);
      Transformer transformer = new Transformer(parser);
      return transformer.IdentifyScopedSymbolTable();
    }

    // Ressources:
    // https://www.youtube.com/watch?v=bfiAvWZWnDA


  }
}