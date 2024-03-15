using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPLogicalAnd : MPOperator
    {
        public MPLogicalAnd()
          : base("&", PrecedenceLogicalAnd, true)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return IsUnary(previousToken) || !Regex.IsMatch(expression, "^\\&(?![\\&\\=])") ? -1 : 1;
        }

        public override void Execute(Stack<object> output)
        {
            object right = PopOrGet(output);
            object left = PopOrGet(output);
            LogicalAnd(output, left, right);
        }

        public void LogicalAnd(Stack<object> output, object left, object right)
        {
            TypeCode typeCode1 = Type.GetTypeCode(left.GetType());
            TypeCode typeCode2 = Type.GetTypeCode(right.GetType());
            switch (typeCode1)
            {
                case TypeCode.Boolean:
                    bool flag = (bool)left;
                    if (typeCode2 == TypeCode.Boolean)
                    {
                        output.Push(flag & (bool)right);
                        return;
                    }
                    break;
                case TypeCode.Char:
                    char ch = (char)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(ch & (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(ch & (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(ch & (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(ch & (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(ch & (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(ch & (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)(ch & (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(ch & (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(ch & (long)(ulong)right));
                            return;
                    }
                    break;
                case TypeCode.SByte:
                    sbyte num1 = (sbyte)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num1 & (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num1 & (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num1 & (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num1 & (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num1 & (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num1 & (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num1 & (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num1 & (long)right);
                            return;
                    }
                    break;
                case TypeCode.Byte:
                    byte num2 = (byte)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num2 & (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num2 & (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num2 & (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num2 & (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num2 & (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num2 & (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)(num2 & (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(num2 & (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(num2 & (long)(ulong)right));
                            return;
                    }
                    break;
                case TypeCode.Int16:
                    short num3 = (short)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num3 & (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num3 & (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num3 & (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num3 & (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num3 & (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num3 & (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num3 & (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num3 & (long)right);
                            return;
                    }
                    break;
                case TypeCode.UInt16:
                    ushort num4 = (ushort)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num4 & (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num4 & (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num4 & (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num4 & (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num4 & (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num4 & (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)(num4 & (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(num4 & (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(num4 & (long)(ulong)right));
                            return;
                    }
                    break;
                case TypeCode.Int32:
                    int num5 = (int)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num5 & (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num5 & (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num5 & (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num5 & (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num5 & (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num5 & (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num5 & (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num5 & (long)right);
                            return;
                    }
                    break;
                case TypeCode.UInt32:
                    uint num6 = (uint)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push((uint)((int)num6 & (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(num6 & (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push((uint)((int)num6 & (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(num6 & (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push((uint)((int)num6 & (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(num6 & (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push((uint)((int)num6 & (int)(uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(num6 & (long)right);
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)(num6 & (long)(ulong)right));
                            return;
                    }
                    break;
                case TypeCode.Int64:
                    long num7 = (long)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(num7 & (char)right);
                            return;
                        case TypeCode.SByte:
                            output.Push(num7 & (sbyte)right);
                            return;
                        case TypeCode.Byte:
                            output.Push(num7 & (byte)right);
                            return;
                        case TypeCode.Int16:
                            output.Push(num7 & (short)right);
                            return;
                        case TypeCode.UInt16:
                            output.Push(num7 & (ushort)right);
                            return;
                        case TypeCode.Int32:
                            output.Push(num7 & (int)right);
                            return;
                        case TypeCode.UInt32:
                            output.Push(num7 & (uint)right);
                            return;
                        case TypeCode.Int64:
                            output.Push(num7 & (long)right);
                            return;
                    }
                    break;
                case TypeCode.UInt64:
                    ulong num8 = (ulong)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push((ulong)((long)num8 & (char)right));
                            return;
                        case TypeCode.Byte:
                            output.Push((ulong)((long)num8 & (byte)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push((ulong)((long)num8 & (ushort)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push((ulong)((long)num8 & (uint)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push((ulong)((long)num8 & (long)(ulong)right));
                            return;
                    }
                    break;
            }
            throw new InvalidOperatorTypesException("&", left, right);
        }
    }
}