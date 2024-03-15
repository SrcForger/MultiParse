using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPInt32Cast : MPOperator
    {
        public MPInt32Cast()
          : base("(int)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(int)"))
                return "(int)".Length;
            return expression.StartsWith("(Int32)") ? "(Int32)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            object a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((int)(char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((int)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((int)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((int)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((int)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((int)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((int)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((int)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((int)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((int)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((int)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(Int32)", a);
            }
        }
    }
}