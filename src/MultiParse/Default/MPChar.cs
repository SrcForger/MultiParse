using System;
using System.Globalization;
using System.Text;

namespace MultiParse.Default
{
    public class MPChar : MPDataType
    {
        public override int Match(string expression, object previousToken, out object converted)
        {
            if (expression.Length < 3)
            {
                converted = null;
                return -1;
            }
            if (expression[0] != '\'')
            {
                converted = null;
                return -1;
            }
            if (expression[1] == '\\')
            {
                var i = 2;
                switch (expression[2])
                {
                    case '"':
                        converted = '"';
                        break;
                    case '\'':
                        converted = '\\';
                        break;
                    case '0':
                        converted = char.MinValue;
                        break;
                    case '\\':
                        converted = '\\';
                        break;
                    case 'a':
                        converted = '\a';
                        break;
                    case 'b':
                        converted = '\b';
                        break;
                    case 'f':
                        converted = '\f';
                        break;
                    case 'n':
                        converted = '\n';
                        break;
                    case 'r':
                        converted = '\r';
                        break;
                    case 't':
                        converted = '\t';
                        break;
                    case 'u':
                        converted = ReadUTF16(expression, ref i);
                        break;
                    case 'v':
                        converted = '\v';
                        break;
                    case 'x':
                        converted = ReadUTF16Var(expression, ref i);
                        break;
                    default:
                        converted = null;
                        return -1;
                }
                var index = i + 1;
                if (index >= expression.Length)
                    throw new ParseException("Quote mismatch, missing a '\"'");
                if (expression[index] == '\'')
                    return index + 1;
                converted = null;
                return -1;
            }
            converted = expression[1];
            if (expression[2] == '\'')
                return 3;
            converted = null;
            return -1;
        }

        private char ReadUTF16(string expression, ref int i)
        {
            var stringBuilder = new StringBuilder();
            for (var index = 0; index < 4; ++index)
            {
                ++i;
                if (i == expression.Length)
                    throw new ParseException("Quote mismatch, missing a '\"'");
                stringBuilder.Append(expression[i]);
            }
            return (char)int.Parse(stringBuilder.ToString(), NumberStyles.HexNumber);
        }

        private char ReadUTF16Var(string expression, ref int i)
        {
            var stringBuilder = new StringBuilder();
            for (var index = 0; index < 4; ++index)
            {
                ++i;
                if (i == expression.Length)
                    throw new ParseException("Quote mismatch, missing a '\"'");
                var ch = expression[i];
                if (ch >= 'A' && ch <= 'F' || ch >= 'a' && ch <= 'f' || ch >= '0' && ch <= '9')
                {
                    stringBuilder.Append(ch);
                }
                else
                {
                    if (index == 0)
                        throw new ParseException("Unrecognized escape sequence '\\x" + ch + "' for " + expression);
                    --i;
                    break;
                }
            }
            try
            {
                return (char)int.Parse(stringBuilder.ToString(), NumberStyles.HexNumber);
            }
            catch (Exception ex)
            {
                throw new ParseException("Unrecognized escape sequence '\\x" + stringBuilder + "' for " + expression);
            }
        }
    }
}