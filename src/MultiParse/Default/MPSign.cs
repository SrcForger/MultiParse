using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPSign : MPFunction
    {
        public MPSign()
          : base("[sS]ign")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Sign()");
            object obj = PopOrGet(output);
            Sign(output, obj);
        }

        public void Sign(Stack<object> output, object arg)
        {
            switch (Type.GetTypeCode(arg.GetType()))
            {
                case TypeCode.Char:
                    output.Push(Math.Sign((char)arg));
                    break;
                case TypeCode.SByte:
                    output.Push(Math.Sign((sbyte)arg));
                    break;
                case TypeCode.Byte:
                    output.Push(Math.Sign((byte)arg));
                    break;
                case TypeCode.Int16:
                    output.Push(Math.Sign((short)arg));
                    break;
                case TypeCode.UInt16:
                    output.Push(Math.Sign((ushort)arg));
                    break;
                case TypeCode.Int32:
                    output.Push(Math.Sign((int)arg));
                    break;
                case TypeCode.UInt32:
                    output.Push(Math.Sign((uint)arg));
                    break;
                case TypeCode.Int64:
                    output.Push(Math.Sign((long)arg));
                    break;
                case TypeCode.Single:
                    output.Push(Math.Sign((float)arg));
                    break;
                case TypeCode.Double:
                    output.Push(Math.Sign((double)arg));
                    break;
                case TypeCode.Decimal:
                    output.Push(Math.Sign((decimal)arg));
                    break;
                default:
                    throw new InvalidArgumentTypeException("Sign()", arg);
            }
        }
    }
}