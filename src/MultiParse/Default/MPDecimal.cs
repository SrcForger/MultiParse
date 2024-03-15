using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPDecimal : MPDataType
    {
        public override int Match(string expression, object previousToken, out object converted)
        {
            var str = "^";
            if (IsUnary(previousToken))
                str = "^[\\+\\-]?";
            var match = Regex.Match(expression, str + "\\d+[mM]?(?![\\w\\.])");
            if (match.Success)
            {
                try
                {
                    converted = decimal.Parse(match.Value, CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    converted = null;
                    return -1;
                }
                return match.Length;
            }
            converted = null;
            return -1;
        }
    }
}