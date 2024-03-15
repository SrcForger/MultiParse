using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPSingle : MPDataType
    {
        public override int Match(string expression, object previousToken, out object convertedToken)
        {
            string str = "";
            if (IsUnary(previousToken))
                str = "[\\+\\-]?";
            Match match = Regex.Match(expression, "^(?<mantissa>" + str + "\\d+(\\.\\d+)?)([eE](?<exponent>[\\-\\+]?\\d+))?[fF]?(?![\\w\\.])");
            if (match.Success)
            {
                try
                {
                    if (match.Groups["exponent"].Success)
                    {
                        convertedToken = float.Parse(match.Groups["mantissa"].ToString() + "E" + match.Groups["exponent"], NumberStyles.Float, CultureInfo.InvariantCulture);
                        return match.Length;
                    }
                    convertedToken = float.Parse(match.Groups["mantissa"].Value, CultureInfo.InvariantCulture);
                    return match.Length;
                }
                catch (Exception ex)
                {
                    convertedToken = null;
                    return -1;
                }
            }
            else
            {
                convertedToken = null;
                return -1;
            }
        }
    }
}