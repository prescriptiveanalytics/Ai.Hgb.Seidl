using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidl.Processor {
  public class Utils {
    public static Type GetType(string typeString) {
      if (typeString == "string") return Type.GetType("System.String");
      if (typeString == "bool") return Type.GetType("System.Boolean");
      if (typeString == "int") return Type.GetType("System.Int32");
      if (typeString == "float") return Type.GetType("System.Double");      
      return null;
    }
  }
}
