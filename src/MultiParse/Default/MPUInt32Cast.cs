using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPUInt32Cast : MPOperator
    {
        public MPUInt32Cast()
          : base("(uint)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(uint)"))
                return "(uint)".Length;
            return expression.StartsWith("(UInt32)") ? "(UInt32)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            var a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((uint)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((uint)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((uint)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((uint)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((uint)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((uint)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((uint)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((uint)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((uint)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((uint)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((uint)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(UInt32)", a);
            }
        }
    }
}