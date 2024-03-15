using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPMin : MPFunction
    {
        public MPMin()
          : base("[mM]in")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 2)
                throw new InvalidArgumentCountException(2, "Min()");
            object right = PopOrGet(output);
            object left = PopOrGet(output);
            Min(output, left, right);
        }

        public void Min(Stack<object> output, object left, object right)
        {
            TypeCode typeCode1 = Type.GetTypeCode(left.GetType());
            TypeCode typeCode2 = Type.GetTypeCode(right.GetType());
            switch (typeCode1)
            {
                case TypeCode.Char:
                    char val1_1 = (char)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_1, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_1, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_1, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_1, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_1, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_1, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_1, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_1, (long)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push(Math.Min(val1_1, (ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_1, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_1, (double)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_1, (decimal)right));
                            return;
                    }
                    break;
                case TypeCode.SByte:
                    sbyte val1_2 = (sbyte)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_2, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_2, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_2, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_2, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_2, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_2, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_2, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_2, (long)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_2, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_2, (double)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_2, (decimal)right));
                            return;
                    }
                    break;
                case TypeCode.Byte:
                    byte val1_3 = (byte)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_3, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_3, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_3, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_3, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_3, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_3, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_3, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_3, (long)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push(Math.Min(val1_3, (ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_3, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_3, (double)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_3, (decimal)right));
                            return;
                    }
                    break;
                case TypeCode.Int16:
                    short val1_4 = (short)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_4, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_4, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_4, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_4, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_4, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_4, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_4, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_4, (long)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_4, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_4, (double)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_4, (decimal)right));
                            return;
                    }
                    break;
                case TypeCode.UInt16:
                    ushort val1_5 = (ushort)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_5, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_5, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_5, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_5, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_5, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_5, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_5, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_5, (long)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push(Math.Min(val1_5, (ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_5, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_5, (double)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_5, (decimal)right));
                            return;
                    }
                    break;
                case TypeCode.Int32:
                    int val1_6 = (int)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_6, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_6, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_6, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_6, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_6, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_6, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_6, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_6, (long)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_6, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_6, (double)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_6, (decimal)right));
                            return;
                    }
                    break;
                case TypeCode.UInt32:
                    uint val1_7 = (uint)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_7, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_7, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_7, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_7, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_7, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_7, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_7, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_7, (long)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push(Math.Min(val1_7, (ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_7, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_7, (double)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_7, (decimal)right));
                            return;
                    }
                    break;
                case TypeCode.Int64:
                    long val1_8 = (long)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_8, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_8, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_8, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_8, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_8, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_8, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_8, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_8, (long)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_8, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_8, (double)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_8, (decimal)right));
                            return;
                    }
                    break;
                case TypeCode.UInt64:
                    ulong val1_9 = (ulong)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_9, (char)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_9, (byte)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_9, (ushort)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_9, (uint)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push(Math.Min(val1_9, (ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_9, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_9, (double)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_9, (decimal)right));
                            return;
                    }
                    break;
                case TypeCode.Single:
                    float val1_10 = (float)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_10, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_10, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_10, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_10, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_10, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_10, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_10, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_10, (long)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push(Math.Min(val1_10, (ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_10, (float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min((double)val1_10, (double)right));
                            return;
                    }
                    break;
                case TypeCode.Double:
                    double val1_11 = (double)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_11, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_11, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_11, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_11, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_11, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_11, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_11, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_11, (long)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push(Math.Min(val1_11, (ulong)right));
                            return;
                        case TypeCode.Single:
                            output.Push(Math.Min(val1_11, (double)(float)right));
                            return;
                        case TypeCode.Double:
                            output.Push(Math.Min(val1_11, (double)right));
                            return;
                    }
                    break;
                case TypeCode.Decimal:
                    decimal val1_12 = (decimal)left;
                    switch (typeCode2)
                    {
                        case TypeCode.Char:
                            output.Push(Math.Min(val1_12, (char)right));
                            return;
                        case TypeCode.SByte:
                            output.Push(Math.Min(val1_12, (sbyte)right));
                            return;
                        case TypeCode.Byte:
                            output.Push(Math.Min(val1_12, (byte)right));
                            return;
                        case TypeCode.Int16:
                            output.Push(Math.Min(val1_12, (short)right));
                            return;
                        case TypeCode.UInt16:
                            output.Push(Math.Min(val1_12, (ushort)right));
                            return;
                        case TypeCode.Int32:
                            output.Push(Math.Min(val1_12, (int)right));
                            return;
                        case TypeCode.UInt32:
                            output.Push(Math.Min(val1_12, (uint)right));
                            return;
                        case TypeCode.Int64:
                            output.Push(Math.Min(val1_12, (long)right));
                            return;
                        case TypeCode.UInt64:
                            output.Push(Math.Min(val1_12, (ulong)right));
                            return;
                        case TypeCode.Decimal:
                            output.Push(Math.Min(val1_12, (decimal)right));
                            return;
                    }
                    break;
            }
            throw new InvalidArgumentTypeException("Min()", left, right);
        }
    }
}