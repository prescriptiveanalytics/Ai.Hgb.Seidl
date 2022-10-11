using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Text;

namespace Sidl.Processor // Note: actual namespace depends on the project name.
{
  internal class Program {
    public static string demoTextFilePath = @"../../../../Samples/resinetShort.3l";

    static void Main(string[] args) {

      Console.WriteLine("DSL Processor Demo\n");
      Console.WriteLine(" - Reading file...");
      string programText = ReadFile(demoTextFilePath);

      Console.WriteLine(" - Parsing program...");
      SidlParser parser = TokenizeAndParse(programText);


      Console.WriteLine(" - Analyzing program...");
      Linter linter = new Linter(parser);
      //linter.AnalyzeScopeSymbolDeclarations();      
      var table = linter.CreateScopedSymbolTable();
      var text = table.Print(null);
      Console.WriteLine(text.ToString());

      Console.WriteLine("\n\n\nEnd of processing.");
    }
    
    public static string ReadFile(string filePath) {
      if (!File.Exists(demoTextFilePath)) throw new FileNotFoundException($"Warning: File could not be found.");      
      StringBuilder text = new StringBuilder();
      using (var sr = new StreamReader(demoTextFilePath)) {        
        string input = "";        
        while (!sr.EndOfStream) {
          text.AppendLine(sr.ReadLine());
        }
      }
      return text.ToString();
    }

    public static SidlParser TokenizeAndParse(string programText) {
      var inputStream = new AntlrInputStream(programText.ToString());
      SidlLexer lexer = new SidlLexer(inputStream);
      var commonTokenStream = new CommonTokenStream(lexer);
      return new SidlParser(commonTokenStream);
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