using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPInt64Cast : MPOperator
    {
        public MPInt64Cast()
          : base("(long)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(long)"))
                return "(long)".Length;
            return expression.StartsWith("(Int64)") ? "(Int64)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            var a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((long)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((long)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((long)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((long)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((long)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((long)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((long)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((long)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((long)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((long)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((long)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(Int64)", a);
            }
        }
    }
}