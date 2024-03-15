using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPSingleCast : MPOperator
    {
        public MPSingleCast()
          : base("(float)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(float)"))
                return "(float)".Length;
            return expression.StartsWith("(Single)") ? "(Single)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            object a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((float)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((float)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((float)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((float)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((float)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((float)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((float)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((float)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((float)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((float)a);
                    break;
                case TypeCode.Double:
                    output.Push((float)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((float)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(Single)", a);
            }
        }
    }
}