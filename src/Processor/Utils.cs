using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidl.Processor {
  public class Utils {

    public static IType CreateAtomicType(string typeString, string valueString = null) {
      IType type = null;
      bool initialize = valueString != null;

      switch(typeString) {
        case "string":
          type = new String(initialize, valueString);
          break;
        case "int":
          type = new Integer(initialize, valueString);
          break;
        case "float":
          type = new Float(initialize, valueString);
          break;
        case "bool":
          type = new Bool(initialize, valueString);
          break;
        default: throw new ArgumentException("The given type is unknown.");
      }            
      return type; // search for symbol
    }

    public static IType CreateAtomicType(string typeString, SidlParser.ExpressionContext? exp) {
      IType type = null;
      bool initialize = !exp.IsEmpty;
      int no = exp.getAltNumber();
      if (no == SidlLexer.NULL) Console.WriteLine("NULL!!!");

      switch (typeString) {
        case "string":          
          type = new String(initialize, exp.GetText());
          break;
        case "int":          
          type = new Integer(initialize, exp.number().INTEGER().GetText());
          break;
        case "float":
          type = new Float(initialize, exp.number().FLOATINGPOINTNUMBER().GetText());
          break;
        case "bool":
          type = new Bool(initialize, exp.boolean().GetText());
          break;
        default: throw new ArgumentException("The given type is unknown.");
      }
      return type; // search for symbol
    }
  }
}
