﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPMultiplication : MPOperator
    {
        public MPMultiplication()
          : base("*", PrecedenceMultiplicative, true)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return IsUnary(previousToken) || !Regex.IsMatch(expression, "^\\*(?![\\*\\=])") ? -1 : 1;
        }

        public override void Execute(Stack<object> output)
        {
            var right = PopOrGet(output);
            var left = PopOrGet(output);
            Multiply(output, left, right);
        }

        public void Multiply(Stack<object> output, object left, object right)
        {
            var typeCode1 = Type.GetTypeCode(left.GetType());
            var typeCode2 = Type.GetTypeCode(right.GetType());
            switch (typeCode1)
            {
                case TypeCode.Char:
                    var ch = (char)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(ch * (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(ch * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(ch * (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(ch * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(ch * (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(ch * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)(ch * (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(ch * (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(ch * (long)(ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push((float)(ch * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(ch * (double)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(ch * (decimal)right);
                            return;
                    }
                    break;
                case TypeCode.SByte:
                    var num1 = (sbyte)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num1 * (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num1 * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num1 * (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num1 * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num1 * (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num1 * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num1 * (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num1 * (long)right);
                            return;
                        case TypeCode.Single:
                            output.Push((float)(num1 * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(num1 * (double)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(num1 * (decimal)right);
                            return;
                    }
                    break;
                case TypeCode.Byte:
                    var num2 = (byte)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num2 * (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num2 * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num2 * (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num2 * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num2 * (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num2 * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)(num2 * (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(num2 * (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(num2 * (long)(ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push((float)(num2 * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(num2 * (double)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(num2 * (decimal)right);
                            return;
                    }
                    break;
                case TypeCode.Int16:
                    var num3 = (short)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num3 * (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num3 * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num3 * (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num3 * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num3 * (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num3 * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num3 * (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num3 * (long)right);
                            return;
                        case TypeCode.Single:
                            output.Push((float)(num3 * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(num3 * (double)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(num3 * (decimal)right);
                            return;
                    }
                    break;
                case TypeCode.UInt16:
                    var num4 = (ushort)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num4 * (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num4 * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num4 * (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num4 * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num4 * (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num4 * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)(num4 * (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(num4 * (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(num4 * (long)(ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push((float)(num4 * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(num4 * (double)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(num4 * (decimal)right);
                            return;
                    }
                    break;
                case TypeCode.Int32:
                    var num5 = (int)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num5 * (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num5 * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num5 * (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num5 * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num5 * (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num5 * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num5 * (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num5 * (long)right);
                            return;
                        case TypeCode.Single:
                            output.Push((float)(num5 * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(num5 * (double)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(num5 * (decimal)right);
                            return;
                    }
                    break;
                case TypeCode.UInt32:
                    var num6 = (uint)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push((uint)((int)num6 * (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(num6 * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push((uint)((int)num6 * (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(num6 * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push((uint)((int)num6 * (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(num6 * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)((int)num6 * (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(num6 * (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(num6 * (long)(ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push((float)(num6 * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(num6 * (double)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(num6 * (decimal)right);
                            return;
                    }
                    break;
                case TypeCode.Int64:
                    var num7 = (long)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num7 * (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num7 * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num7 * (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num7 * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num7 * (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num7 * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num7 * (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num7 * (long)right);
                            return;
                        case TypeCode.Single:
                            output.Push((float)(num7 * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(num7 * (double)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(num7 * (decimal)right);
                            return;
                    }
                    break;
                case TypeCode.UInt64:
                    var num8 = (ulong)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push((ulong)((long)num8 * (char)right));
                            return;
                        case TypeCode.Byte:
                            output.Push((ulong)((long)num8 * (byte)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push((ulong)((long)num8 * (ushort)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push((ulong)((long)num8 * (uint)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)((long)num8 * (long)(ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push((float)(num8 * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(num8 * (double)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(num8 * (decimal)right);
                            return;
                    }
                    break;
                case TypeCode.Single:
                    var num9 = (float)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push((float)((double)num9 * (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push((float)((double)num9 * (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push((float)((double)num9 * (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push((float)((double)num9 * (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push((float)((double)num9 * (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push((float)((double)num9 * (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push((float)((double)num9 * (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push((float)((double)num9 * (long)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push((float)((double)num9 * (ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push((float)((double)num9 * (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push((double)num9 * (double)right);
                            return;
                    }
                    break;
                case TypeCode.Double:
                    var num10 = (double)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num10 * (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num10 * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num10 * (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num10 * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num10 * (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num10 * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num10 * (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num10 * (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push(num10 * (ulong)right);
                            return;
                        case TypeCode.Single:
                            output.Push(num10 * (double)(float)right);
                            return;
                        case TypeCode.Double:
                            output.Push(num10 * (double)right);
                            return;
                    }
                    break;
                case TypeCode.Decimal:
                    var num11 = (decimal)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num11 * (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num11 * (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num11 * (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num11 * (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num11 * (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num11 * (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num11 * (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num11 * (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push(num11 * (ulong)right);
                            return;
                        case TypeCode.Decimal:
                            output.Push(num11 * (decimal)right);
                            return;
                    }
                    break;
            }
            throw new InvalidOperatorTypesException("*", left, right);
        }
    }
}