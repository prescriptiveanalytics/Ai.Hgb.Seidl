/*
 * SIDL LSP API
 * 
 * Description: This server provides access to the scoped symbol store
 * 
 */
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
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

      app.UsePathBase("/sidl/lsp/");
      MapRoutes(app);

      app.Run();
    }

    private static void MapRoutes(WebApplication app) {      

      app.MapGet("/", () => "Sidl LSP API");

      app.MapGet("/keywords", async () => {
        var keywords = "[\"string\", \"int\", \"float\", \"bool\", \"struct\", \"node\"]";
        return Results.Ok(keywords);
      });

    }
  }
}