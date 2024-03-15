using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPDoubleCast : MPOperator
    {
        public MPDoubleCast()
          : base("(double)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(double)"))
                return "(double)".Length;
            return expression.StartsWith("(Double)") ? "(Double)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            var a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((double)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((double)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((double)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((double)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((double)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((double)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((double)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((double)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((double)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((double)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((double)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(Double)", a);
            }
        }
    }
}