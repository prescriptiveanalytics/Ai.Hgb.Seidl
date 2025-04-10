using Ai.Hgb.Common.Entities;
using Ai.Hgb.Seidl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai.Hgb.Seidl.Processor {
  public class Generator {

    private CancellationTokenSource cts;

    public Generator() {
      cts = new CancellationTokenSource();
    }

    public void GenerateSolution(ScopedSymbolTable sst, string resultPath) {
      if(!Directory.Exists(resultPath)) Directory.CreateDirectory(resultPath);


    }

    #region code generation

    private Task GenerateStubs(string path, string resultPath) {
      return Task.Run(async () => {
        try {
          string runId = Guid.NewGuid().ToString();
          string text = File.ReadAllText(path);
          string fileName = Path.GetFileNameWithoutExtension(path);
          var pr = new ProgramRecord(text);

          string name = fileName;
          string scope = "Sample";

          var sb = new StringBuilder();

          RoutingTable rt = null;
          List<InitializationRecord> inits = null;          

          sb.AppendLine(
            $$"""
            using System.Text.Json;
            using System.Text.Json.Serialization;
            using Ai.Hgb.Common.Entities;
            using Ai.Hgb.Dat.Communication;
            using Ai.Hgb.Dat.Configuration;
            
            namespace Ai.Hgb.Application.{{scope}}.{{name}} {
              
              public class Parameters : IApplicationParametersBase, IApplicationParametersNetworking {
                [JsonPropertyName("name")]
                public string Name { get; set; }

                [JsonPropertyName("description")]
                public string Description { get; set; }

                [JsonPropertyName("applicationParametersBase")]
                public ApplicationParametersBase ApplicationParametersBase { get; set; }

                [JsonPropertyName("applicationParametersNetworking")]
                public ApplicationParametersNetworking ApplicationParametersNetworking { get; set; }
              }

              public class Program {
                public static void Main(string[] args) {
                  Console.WriteLine("{{scope}}.{{name}}\n");
                  var parameters = JsonSerializer.Deserialize<Parameters>(args[0]);
                  var routingTable = JsonSerializer.Deserialize<RoutingTable>(args[1]);

                  // setup socket and converter
                  var address = new HostAddress(parameters.ApplicationParametersNetworking.HostName, parameters.ApplicationParametersNetworking.HostPort);
                  var converter = new JsonPayloadConverter();
                  var cts = new CancellationTokenSource();
                  ISocket socket = null;

                  try {
                    socket = new MqttSocket(parameters.Name, parameters.Name, address, converter, connect: true);
            """);


          foreach (var init in inits) {
            foreach (var route in rt.Routes.Where(x => x.Sink.Id == init.name)) {
              sb.AppendLine($"socket.Subscribe<>({route.SinkPort.Address}, ProcessPayload, cts.Token);");
            }
            foreach (var route in rt.Routes.Where(x => x.Source.Id == init.name)) {
              sb.AppendLine($"socket.Publish({route.SourcePort.Address}, new Payload(...));");
            }
          }

          sb.AppendLine(
            $$"""              
                  } catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                  } finally {
                    socket.Disconnect();
                  }
                }
              }
            }            
            """);

          File.WriteAllText(resultPath, sb.ToString());

        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
      }, cts.Token);
    }

    private Task GenerateProjectFile(string sourcePath, string resultPath, string scope, string name) {
      return Task.Run(async () => {
        try {
          var sb = new StringBuilder();

          sb.AppendLine(
            $$"""
              <Project Sdk="Microsoft.NET.Sdk">

              <PropertyGroup>
                <OutputType>Exe</OutputType>
                <TargetFramework>net9.0</TargetFramework>
                <ImplicitUsings>enable</ImplicitUsings>
                <Nullable>enable</Nullable>
                <AssemblyName>Ai.Hgb.Application.{{scope}}.$(MSBuildProjectName)</AssemblyName>
                <RootNamespace>Ai.Hgb.Application.{{scope}}.$(MSBuildProjectName.Replace(" ", "_"))</RootNamespace>
              </PropertyGroup>

            	<ItemGroup>
            	  <PackageReference Include="Ai.Hgb.Common.Entities" Version="0.1.13-prerelease-gb162266326" />
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
      }, cts.Token);
    }

    private Task GenerateDockerFile(string sourcePath, string resultPath, string scope, string name) {
      return Task.Run(async () => {
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
              COPY {{name}}/configurations /{{name}}/out/configurations

              # Build runtime image
              FROM mcr.microsoft.com/dotnet/aspnet:9.0
              WORKDIR /{{name}}
              COPY --from=build-env /{{name}}/out .
              ENTRYPOINT ["dotnet", "Ai.Hgb.Application.{{scope}}.{{name}}.dll"]
            </Project>
            
            """);

          File.WriteAllText(resultPath, sb.ToString());
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
      }, cts.Token);
    }

    private Task GenerateCommonProject(string resultPath, string scope, string name) {
      return Task.Run(async () => {
        try {

          // Data.cs
          var sb = new StringBuilder();

          sb.AppendLine(
          $$"""
            namespace Ai.Hgb.Application.{{scope}}.Common {
            public struct Message {
              public string Id { get; set; }
              public string Text { get; set; }
              public double Value { get; set; }

              public Document(string id, string text, double value) {
                Id = id;
                Author = author;
                Value = value;
              }

              public override string ToString() {
                return $"Id: {Id}\tText: {Text}\tValue: {Value}";
              }
            }
          }          
          """);
          File.WriteAllText(resultPath, sb.ToString());
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
      }, cts.Token);
    }


    record ProjectInfo(string pguid, string name, string path, string tguid);
    private Task GenerateSolutionFile(string resultPath, string name, List<ProjectInfo> projects) {
      return Task.Run(async () => {
        try {
          var sb = new StringBuilder();

          sb.AppendLine(
            $$"""
              Microsoft Visual Studio Solution File, Format Version 12.00
              # Visual Studio Version 17
              VisualStudioVersion = 17.4.33205.214
              MinimumVisualStudioVersion = 10.0.40219.1
            """);

          // Lib: 9A19103F-16F7-4668-BE54-9A1E7A4F7556
          // App: FAE04EC0-301F-11D3-BF4B-00C04F79EFBC
          foreach (var project in projects) {
            sb.AppendLine(
              $$"""
                Project("{{{project.tguid}}}") = "{{project.name}}", "{{project.path}}", "{{{project.pguid}}}"
              """);
          }

          sb.AppendLine(
            $$"""
              Global
                GlobalSection(SolutionConfigurationPlatforms) = preSolution
            	    Debug|Any CPU = Debug|Any CPU
            	    Release|Any CPU = Release|Any CPU
                EndGlobalSection
                GlobalSection(SolutionProperties) = preSolution
            	    HideSolutionNode = FALSE
                EndGlobalSection
              EndGlobal
            """);

          File.WriteAllText(resultPath, sb.ToString());
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
      }, cts.Token);
    }


    #endregion code generation
  }
}
