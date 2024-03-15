using System;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPUInt64 : MPDataType
    {
        public override int Match(string expression, object previousToken, out object converted)
        {
            var str = "^";
            if (IsUnary(previousToken))
                str = "^\\+?";
            var match = Regex.Match(expression, "^(?<value>" + str + "\\d+)([uU][lL]|[lL][uU])?(?![\\w\\.])");
            if (match.Success)
            {
                try
                {
                    converted = ulong.Parse(match.Groups["value"].Value);
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