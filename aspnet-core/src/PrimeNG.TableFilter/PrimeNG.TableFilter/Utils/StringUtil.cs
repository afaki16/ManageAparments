﻿using System;
using System.Linq;

namespace PrimeNG.TableFilter.Utils
{
    public static class StringUtil
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpperInvariant() + input.Substring(1);
            }
        }
    }
}
