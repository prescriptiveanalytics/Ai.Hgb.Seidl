using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Diagnostics;
using System.Text;

namespace Sidl.Processor // Note: actual namespace depends on the project name.
{
  internal class Program {
    public static string demoTextFilePath = @"../../../../Samples/Lmd.3l";
    //public static string demoTextFilePath = @"../../../../Samples/resinet_democombined.3l";
    //public static string demoTextFilePath = @"../../../../Samples/resinet_instantiations.3l";    

    static void Main(string[] args) {
      TestRun();
      //new RuntimeTests().Run();
    }


    public static void TestRun() {
      string fp = Path.GetFullPath(demoTextFilePath);

      Console.WriteLine("DSL Processor Demo\n");
      Console.WriteLine(" - Reading file...");
      string programText = Utils.ReadFile(fp);

      Console.WriteLine(" - Parsing program...");
      SidlParser parser = Utils.TokenizeAndParse(programText);


      Console.WriteLine(" - Analyzing program...");
      Linter linter = new Linter(parser);
      linter.ProgramTextUrl = fp;

      var table = linter.CreateScopedSymbolTableSecured();

      //var scopesX = table.Scopes;
      //Console.WriteLine(System.String.Join(' ', scopesX));

      Console.WriteLine("\n\n");

      var text = table.Print(null);
      Console.WriteLine(text.ToString());

      Console.WriteLine("\n\n\nEnd of processing.");
    }



    // TODO:
    // ========================================================    
    // type / assignment checks
    // graph - node - edge mappings (messages)
    // further on:
    // - 1. mock a node-rep with a txt
    // - 2. add interpreter check for existing node inside rep
    // -- 2.1 check versions, message/input-outputs


    // Interpreter Result: (REST)-API to access internally generated data structure


    // Ressources:
    // https://www.youtube.com/watch?v=bfiAvWZWnDA


  }
}