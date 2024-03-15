using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPUInt64Cast : MPOperator
    {
        public MPUInt64Cast()
          : base("(ulong)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(ulong)"))
                return "(ulong)".Length;
            return expression.StartsWith("(UInt64)") ? "(UInt64)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            var a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((ulong)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((ulong)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((ulong)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((ulong)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((ulong)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((ulong)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((ulong)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((ulong)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((ulong)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((ulong)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((ulong)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(UInt64)", a);
            }
        }
    }
}