using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPCharCast : MPOperator
    {
        public MPCharCast()
          : base("(char)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(char)"))
                return "(char)".Length;
            return expression.StartsWith("(Char)") ? "(Char)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            var a = PopOrGet(output);
            switch (Type.GetTypeCode(a.GetType()))
            {
                case TypeCode.Char:
                    output.Push((char)a);
                    break;
                case TypeCode.SByte:
                    output.Push((char)(sbyte)a);
                    break;
                case TypeCode.Byte:
                    output.Push((char)(byte)a);
                    break;
                case TypeCode.Int16:
                    output.Push((char)(short)a);
                    break;
                case TypeCode.UInt16:
                    output.Push((char)(ushort)a);
                    break;
                case TypeCode.Int32:
                    output.Push((char)(int)a);
                    break;
                case TypeCode.UInt32:
                    output.Push((char)(uint)a);
                    break;
                case TypeCode.Int64:
                    output.Push((char)(long)a);
                    break;
                case TypeCode.UInt64:
                    output.Push((char)(ulong)a);
                    break;
                case TypeCode.Single:
                    output.Push((char)(float)a);
                    break;
                case TypeCode.Double:
                    output.Push((char)(double)a);
                    break;
                case TypeCode.Decimal:
                    output.Push((char)(decimal)a);
                    break;
                default:
                    throw new InvalidOperatorTypesException("(Char)", a);
            }
        }
    }
}