using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Utility
{
    public static class TextHelper
    {
        public static string CapitalizeFirstLetter(this string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Input cannot be null or empty.", nameof(value));

            var firstChar = char.ToUpper(value[0]);
            var remaining = value.Length > 1 ? value.Substring(1) : string.Empty;

            return $"{firstChar}{remaining}";
        }
    }
}
