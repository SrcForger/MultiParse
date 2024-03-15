using System;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPSByte : MPDataType
    {
        public override int Match(string expression, object previousToken, out object converted)
        {
            string str = "^";
            if (IsUnary(previousToken))
                str = "^[\\+\\-]?";
            Match match = Regex.Match(expression, str + "\\d+(?![\\w\\.])");
            if (match.Success)
            {
                try
                {
                    converted = sbyte.Parse(match.Value);
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