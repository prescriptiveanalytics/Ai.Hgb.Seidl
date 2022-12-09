using Antlr4.Runtime.Misc;
using Sidl.Data;
using Sidl.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidl.Processor {
  public class Utils {

    #region atomic type checks / helper
    public static bool IsAtomicType(int typeCode) {
      return typeCode.IsOneOf(SidlLexer.STRING, SidlLexer.INT, SidlLexer.FLOAT, SidlLexer.BOOL);
    }

    private static bool CheckAtomicTypeValue(int typeCode, int valueCode) => typeCode switch {
      SidlLexer.STRING  => valueCode == SidlLexer.STRINGLITEARL,
      SidlLexer.INT     => valueCode == SidlLexer.INTEGER,
      SidlLexer.FLOAT   => valueCode == SidlLexer.FLOATINGPOINTNUMBER,
      SidlLexer.BOOL    => valueCode == SidlLexer.TRUE || valueCode == SidlLexer.FALSE,
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static string GetAtomicTypeValueText(int typeCode, SidlParser.ExpressionContext? exp) => typeCode switch {
      SidlLexer.STRING => exp.GetText(),
      SidlLexer.INT => exp.number().INTEGER().GetText(),
      SidlLexer.FLOAT => exp.number().FLOATINGPOINTNUMBER().GetText(),
      SidlLexer.BOOL => exp.boolean().GetText(),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static IAtomicType InstanceAtomicType(int typeCode, SidlParser.ExpressionContext? exp) => typeCode switch {
      SidlLexer.STRING => new Data.String(exp.GetText()),
      SidlLexer.INT => new Data.Integer(exp.number().INTEGER().GetText()),
      SidlLexer.FLOAT => new Data.Float(exp.number().FLOATINGPOINTNUMBER().GetText()),
      SidlLexer.BOOL => new Data.Bool(exp.boolean().GetText()),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static IAtomicType InstanceAtomicType(int typeCode, string valueText = null) => typeCode switch {
      SidlLexer.STRING => new Data.String(valueText),
      SidlLexer.INT => new Data.Integer(valueText),
      SidlLexer.FLOAT => new Data.Float(valueText),
      SidlLexer.BOOL => new Data.Bool(valueText),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static IAtomicType DeclareAtomicType(int typeCode) => typeCode switch {
      SidlLexer.STRING => new Data.String(),
      SidlLexer.INT => new Data.Integer(),
      SidlLexer.FLOAT => new Data.Float(),
      SidlLexer.BOOL => new Data.Bool(),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    #endregion atomic type checks / helper

    public static IAtomicType CreateAtomicType(int typeCode, SidlParser.ExpressionContext? exp) {
      IAtomicType type;
      bool initialize = exp != null && !exp.IsEmpty;

      if (initialize) {
        int valueCode = initialize ? exp.Start.Type : -1;        
        if (CheckAtomicTypeValue(typeCode, valueCode)) type = InstanceAtomicType(typeCode, exp);
        else throw new ArgumentException($"The stated expression ({SidlLexer.DefaultVocabulary.GetDisplayName(valueCode)}) does not match the specified type ({SidlLexer.DefaultVocabulary.GetDisplayName(typeCode)}).");
      } else {
        type = DeclareAtomicType(typeCode);
      }

      return type;
    }

    public static IType CreateType(int? typecode, string? typename, ScopedSymbolTable scopedSymbolTable, Scope currentScope, SidlParser.ExpressionContext? expression = null) {
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
