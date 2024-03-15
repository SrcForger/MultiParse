using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPLogicalOr : MPOperator
    {
        public MPLogicalOr()
          : base("|", PrecedenceLogicalOr, true)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return IsUnary(previousToken) || !Regex.IsMatch(expression, "^\\|(?![\\|\\=])") ? -1 : 1;
        }

        public override void Execute(Stack<object> output)
        {
            var right = PopOrGet(output);
            var left = PopOrGet(output);
            LogicalOr(output, left, right);
        }

        public void LogicalOr(Stack<object> output, object left, object right)
        {
            var typeCode1 = Type.GetTypeCode(left.GetType());
            var typeCode2 = Type.GetTypeCode(right.GetType());
            switch (typeCode1)
            {
                case TypeCode.Boolean:
                    var flag = (bool)left;
                    if (typeCode2 == TypeCode.Boolean)
                    {
                        output.Push(flag | (bool)right);
                        return;
                    }
                    break;
                case TypeCode.Char:
                    var ch = (char)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(ch | (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(ch | (int)(sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(ch | (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(ch | (int)(short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(ch | (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(ch | (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)(ch | (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(ch | (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(ch | (long)(ulong)right));
                            return;
                    }
                    break;
                case TypeCode.SByte:
                    var num1 = (sbyte)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push((int)num1 | (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push((int)num1 | (int)(sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push((int)num1 | (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push((int)num1 | (int)(short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push((int)num1 | (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push((int)num1 | (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((long)num1 | (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push((long)num1 | (long)right);
                            return;
                    }
                    break;
                case TypeCode.Byte:
                    var num2 = (byte)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num2 | (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num2 | (int)(sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num2 | (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num2 | (int)(short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num2 | (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num2 | (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)(num2 | (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(num2 | (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(num2 | (long)(ulong)right));
                            return;
                    }
                    break;
                case TypeCode.Int16:
                    var num3 = (short)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push((int)num3 | (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push((int)num3 | (int)(sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push((int)num3 | (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push((int)num3 | (int)(short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push((int)num3 | (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push((int)num3 | (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((long)num3 | (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push((long)num3 | (long)right);
                            return;
                    }
                    break;
                case TypeCode.UInt16:
                    var num4 = (ushort)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num4 | (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num4 | (int)(sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num4 | (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num4 | (int)(short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num4 | (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num4 | (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)(num4 | (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(num4 | (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(num4 | (long)(ulong)right));
                            return;
                    }
                    break;
                case TypeCode.Int32:
                    var num5 = (int)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num5 | (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num5 | (int)(sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num5 | (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num5 | (int)(short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num5 | (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num5 | (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((long)num5 | (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push((long)num5 | (long)right);
                            return;
                    }
                    break;
                case TypeCode.UInt32:
                    var num6 = (uint)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push((uint)((int)num6 | (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(num6 | (long)(sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push((uint)((int)num6 | (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(num6 | (long)(short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push((uint)((int)num6 | (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(num6 | (long)(int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)((int)num6 | (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(num6 | (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(num6 | (long)(ulong)right));
                            return;
                    }
                    break;
                case TypeCode.Int64:
                    var num7 = (long)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num7 | (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num7 | (long)(sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num7 | (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num7 | (long)(short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num7 | (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num7 | (long)(int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num7 | (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num7 | (long)right);
                            return;
                    }
                    break;
                case TypeCode.UInt64:
                    var num8 = (ulong)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push((ulong)((long)num8 | (char)right));
                            return;
                        case TypeCode.Byte:
                            output.Push((ulong)((long)num8 | (byte)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push((ulong)((long)num8 | (ushort)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push((ulong)((long)num8 | (uint)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)((long)num8 | (long)(ulong)right));
                            return;
                    }
                    break;
            }
            throw new InvalidOperatorTypesException("|", left, right);
        }
    }
}