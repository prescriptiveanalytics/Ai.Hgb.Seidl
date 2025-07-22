using Ai.Hgb.Common.Entities;
using Ai.Hgb.Seidl.Data;
using Antlr4.Runtime.Dfa;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ai.Hgb.Seidl.Processor {
  public class Generator {

    private CancellationTokenSource cts;
    private AdhocWorkspace workspace;

    private static string libTypeGuid = "9A19103F-16F7-4668-BE54-9A1E7A4F7556";
    private static string appTypeGuid = "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC";

    public List<Data.ProjectInfo> Projects { get; set; }


    public Generator() {
      cts = new CancellationTokenSource();
      workspace = new AdhocWorkspace();
    }

    public List<Data.ProjectInfo> GenerateSolution(ScopedSymbolTable sst, string resultPathRoot, bool overide) {
      var fullPath = Path.GetFullPath(resultPathRoot);
      if(!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
      string rootDir = Path.Combine(fullPath, $"{sst.Name}.{sst.Tag}");
      if (!Directory.Exists(rootDir)) Directory.CreateDirectory(rootDir);

      var splits = sst.Name.Split('.').ToList();
      //string scope = string.Join('.', splits.Take(splits.Count - 1));
      string scope = sst.Name;
      string name = splits.Last();

      var projects = new List<Data.ProjectInfo>();

      string commonDir = Path.Combine(rootDir, "Common");
      if (!Directory.Exists(commonDir)) Directory.CreateDirectory(commonDir);
      var datastructures = sst.GetDataStructures(null);
      GenerateCommonStubs(Path.Combine(commonDir, "Data.cs"), scope, name, datastructures);
      GenerateCommonProjectFile(Path.Combine(commonDir, "Common.csproj"), scope, name);
      projects.Add(new Data.ProjectInfo(Guid.NewGuid().ToString().ToUpper(), libTypeGuid, "Common", ".\\Common", $"Common\\Common.csproj", commonDir, null, null, null));

      var nodetypes = sst.GetNodetypes(null);
      foreach (var nodetype in nodetypes) {
        //Console.WriteLine(nodetype.name);
        string projectDir = Path.Combine(rootDir, nodetype.name);
        if (!Directory.Exists(projectDir)) Directory.CreateDirectory(projectDir);        
        projects.Add(new Data.ProjectInfo(Guid.NewGuid().ToString().ToUpper(), appTypeGuid, nodetype.name, $".\\{nodetype.name}", $"{nodetype.name}\\{nodetype.name}.csproj", projectDir, nodetype.imageName, nodetype.imageTag, nodetype.command));
        GenerateNodetypeProjectFile(Path.Combine(projectDir, $"{nodetype.name}.csproj"), scope, nodetype.name);
        GenerateNodetypeStubs(Path.Combine(projectDir, "Program.cs"), scope, nodetype.name, nodetype);
        GenerateDockerFile(Path.Combine(projectDir, "Dockerfile"), scope, nodetype.name);
      }

      GenerateSolutionFile(Path.Combine(rootDir, $"{name}.sln"), name, projects);

      Projects = projects;
      return Projects;
    }

    public List<Data.ProjectInfo> GetProjectInfos() {
      return Projects;
    }

    public List<Data.ProjectInfo> ParseProjectInfo(ScopedSymbolTable sst, string resultPathRoot) {
      var fullPath = Path.GetFullPath(resultPathRoot);
      if (!Directory.Exists(fullPath)) return null;
      string rootDir = Path.Combine(fullPath, $"{sst.Name}.{sst.Tag}");
      if (!Directory.Exists(rootDir)) return null;

      var splits = sst.Name.Split('.').ToList();
      string scope = sst.Name;
      string name = splits.Last();

      var projects = new List<Data.ProjectInfo>();

      string commonDir = Path.Combine(rootDir, "Common");
      if (!Directory.Exists(commonDir)) return null;
      var datastructures = sst.GetDataStructures(null);
      projects.Add(new Data.ProjectInfo(Guid.NewGuid().ToString().ToUpper(), libTypeGuid, "Common", ".\\Common", $"Common\\Common.csproj", commonDir, null, null, null));

      var nodetypes = sst.GetNodetypes(null);
      foreach (var nodetype in nodetypes) {        
        string projectDir = Path.Combine(rootDir, nodetype.name);
        if (!Directory.Exists(projectDir)) return null;
        projects.Add(new Data.ProjectInfo(Guid.NewGuid().ToString().ToUpper(), appTypeGuid, nodetype.name, $".\\{nodetype.name}", $"{nodetype.name}\\{nodetype.name}.csproj", projectDir, nodetype.imageName, nodetype.imageTag, nodetype.command));
      }      

      return projects;      
    }

    #region code generation

    private void GenerateNodetypeStubs(string resultPath, string scope, string name, NodetypeRecord ntr) {
      try {

        var sb = new StringBuilder();        

        sb.AppendLine(
          $$"""
            using System.Text.Json;
            using System.Text.Json.Serialization;
            using Ai.Hgb.Common.Entities;
            using Ai.Hgb.Dat.Communication;
            using Ai.Hgb.Dat.Configuration;
            using {{scope}}.Common;
            
            namespace {{scope}}.{{name}} {              
              public class Program {
                public static async Task Main(string[] args) {
                  Console.WriteLine("{{scope}}.{{name}}\n");

                  Parameters parameters = null;
                  RoutingTable routingTable = null;
                  HostAddress address = null;
                  
                  try {
                    Console.WriteLine("Parsing parameters");
                    parameters = JsonSerializer.Deserialize<Parameters>(args[0]);
                    Console.WriteLine("Parsing routing table");
                    routingTable = JsonSerializer.Deserialize<RoutingTable>(args[1]);
                    address = new HostAddress(parameters.ApplicationParametersNetworking.HostName, parameters.ApplicationParametersNetworking.HostPort);
                  }
                  catch (Exception ex) {
                      Console.WriteLine(ex.Message);
                      return;
                  }
                  Console.WriteLine("Parsed parameters");

                  // setup socket and converter                  
                  var converter = new JsonPayloadConverter();
                  var cts = new CancellationTokenSource();
                  var token = cts.Token;
                  ISocket socket = null;

                  try {
                    Console.WriteLine("Setup socket");
                    socket = new MqttSocket(parameters.Name, parameters.Name, address, converter, connect: true);                    

            """);

        // publish
        sb.AppendLine("#region publish");
        sb.AppendLine("var producerTasks = new Dictionary<string, Task>();");
        foreach (var port in ntr.routingPoint.Ports.Where(x => x.Type == PortType.Producer)) {
          sb.AppendLine();
          sb.AppendLine("// TODO: move the following to the desired position");
          sb.AppendLine($"// publish port: {port.Id}");          
          string outPayloadId = "outPayload_" + port.Id;
          string outPayloadTypeDef = port.OutPayloadTypes.Count > 1 ? "Tuple<" + string.Join(',', port.OutPayloadTypes) + $"> {outPayloadId} = default;" : port.OutPayloadTypes.First() + $" {outPayloadId} = default;";
          sb.AppendLine(outPayloadTypeDef);          
          sb.AppendLine($$"""foreach(var route in routingTable.Routes.Where(x => x.Source.Id == parameters.Name && x.SourcePort.Type == PortType.Producer && x.SourcePort.Id == "{{port.Id}}")) {""");
          sb.AppendLine($$"""            
            producerTasks["{{port.Id}}"] = new Task( () => {
              // TODO: modify the following control structures by your needs
              Console.WriteLine("Start publishing");
              while(!token.IsCancellationRequested) {
                socket.Publish(route.SourcePort.Address, {{outPayloadId}});     
                Task.Delay(1000, token).Wait();
              }              
            }, token);}
            """);          
        }

        sb.AppendLine("var producerTasksFlat = producerTasks.Values.ToList();");
        sb.AppendLine("#endregion publish");
        sb.AppendLine();

        // subscribe
        sb.AppendLine("#region subscribe");
        foreach(var port in ntr.routingPoint.Ports.Where(x => x.Type == PortType.Consumer)) {
          sb.AppendLine();
          sb.AppendLine("// TODO: move the following to the desired position");
          sb.AppendLine($"// subscription port: {port.Id}");
          string inPayloadType = port.InPayloadTypes.Count > 1 ? $"Tuple<{string.Join(',', port.InPayloadTypes)}>" : port.InPayloadTypes.First();
          sb.AppendLine($$"""foreach(var route in routingTable.Routes.Where(x => x.Sink.Id == parameters.Name && x.SinkPort.Type == PortType.Consumer && x.SinkPort.Id == "{{port.Id}}")) {""");
          sb.AppendLine($$"""
            socket.Subscribe<{{inPayloadType}}>(route.SinkPort.Address, (msg, t) => {
              // TODO: modify the following by your needs
              var payload = ({{inPayloadType}})msg.Content;
              Console.WriteLine($"Received message: {payload.ToString()}");
            }, token);
            """);
          sb.AppendLine("}");
        }
        CancellationToken cancellationToken = new CancellationToken();
        
        sb.AppendLine("#endregion subscribe");
        sb.AppendLine();

        // request (client)
        sb.AppendLine("#region request");
        sb.AppendLine("var requestTasks = new Dictionary<string, Task>();");
        // TODO
        sb.AppendLine("var requestTasksFlat = requestTasks.Values.ToList();");
        sb.AppendLine("#endregion request");
        sb.AppendLine();

        // respond (server)
        sb.AppendLine("#region respond");
        // TODO
        sb.AppendLine("#endregion respond");
        sb.AppendLine();

        sb.AppendLine();
        sb.AppendLine("// start publish and request actions");
        sb.AppendLine("Console.WriteLine(\"start producer tasks\");");
        sb.AppendLine("producerTasksFlat.ForEach(x => x.Start());");
        sb.AppendLine("requestTasksFlat.ForEach(x => x.Start());");
        sb.AppendLine();
        sb.AppendLine("// TODO: do something else ...");
        sb.AppendLine();
        sb.AppendLine("// await publish and request actions");
        sb.AppendLine("Console.WriteLine(\"await producer tasks\");");
        sb.AppendLine("await Task.WhenAll(producerTasksFlat);");
        sb.AppendLine("await Task.WhenAll(requestTasksFlat);");               

        sb.AppendLine(
          $$"""              
                  } catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                  } finally {
                    socket.Unsubscribe();
                    socket.Disconnect();
                  }
                }
              }

              public class Parameters : IApplicationParametersBase, IApplicationParametersNetworking {            
                [JsonPropertyName("applicationParametersBase")]
                public ApplicationParametersBase ApplicationParametersBase { get; set; }
            
                [JsonPropertyName("applicationParametersNetworking")]
                public ApplicationParametersNetworking ApplicationParametersNetworking { get; set; }        
            """);

        foreach(var property in ntr.properties) {
          sb.AppendLine();
          sb.AppendLine($$"""[JsonPropertyName("{{property.Key}}")]""");
          sb.AppendLine($$"""public {{property.Value}} { get; set; }""");          
        }

        sb.AppendLine("}}");

        var formattedCode = FormatCode(sb.ToString());
        File.WriteAllText(resultPath, formattedCode);

      }
      catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    private void GenerateNodetypeProjectFile(string resultPath, string scope, string name) {
      try {
        var sb = new StringBuilder();

        // TODO: insert version of package references via nuget lookup
        sb.AppendLine(
          $$"""
            <Project Sdk="Microsoft.NET.Sdk">

              <PropertyGroup>
                <OutputType>Exe</OutputType>
                <TargetFramework>net9.0</TargetFramework>
                <ImplicitUsings>enable</ImplicitUsings>
                <Nullable>enable</Nullable>
                <AssemblyName>{{scope}}.$(MSBuildProjectName)</AssemblyName>
                <RootNamespace>{{scope}}.$(MSBuildProjectName.Replace(" ", "_"))</RootNamespace>
              </PropertyGroup>

            	<ItemGroup>
            	  <PackageReference Include="Ai.Hgb.Common.Entities" Version="0.1.15-prerelease-g369bb9a25a" />
            	  <PackageReference Include="Ai.Hgb.Dat.Communication" Version="0.1.7-prerelease-gdaf7bfe3e4" />
            	  <PackageReference Include="Ai.Hgb.Dat.Configuration" Version="0.1.11-prerelease-gdaf7bfe3e4" />
            	  <PackageReference Include="Ai.Hgb.Dat.Utils" Version="0.1.5-prerelease-gdaf7bfe3e4" />
            	</ItemGroup>
            	<ItemGroup>
            	  <ProjectReference Include="..\Common\Common.csproj" />
            	</ItemGroup>

            </Project>
            
            """);

        File.WriteAllText(resultPath, sb.ToString());
      }
      catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    private void GenerateDockerFile(string resultPath, string scope, string name) {
      try {
        var sb = new StringBuilder();

        sb.AppendLine(
          $$"""
              FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
              WORKDIR .

              # Copy everything
              COPY "{{name}}/*.csproj" "{{name}}/"
              COPY "Common/*.csproj" "Common/"

              # Restore as distinct layers
              RUN dotnet restore "{{name}}/{{name}}.csproj"

              # Build and publish a release
              COPY "{{name}}/" "{{name}}/"
              COPY "Common/" "Common/"
              WORKDIR /{{name}}
              RUN dotnet publish -c Release -o out
              # COPY {{name}}/configurations /{{name}}/out/configurations

              # Build runtime image
              FROM mcr.microsoft.com/dotnet/aspnet:9.0
              WORKDIR /{{name}}
              COPY --from=build-env /{{name}}/out .
              ENTRYPOINT ["dotnet", "{{scope}}.{{name}}.dll"]                        
            """);

        File.WriteAllText(resultPath, sb.ToString());
      }
      catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    private void GenerateCommonStubs(string resultPath, string scope, string name, Dictionary<string, List<string>> ds) {
      try {        
        var sb = new StringBuilder();

        sb.AppendLine(
        $$"""
          namespace {{scope}}.Common {
          public class Properties {          
          """);

        foreach (var element in ds["properties"]) {
          sb.AppendLine($"public static {element};");
        }
        sb.AppendLine("}");
        sb.AppendLine();

        foreach (var element in ds["structs"]) {
          sb.AppendLine($"public {element}");
        }
        sb.AppendLine("}");

        var formattedCode = FormatCode(sb.ToString());
        File.WriteAllText(resultPath, formattedCode);
      }
      catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    private void GenerateCommonProjectFile(string resultPath, string scope, string name) {
      try {
        var sb = new StringBuilder();

        sb.AppendLine(
          $$"""
            <Project Sdk="Microsoft.NET.Sdk">

              <PropertyGroup>
                <TargetFramework>net9.0</TargetFramework>
                <ImplicitUsings>enable</ImplicitUsings>
                <Nullable>enable</Nullable>
                <AssemblyName>{{scope}}.$(MSBuildProjectName)</AssemblyName>
                <RootNamespace>{{scope}}.$(MSBuildProjectName.Replace(" ", "_"))</RootNamespace>
              </PropertyGroup>

            </Project>
            
            """);

        File.WriteAllText(resultPath, sb.ToString());
      }
      catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
    
    private void GenerateSolutionFile(string resultPath, string name, List<Data.ProjectInfo> projects) {
      try {
        var sb = new StringBuilder();
         
        sb.AppendLine(
          $$"""
            Microsoft Visual Studio Solution File, Format Version 12.00
            # Visual Studio Version 17
            VisualStudioVersion = 17.1.32228.430
            MinimumVisualStudioVersion = 10.0.40219.1
            """);


        foreach (var project in projects) {
          sb.AppendLine(
            $$"""
              Project("{{{project.tguid}}}") = "{{project.name}}", "{{project.relpathpfile}}", "{{{project.pguid}}}"
              EndProject
          
              """
          );
        }


        sb.AppendLine(
          $$"""
            Global
              GlobalSection(SolutionConfigurationPlatforms) = preSolution
            	  Debug|Any CPU = Debug|Any CPU
            	  Release|Any CPU = Release|Any CPU
              EndGlobalSection
              GlobalSection(ProjectConfigurationPlatforms) = postSolution
            """);

        foreach (var project in projects) {
          sb.AppendLine(
            $$"""
              	{{project.pguid}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
              	{{project.pguid}}.Debug|Any CPU.Build.0 = Debug|Any CPU
              	{{project.pguid}}.Release|Any CPU.ActiveCfg = Release|Any CPU
              	{{project.pguid}}.Release|Any CPU.Build.0 = Release|Any CPU
          
              """
          );
        }

        sb.AppendLine(
            $$"""
              EndGlobalSection
              GlobalSection(SolutionProperties) = preSolution
            	  HideSolutionNode = FALSE
              EndGlobalSection
              GlobalSection(ExtensibilityGlobals) = postSolution
            	  SolutionGuid = {{Guid.NewGuid().ToString().ToUpper()}}
              EndGlobalSection
            EndGlobal
            """);

        File.WriteAllText(resultPath, sb.ToString());
      }
      catch (Exception ex) { Console.WriteLine(ex.Message); }
    }


    public string FormatCode(string csCode) {
      var tree = CSharpSyntaxTree.ParseText(csCode);
      var root = tree.GetRoot();
      //root = root.NormalizeWhitespace("  ", false);

      var options = workspace.Options;
      var froot = Formatter.Format(root, workspace, options);

      return froot.ToFullString();
    }    

    #endregion code generation
  }
}
