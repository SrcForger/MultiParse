using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPLog10 : MPFunction
    {
        public MPLog10()
          : base("[lL]og10")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Log10()");
            object obj = PopOrGet(output);
            Log10(output, obj);
        }

        public void Log10(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Log10()", arg);
            output.Push(Math.Log10(result));
        }
    }
}