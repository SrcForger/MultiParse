using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPTanh : MPFunction
    {
        public MPTanh()
          : base("[tT]anh")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Tanh()");
            var obj = PopOrGet(output);
            Tanh(output, obj);
        }

        public void Tanh(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Tanh()", arg);
            output.Push(Math.Tanh(result));
        }
    }
}