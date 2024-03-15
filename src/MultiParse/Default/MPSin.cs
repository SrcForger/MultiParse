using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPSin : MPFunction
    {
        public MPSin()
          : base("[sS]in")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Sin()");
            var obj = PopOrGet(output);
            Sin(output, obj);
        }

        public void Sin(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Sin()", arg);
            output.Push(Math.Sin(result));
        }
    }
}