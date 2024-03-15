using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPBoolean : MPDataType
    {
        public override int Match(string expression, object previousToken, out object convertedToken)
        {
            if (Regex.IsMatch(expression, "^[tT]rue(?!\\w)"))
            {
                convertedToken = true;
                return 4;
            }
            if (Regex.IsMatch(expression, "^[fF]alse(?!\\w)"))
            {
                convertedToken = false;
                return 5;
            }
            convertedToken = null;
            return -1;
        }
    }
}