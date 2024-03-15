using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPDouble : MPDataType
    {
        public override int Match(string expression, object previousToken, out object convertedToken)
        {
            var str = "";
            if (IsUnary(previousToken))
                str = "[\\+\\-]?";
            var match = Regex.Match(expression, "^(?<mantissa>" + str + "\\d+(\\.\\d+)?)([eE](?<exponent>[\\-\\+]?\\d+))?(?![\\w\\.])");
            if (match.Success)
            {
                try
                {
                    if (match.Groups["exponent"].Success)
                    {
                        convertedToken = double.Parse(match.Groups["mantissa"].ToString() + "E" + match.Groups["exponent"], NumberStyles.Float, CultureInfo.InvariantCulture);
                        return match.Length;
                    }
                    convertedToken = double.Parse(match.Groups["mantissa"].Value, CultureInfo.InvariantCulture);
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