using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPDecimalCast : MPOperator
    {
        public MPDecimalCast()
          : base("(decimal)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(decimal)"))
                return "(decimal)".Length;
            return expression.StartsWith("(Decimal)") ? "(Decimal)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            object a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((decimal)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((decimal)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((decimal)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((decimal)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((decimal)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((decimal)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((decimal)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((decimal)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((decimal)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((decimal)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((decimal)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(Decimal)", a);
            }
        }
    }
}