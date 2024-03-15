using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPAsin : MPFunction
    {
        public MPAsin()
          : base("[aA]sin")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Asin()");
            var obj = PopOrGet(output);
            Asin(output, obj);
        }

        public void Asin(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Asin()", arg);
            output.Push(Math.Asin(result));
        }
    }
}