using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPSByteCast : MPOperator
    {
        public MPSByteCast()
          : base("(sbyte)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(sbyte)"))
                return "(sbyte)".Length;
            return expression.StartsWith("(SByte)") ? "(SByte)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            object a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((sbyte)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((sbyte)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((sbyte)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((sbyte)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((sbyte)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((sbyte)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((sbyte)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((sbyte)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((sbyte)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((sbyte)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((sbyte)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(SByte)", a);
            }
        }
    }
}