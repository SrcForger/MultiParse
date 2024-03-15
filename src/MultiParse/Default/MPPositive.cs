using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPPositive : MPOperator
    {
        public MPPositive()
          : base("+", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return !IsUnary(previousToken) || !Regex.IsMatch(expression, "^\\+(?![\\+\\=])") ? -1 : 1;
        }

        public override void Execute(Stack<object> output)
        {
            var operand = PopOrGet(output);
            Positive(output, operand);
        }

        public void Positive(Stack<object> output, object operand)
        {
            switch (Type.GetTypeCode(operand.GetType()))
            {
                case TypeCode.Char:
                    output.Push((int)(char)operand);
                    break;
                case TypeCode.SByte:
                    output.Push((int)(sbyte)operand);
                    break;
                case TypeCode.Byte:
                    output.Push((int)(byte)operand);
                    break;
                case TypeCode.Int16:
                    output.Push((int)(short)operand);
                    break;
                case TypeCode.UInt16:
                    output.Push((int)(ushort)operand);
                    break;
                case TypeCode.Int32:
                    output.Push((int)operand);
                    break;
                case TypeCode.UInt32:
                    output.Push((uint)operand);
                    break;
                case TypeCode.Int64:
                    output.Push((long)operand);
                    break;
                case TypeCode.UInt64:
                    output.Push((ulong)operand);
                    break;
                case TypeCode.Single:
                    output.Push((float)operand);
                    break;
                case TypeCode.Double:
                    output.Push((double)operand);
                    break;
                case TypeCode.Decimal:
                    output.Push((decimal)operand);
                    break;
                default:
                    throw new InvalidOperatorTypesException("+", operand);
            }
        }
    }
}