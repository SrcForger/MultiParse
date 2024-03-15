using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPExp : MPFunction
    {
        public MPExp()
          : base("[eE]xp")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Exp()");
            var obj = PopOrGet(output);
            Exp(output, obj);
        }

        public void Exp(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Exp()", arg);
            output.Push(Math.Exp(result));
        }
    }
}