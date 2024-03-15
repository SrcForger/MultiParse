using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPCos : MPFunction
    {
        public MPCos()
          : base("[cC]os")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Cos()");
            var obj = PopOrGet(output);
            Cos(output, obj);
        }

        public void Cos(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Cos()", arg);
            output.Push(Math.Cos(result));
        }
    }
}