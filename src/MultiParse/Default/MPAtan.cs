using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPAtan : MPFunction
    {
        public MPAtan()
          : base("[aA]tan")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Atan()");
            object obj = PopOrGet(output);
            Atan(output, obj);
        }

        public void Atan(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Atan()", arg);
            output.Push(Math.Atan(result));
        }
    }
}