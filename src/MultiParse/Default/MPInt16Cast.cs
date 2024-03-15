using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPInt16Cast : MPOperator
    {
        public MPInt16Cast()
          : base("(short)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(short)"))
                return "(short)".Length;
            return expression.StartsWith("(Int16)") ? "(Int16)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            var a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((short)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((short)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((short)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((short)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((short)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((short)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((short)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((short)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((short)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((short)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((short)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(Int16)", a);
            }
        }
    }
}