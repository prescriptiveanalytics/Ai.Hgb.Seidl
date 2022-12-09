using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidl.Utils {
  public static class Extensions {
    public static bool IsOneOf<T>(this T @this, params T[] values) {
      return values.Contains(@this);
    }
  }
}
