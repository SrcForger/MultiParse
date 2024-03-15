using System;
using System.Collections.Generic;

namespace MultiParse
{
    public class MPExecutable
    {
        protected object PopOrGet(Stack<object> output)
        {
            var obj = output.Pop();
            return obj is IMPGettable ? (obj as IMPGettable).Get() : obj;
        }

        protected bool IsUnary(object previousToken)
        {
            switch (previousToken)
            {
                case null:
                    return true;
                case MPOperator _:
                    return true;
                case MPBracketInfo _:
                    return true;
                default:
                    return false;
            }
        }

        protected static bool CastImplicit(object o, out bool result)
        {
            if (o is bool flag)
            {
                result = flag;
                return true;
            }
            result = false;
            return false;
        }

        protected static bool CastImplicit(object o, out byte result)
        {
            if (o is byte num)
            {
                result = num;
                return true;
            }
            result = 0;
            return false;
        }

        protected static bool CastImplicit(object o, out char result)
        {
            if (o is char ch)
            {
                result = ch;
                return true;
            }
            result = char.MinValue;
            return false;
        }

        protected static bool CastImplicit(object o, out decimal result)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Char:
                    result = (char)o;
                    return true;
                case TypeCode.SByte:
                    result = (sbyte)o;
                    return true;
                case TypeCode.Byte:
                    result = (byte)o;
                    return true;
                case TypeCode.Int16:
                    result = (short)o;
                    return true;
                case TypeCode.UInt16:
                    result = (ushort)o;
                    return true;
                case TypeCode.Int32:
                    result = (int)o;
                    return true;
                case TypeCode.UInt32:
                    result = (uint)o;
                    return true;
                case TypeCode.Int64:
                    result = (long)o;
                    return true;
                case TypeCode.UInt64:
                    result = (ulong)o;
                    return true;
                case TypeCode.Decimal:
                    result = (decimal)o;
                    return true;
                default:
                    result = 0M;
                    return false;
            }
        }

        protected static bool CastImplicit(object o, out double result)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Char:
                    result = (char)o;
                    return true;
                case TypeCode.SByte:
                    result = (sbyte)o;
                    return true;
                case TypeCode.Byte:
                    result = (byte)o;
                    return true;
                case TypeCode.Int16:
                    result = (short)o;
                    return true;
                case TypeCode.UInt16:
                    result = (ushort)o;
                    return true;
                case TypeCode.Int32:
                    result = (int)o;
                    return true;
                case TypeCode.UInt32:
                    result = (uint)o;
                    return true;
                case TypeCode.Int64:
                    result = (long)o;
                    return true;
                case TypeCode.UInt64:
                    result = (ulong)o;
                    return true;
                case TypeCode.Single:
                    result = (double)(float)o;
                    return true;
                case TypeCode.Double:
                    result = (double)o;
                    return true;
                default:
                    result = 0.0;
                    return false;
            }
        }

        protected static bool CastImplicit(object o, out short result)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.SByte:
                    result = (sbyte)o;
                    return true;
                case TypeCode.Byte:
                    result = (byte)o;
                    return true;
                case TypeCode.Int16:
                    result = (short)o;
                    return true;
                default:
                    result = 0;
                    return false;
            }
        }

        protected static bool CastImplicit(object o, out int result)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Char:
                    result = (char)o;
                    return true;
                case TypeCode.SByte:
                    result = (sbyte)o;
                    return true;
                case TypeCode.Byte:
                    result = (byte)o;
                    return true;
                case TypeCode.Int16:
                    result = (short)o;
                    return true;
                case TypeCode.UInt16:
                    result = (ushort)o;
                    return true;
                case TypeCode.Int32:
                    result = (int)o;
                    return true;
                default:
                    result = 0;
                    return false;
            }
        }

        protected static bool CastImplicit(object o, out long result)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Char:
                    result = (char)o;
                    return true;
                case TypeCode.SByte:
                    result = (sbyte)o;
                    return true;
                case TypeCode.Byte:
                    result = (byte)o;
                    return true;
                case TypeCode.Int16:
                    result = (short)o;
                    return true;
                case TypeCode.UInt16:
                    result = (ushort)o;
                    return true;
                case TypeCode.Int32:
                    result = (int)o;
                    return true;
                case TypeCode.UInt32:
                    result = (uint)o;
                    return true;
                case TypeCode.Int64:
                    result = (long)o;
                    return true;
                default:
                    result = 0L;
                    return false;
            }
        }

        protected static bool CastImplicit(object o, out sbyte result)
        {
            if (o is sbyte num)
            {
                result = num;
                return true;
            }
            result = 0;
            return false;
        }

        protected static bool CastImplicit(object o, out float result)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Char:
                    result = (char)o;
                    return true;
                case TypeCode.SByte:
                    result = (sbyte)o;
                    return true;
                case TypeCode.Byte:
                    result = (byte)o;
                    return true;
                case TypeCode.Int16:
                    result = (short)o;
                    return true;
                case TypeCode.UInt16:
                    result = (ushort)o;
                    return true;
                case TypeCode.Int32:
                    result = (int)o;
                    return true;
                case TypeCode.UInt32:
                    result = (uint)o;
                    return true;
                case TypeCode.Int64:
                    result = (long)o;
                    return true;
                case TypeCode.UInt64:
                    result = (ulong)o;
                    return true;
                case TypeCode.Single:
                    result = (float)o;
                    return true;
                default:
                    result = 0.0f;
                    return false;
            }
        }

        protected static bool CastImplicit(object o, out ushort result)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Char:
                    result = (ushort)(short)(char)o;
                    return true;
                case TypeCode.Byte:
                    result = (ushort)(short)(byte)o;
                    return true;
                case TypeCode.UInt16:
                    result = (ushort)o;
                    return true;
                default:
                    result = 0;
                    return false;
            }
        }

        protected static bool CastImplicit(object o, out uint result)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Char:
                    result = (char)o;
                    return true;
                case TypeCode.Byte:
                    result = (byte)o;
                    return true;
                case TypeCode.UInt16:
                    result = (ushort)o;
                    return true;
                case TypeCode.UInt32:
                    result = (uint)o;
                    return true;
                default:
                    result = 0U;
                    return false;
            }
        }

        protected static bool CastImplicit(object o, out ulong result)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Char:
                    result = (char)o;
                    return true;
                case TypeCode.Byte:
                    result = (byte)o;
                    return true;
                case TypeCode.UInt16:
                    result = (ushort)o;
                    return true;
                case TypeCode.UInt32:
                    result = (uint)o;
                    return true;
                case TypeCode.UInt64:
                    result = (ulong)o;
                    return true;
                default:
                    result = 0UL;
                    return false;
            }
        }
    }
}