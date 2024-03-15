﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPNegative : MPOperator
    {
        public MPNegative()
          : base("-", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return !IsUnary(previousToken) || !Regex.IsMatch(expression, "^-(?![-\\=])") ? -1 : 1;
        }

        public override void Execute(Stack<object> output)
        {
            object operand = PopOrGet(output);
            Negative(output, operand);
        }

        public void Negative(Stack<object> output, object operand)
        {
            switch (Type.GetTypeCode(operand.GetType()))
            {
                case TypeCode.Char:
                    output.Push(-(char)operand);
                    break;
                case TypeCode.SByte:
                    output.Push(-(sbyte)operand);
                    break;
                case TypeCode.Byte:
                    output.Push(-(byte)operand);
                    break;
                case TypeCode.Int16:
                    output.Push(-(short)operand);
                    break;
                case TypeCode.UInt16:
                    output.Push(-(ushort)operand);
                    break;
                case TypeCode.Int32:
                    output.Push(-(int)operand);
                    break;
                case TypeCode.UInt32:
                    output.Push(-(uint)operand);
                    break;
                case TypeCode.Int64:
                    output.Push(-(long)operand);
                    break;
                case TypeCode.Single:
                    output.Push((float)-(double)(float)operand);
                    break;
                case TypeCode.Double:
                    output.Push(-(double)operand);
                    break;
                case TypeCode.Decimal:
                    output.Push(-(decimal)operand);
                    break;
                default:
                    throw new InvalidOperatorTypesException("-", operand);
            }
        }
    }
}