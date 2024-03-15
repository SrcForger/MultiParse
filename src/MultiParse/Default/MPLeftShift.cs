using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPLeftShift : MPOperator
    {
        public MPLeftShift()
          : base("<<", PrecedenceShift, true)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return IsUnary(previousToken) || !expression.StartsWith("<<") ? -1 : 2;
        }

        public override void Execute(Stack<object> output)
        {
            var right = PopOrGet(output);
            var left = PopOrGet(output);
            LeftShift(output, left, right);
        }

        public void LeftShift(Stack<object> output, object left, object right)
        {
            int result;
            if (!CastImplicit(right, out result))
                throw new InvalidOperatorTypesException("<<", left, right);
            switch (Type.GetTypeCode(left.GetType()))
            {
                case TypeCode.Char:
                    output.Push((char)left << result);
                    break;
                case TypeCode.SByte:
                    output.Push((sbyte)left << result);
                    break;
                case TypeCode.Byte:
                    output.Push((byte)left << result);
                    break;
                case TypeCode.Int16:
                    output.Push((short)left << result);
                    break;
                case TypeCode.UInt16:
                    output.Push((ushort)left << result);
                    break;
                case TypeCode.Int32:
                    output.Push((int)left << result);
                    break;
                case TypeCode.UInt32:
                    output.Push((uint)((int)(uint)left << result));
                    break;
                case TypeCode.Int64:
                    output.Push((long)left << result);
                    break;
                case TypeCode.UInt64:
                    output.Push((ulong)((long)(ulong)left << result));
                    break;
                default:
                    throw new InvalidOperatorTypesException("<<", left, right);
            }
        }
    }
}