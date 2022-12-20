/*
 * SIDL LSP API
 * 
 * Description: This server provides access to: parsing/linting functionality, node repository,...
 * 
 */
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Sidl.Data;
using Sidl.Processor;
using System;

namespace Sidl.Server {
  public class Program {
    public static void Main(string[] args) {

      // setup web api
      var builder = WebApplication.CreateBuilder(args);

      // setup logger
      var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
      builder.Logging.ClearProviders();
      builder.Logging.AddSerilog();
      builder.Logging.AddConsole();

      // add swagger support (automatic api description)
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();
      app.UseSwagger();
      app.UseSwaggerUI();
      app.UseHttpsRedirection();

      app.UsePathBase("/sidl/lsp");
      app.UseRouting();
      MapRoutes(app);

      app.Run();
    }

    private static void MapRoutes(WebApplication app) {

      //SidlParser parser = Processor.Utils.TokenizeAndParse("");
      //parser.

      app.MapGet("/", (HttpContext ctx, LinkGenerator link) => "Sidl LSP API");


      app.MapGet("/atomictypes", async () => {
        return Results.Ok(Processor.Utils.GetAtomicTypeDisplayNames().OrderBy(x => x));
      });

      app.MapGet("/basetypes", async () => {
        return Results.Ok(Processor.Utils.GetBaseTypeDisplayNames().OrderBy(x => x));
      });

      app.MapGet("/keywords", async () => {
        return Results.Ok(Processor.Utils.GetKeywordDisplayNames().OrderBy(x => x));
      });

      app.MapPost("/validate", async (ProgramRecord req) => {
        try {
          var sst = ParseSST(req.programText);
          return Results.Ok("ok");
        } catch(Exception exc) {
          return Results.Problem(exc.Message);
        }
      });


      app.MapPost("/nodetypes", async (NodetypesRequest req) => {        
        //Console.WriteLine($"Request: {req.line} / {req.character}");          
        var sst = ParseSST(req.programText);        
        var s = sst.GetScope(req.line, req.character);
        sst.Print(s);
        //Console.WriteLine($"Scope name: {s.Name}");
        var symbols = sst[s].Where(x => x.Type is Node && x.IsTypedef).Select(x => x.Name);
        //Console.WriteLine(string.Join(", ", symbols));
        //Console.WriteLine($"sending {symbols.Count()} nodetypes...");
        return Results.Ok(symbols);

      });

      app.MapPost("/visualization/graph", async (ProgramRecord pr) => {
        try {
          var sst = ParseSST(pr.programText);
          var gr = sst.GetGraph();
          return Results.Ok(gr);
          
        }
        catch (Exception exc) {
          return Results.Problem(exc.Message);
        }
      });

    } 
    
    private static ScopedSymbolTable ParseSST(string programText) {
      SidlParser parser = Processor.Utils.TokenizeAndParse(programText);
      Linter linter = new Linter(parser);
      return linter.CreateScopedSymbolTable();
    }
  }
}