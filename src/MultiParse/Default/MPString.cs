using System;
using System.Globalization;
using System.Text;

namespace MultiParse.Default
{
    public class MPString : MPDataType
    {
        public override int Match(string expression, object previousToken, out object convertedToken)
        {
            if (expression.Length < 2 || expression[0] != '"')
            {
                convertedToken = null;
                return -1;
            }
            var stringBuilder = new StringBuilder();
            int i;
            for (i = 1; i <= expression.Length; ++i)
            {
                if (i == expression.Length)
                    throw new ParseException("Quote mismatch, missing a '\"'");
                var ch1 = expression[i];
                switch (ch1)
                {
                    case '"':
                        goto label_27;
                    case '\\':
                        ++i;
                        if (i == expression.Length)
                            throw new ParseException("Quote mismatch, missing a '\"'");
                        var ch2 = expression[i];
                        switch (ch2)
                        {
                            case '"':
                                stringBuilder.Append('"');
                                continue;
                            case '\'':
                                stringBuilder.Append('\'');
                                continue;
                            case '0':
                                stringBuilder.Append(char.MinValue);
                                continue;
                            case 'U':
                                stringBuilder.Append(ReadUnicodeSurrogatePair(expression, ref i));
                                continue;
                            case '\\':
                                stringBuilder.Append('\\');
                                continue;
                            case 'a':
                                stringBuilder.Append('\a');
                                continue;
                            case 'b':
                                stringBuilder.Append('\b');
                                continue;
                            case 'f':
                                stringBuilder.Append('\f');
                                continue;
                            case 'n':
                                stringBuilder.Append('\n');
                                continue;
                            case 'r':
                                stringBuilder.Append('\r');
                                continue;
                            case 't':
                                stringBuilder.Append('\t');
                                continue;
                            case 'u':
                                stringBuilder.Append(ReadUTF16(expression, ref i));
                                continue;
                            case 'v':
                                stringBuilder.Append('\v');
                                continue;
                            case 'x':
                                stringBuilder.Append(ReadUTF16Var(expression, ref i));
                                continue;
                            default:
                                throw new ParseException("Unrecognized escape character found for '\\" + ch2 + "' in " + expression);
                        }
                    default:
                        stringBuilder.Append(ch1);
                        break;
                }
            }
        label_27:
            var str = stringBuilder.ToString();
            convertedToken = str;
            return i + 1;
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

        private string ReadUnicodeSurrogatePair(string expression, ref int i)
        {
            var stringBuilder = new StringBuilder();
            for (var index = 0; index < 8; ++index)
            {
                ++i;
                if (i == expression.Length)
                    throw new ParseException("Quote mismatch, missing a '\"'");
                stringBuilder.Append(expression[i]);
            }
            try
            {
                return char.ConvertFromUtf32(int.Parse(stringBuilder.ToString(), NumberStyles.HexNumber));
            }
            catch (Exception ex)
            {
                throw new ParseException("Unrecognized escape sequence '\\U" + stringBuilder + " for " + expression);
            }
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