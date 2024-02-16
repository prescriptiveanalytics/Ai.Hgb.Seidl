using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Ai.Hgb.Seidl.Data;
using Ai.Hgb.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ai.Hgb.Seidl.Processor {
  public class Utils {

    public static string ReadFile(string filePath) {
      if (!File.Exists(filePath)) throw new FileNotFoundException($"Warning: File could not be found.");
      StringBuilder text = new StringBuilder();
      using (var sr = new StreamReader(filePath)) {
        string input = "";
        while (!sr.EndOfStream) {
          text.AppendLine(sr.ReadLine());
        }
      }
      return text.ToString();
    }

    public static SeidlParser TokenizeAndParse(string programText) {
      var inputStream = new AntlrInputStream(programText.ToString());
      SeidlLexer lexer = new SeidlLexer(inputStream);
      var commonTokenStream = new CommonTokenStream(lexer);
      return new SeidlParser(commonTokenStream);
    }

    #region atomic type checks / helper
    public static bool IsAtomicType(int typeCode) {
      return typeCode.IsOneOf(SeidlLexer.STRING, SeidlLexer.INT, SeidlLexer.FLOAT, SeidlLexer.BOOL);
    }

    public static bool IsAtomicType(IType type) {
      //return type is IAtomicType;      
      return type is Data.String || type is Integer || type is Float || type is Bool;
    }

    public static IEnumerable<string> GetAtomicTypeDisplayNames() {
      var atomicTypeCodes = new List<int> { SeidlLexer.STRING, SeidlLexer.INT, SeidlLexer.FLOAT, SeidlLexer.BOOL };
      foreach (var tc in atomicTypeCodes) {
        yield return SeidlLexer.DefaultVocabulary.GetDisplayName(tc).Trim('\'');
      }
    }

    public static IEnumerable<string> GetBaseTypeDisplayNames() {
      var typeCodes = new List<int> { SeidlLexer.STRING, SeidlLexer.INT, SeidlLexer.FLOAT, SeidlLexer.BOOL,
        SeidlLexer.STRUCT, SeidlLexer.MESSAGE, SeidlLexer.NODETYPE, SeidlLexer.NODE };
      foreach (var tc in typeCodes) {
        yield return SeidlLexer.DefaultVocabulary.GetDisplayName(tc).Trim('\'');
      }
    }

    public static IEnumerable<string> GetKeywordDisplayNames() {
      var typeCodes = new List<int> { SeidlLexer.STRING, SeidlLexer.INT, SeidlLexer.FLOAT, SeidlLexer.BOOL,
        SeidlLexer.STRUCT, SeidlLexer.MESSAGE, SeidlLexer.NODETYPE, SeidlLexer.NODE,
        SeidlLexer.TYPEDEF, SeidlLexer.TOPIC, SeidlLexer.PROPERTY,
        SeidlLexer.IMPORT, SeidlLexer.PACKAGE
      };
      foreach (var tc in typeCodes) {
        yield return SeidlLexer.DefaultVocabulary.GetDisplayName(tc).Trim('\'');
      }
    }

    private static bool CheckAtomicTypeValue(int typeCode, int valueCode) => typeCode switch {
      SeidlLexer.STRING  => valueCode == SeidlLexer.STRINGLITERAL,
      SeidlLexer.INT     => valueCode == SeidlLexer.INTEGER,
      SeidlLexer.FLOAT   => valueCode == SeidlLexer.FLOATINGPOINTNUMBER,
      SeidlLexer.BOOL    => valueCode == SeidlLexer.TRUE || valueCode == SeidlLexer.FALSE,
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static string GetAtomicTypeValueText(int typeCode, SeidlParser.ExpressionContext? exp) => typeCode switch {
      SeidlLexer.STRING => exp.GetText(),
      SeidlLexer.INT => exp.number().INTEGER().GetText(),
      SeidlLexer.FLOAT => exp.number().FLOATINGPOINTNUMBER().GetText(),
      SeidlLexer.BOOL => exp.boolean().GetText(),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static IAtomicType InstanceAtomicType(int typeCode, SeidlParser.ExpressionContext? exp) => typeCode switch {
      SeidlLexer.STRING => new Data.String(exp.GetText()),
      SeidlLexer.INT => new Data.Integer(exp.number().INTEGER().GetText()),
      SeidlLexer.FLOAT => new Data.Float(exp.number().FLOATINGPOINTNUMBER().GetText()),
      SeidlLexer.BOOL => new Data.Bool(exp.boolean().GetText()),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static IAtomicType InstanceAtomicType(int typeCode, string valueText = null) => typeCode switch {
      SeidlLexer.STRING => new Data.String(valueText),
      SeidlLexer.INT => new Data.Integer(valueText),
      SeidlLexer.FLOAT => new Data.Float(valueText),
      SeidlLexer.BOOL => new Data.Bool(valueText),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static IAtomicType DeclareAtomicType(int typeCode) => typeCode switch {
      SeidlLexer.STRING => new Data.String(),
      SeidlLexer.INT => new Data.Integer(),
      SeidlLexer.FLOAT => new Data.Float(),
      SeidlLexer.BOOL => new Data.Bool(),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static int GetExpressionTypeCode(SeidlParser.ExpressionContext? exp) {
      int typeCode = int.MaxValue;

      if (exp.GetText() != null) typeCode = SeidlLexer.STRING;
      if (exp.number() != null && exp.number().INTEGER() != null) typeCode = SeidlLexer.INT;
      if (exp.number() != null && exp.number().FLOATINGPOINTNUMBER() != null) typeCode = SeidlLexer.FLOAT;
      if (exp.boolean() != null) typeCode = SeidlLexer.BOOL;

      return typeCode;
    }

    #endregion atomic type checks / helper

    public static IAtomicType CreateAtomicType(int typeCode, SeidlParser.ExpressionContext? exp) {
      IAtomicType type;
      bool initialize = exp != null && !exp.IsEmpty;

      if (initialize) {
        int valueCode = initialize ? exp.Start.Type : -1;        
        if (CheckAtomicTypeValue(typeCode, valueCode)) type = InstanceAtomicType(typeCode, exp);
        else throw new ArgumentException($"The stated expression ({SeidlLexer.DefaultVocabulary.GetDisplayName(valueCode)}) does not match the specified type ({SeidlLexer.DefaultVocabulary.GetDisplayName(typeCode)}).");
      } else {
        type = DeclareAtomicType(typeCode);
      }

      return type;
    }

    public static IType CreateType(int? typecode, string? typename, ScopedSymbolTable scopedSymbolTable, Scope currentScope, SeidlParser.ExpressionContext? expression = null) {
      IType type = null;
      if (typecode != null && typecode.HasValue) {
        if (Utils.IsAtomicType(typecode.Value)) type = Utils.CreateAtomicType(typecode.Value, expression);
        else throw new ArgumentException("The stated typecode is not a valid atomic type.");
      } else if (typename != null) {
        var symbol = scopedSymbolTable[currentScope, typename]; // search for symbol (i.e. struct or graph types)
        if (symbol == null) throw new ArgumentException("The stated typename is unknown.");
        else if (!symbol.IsTypedef) throw new ArgumentException("The stated typename is not a type.");
        else {
          type = symbol.ShallowCopy();

        }
      }
      return type;
    }

    public static void TryAssignExpression(IType target, SeidlParser.ExpressionContext? exp) {
      try {
        if (target is Data.String) (target as IAtomicType).Assign(exp.GetText());
        else if (target is Data.Integer) (target as IAtomicType).Assign(exp.number().INTEGER().GetText());
        else if (target is Data.Float) (target as IAtomicType).Assign(exp.number().FLOATINGPOINTNUMBER().GetText());
        else if (target is Data.Bool) (target as IAtomicType).Assign(exp.boolean().GetText());
      }
      catch { }
    }

    public static Message GetMessageType(string msgtypename, ScopedSymbolTable scopedSymbolTable, Scope currentScope) {
      var symbol = scopedSymbolTable[currentScope, msgtypename];
      if (symbol == null) throw new ArgumentException($"The specified message type {msgtypename} does not exist in this context.");
      else if (symbol.Type is not Message) throw new ArgumentException($"The specified type {msgtypename} is not a message.");
      return (Message)symbol.Type.ShallowCopy();
    }

    public static Node GetNodeType(string nodetypename, ScopedSymbolTable scopedSymbolTable, Scope currentScope) {
      var symbol = scopedSymbolTable[currentScope, nodetypename];
      if (symbol == null) throw new ArgumentException($"The specified node type {nodetypename} does not exist in this context.");
      else if (symbol.Type is not Node) throw new ArgumentException($"The specified type {nodetypename} is not a node type.");
      return (Node)symbol.Type.ShallowCopy();
    }

  }
}
