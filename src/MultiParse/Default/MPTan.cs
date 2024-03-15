using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPTan : MPFunction
    {
        public MPTan()
          : base("[tT]an")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Tan()");
            object obj = PopOrGet(output);
            Tan(output, obj);
        }

        public void Tan(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Tan()", arg);
            output.Push(Math.Tan(result));
        }
    }
}