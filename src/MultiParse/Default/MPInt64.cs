using System;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPInt64 : MPDataType
    {
        public override int Match(string expression, object previousToken, out object converted)
        {
            var str = "";
            if (IsUnary(previousToken))
                str = "[\\+\\-]?";
            var match = Regex.Match(expression, "^(?<value>" + str + "\\d+)[lL]?(?![\\w\\.])");
            if (match.Success)
            {
                try
                {
                    converted = long.Parse(match.Groups["value"].Value);
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