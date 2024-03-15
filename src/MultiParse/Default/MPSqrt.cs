using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPSqrt : MPFunction
    {
        public MPSqrt()
          : base("[sS]qrt")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Sqrt()");
            object obj = PopOrGet(output);
            Sqrt(output, obj);
        }

        public void Sqrt(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Sqrt()", arg);
            output.Push(Math.Sqrt(result));
        }
    }
}