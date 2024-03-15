using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPAbs : MPFunction
    {
        public MPAbs()
          : base("[aA]bs")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Abs()");
            object obj = PopOrGet(output);
            Abs(output, obj);
        }

        public void Abs(Stack<object> output, object arg)
        {
            switch (Type.GetTypeCode(arg.GetType()))
            {
                case TypeCode.Char:
                    output.Push(Math.Abs((char)arg));
                    break;
                case TypeCode.SByte:
                    output.Push(Math.Abs((sbyte)arg));
                    break;
                case TypeCode.Byte:
                    output.Push(Math.Abs((byte)arg));
                    break;
                case TypeCode.Int16:
                    output.Push(Math.Abs((short)arg));
                    break;
                case TypeCode.UInt16:
                    output.Push(Math.Abs((ushort)arg));
                    break;
                case TypeCode.Int32:
                    output.Push(Math.Abs((int)arg));
                    break;
                case TypeCode.UInt32:
                    output.Push(Math.Abs((uint)arg));
                    break;
                case TypeCode.Int64:
                    output.Push(Math.Abs((long)arg));
                    break;
                case TypeCode.Single:
                    output.Push(Math.Abs((float)arg));
                    break;
                case TypeCode.Double:
                    output.Push(Math.Abs((double)arg));
                    break;
                case TypeCode.Decimal:
                    output.Push(Math.Abs((decimal)arg));
                    break;
                default:
                    throw new InvalidArgumentTypeException("Abs()", arg);
            }
        }
    }
}