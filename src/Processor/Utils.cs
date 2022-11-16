using Antlr4.Runtime.Misc;
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
      SidlLexer.STRING => new String(exp.GetText()),
      SidlLexer.INT => new Integer(exp.number().INTEGER().GetText()),
      SidlLexer.FLOAT => new Float(exp.number().FLOATINGPOINTNUMBER().GetText()),
      SidlLexer.BOOL => new Bool(exp.boolean().GetText()),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static IAtomicType InstanceAtomicType(int typeCode, string valueText = null) => typeCode switch {
      SidlLexer.STRING => new String(valueText),
      SidlLexer.INT => new Integer(valueText),
      SidlLexer.FLOAT => new Float(valueText),
      SidlLexer.BOOL => new Bool(valueText),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    private static IAtomicType DeclareAtomicType(int typeCode) => typeCode switch {
      SidlLexer.STRING => new String(),
      SidlLexer.INT => new Integer(),
      SidlLexer.FLOAT => new Float(),
      SidlLexer.BOOL => new Bool(),
      _ => throw new ArgumentException("The given type is unknown.")
    };

    #endregion atomic type checks / helper

    public static IBaseType CreateAtomicType(int typeCode, SidlParser.ExpressionContext? exp) {
      IBaseType type;
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


  }
}
