﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ai.Hgb.Seidl.Data {
  public static class StringExtensions {
    public static string FirstCharToUpper(this string input) =>
        input switch
        {
          null => throw new ArgumentNullException(nameof(input)),
          "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
          _ => input[0].ToString().ToUpper() + input.Substring(1)
        };
  }
}
