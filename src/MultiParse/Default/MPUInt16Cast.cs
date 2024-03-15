using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPUInt16Cast : MPOperator
    {
        public MPUInt16Cast()
          : base("(ushort)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(ushort)"))
                return "(ushort)".Length;
            return expression.StartsWith("(UInt16)") ? "(UInt16)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            object a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((ushort)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((ushort)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((ushort)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((ushort)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((ushort)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((ushort)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((ushort)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((ushort)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((ushort)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((ushort)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((ushort)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(UInt16)", a);
            }
        }
    }
}