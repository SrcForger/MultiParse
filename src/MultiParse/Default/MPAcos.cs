using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPAcos : MPFunction
    {
        public MPAcos()
          : base("[aA]cos")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Acos()");
            object obj = PopOrGet(output);
            Acos(output, obj);
        }

        public void Acos(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Acos()", arg);
            output.Push(Math.Acos(result));
        }
    }
}