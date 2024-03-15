using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPByteCast : MPOperator
    {
        public MPByteCast()
          : base("(byte)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(byte)"))
                return "(byte)".Length;
            return expression.StartsWith("(Byte)") ? "(Byte)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            object a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((byte)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((byte)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((byte)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((byte)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((byte)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((byte)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((byte)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((byte)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((byte)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((byte)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((byte)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(Byte)", a);
            }
        }
    }
}