using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPPow : MPFunction
    {
        public MPPow()
          : base("[pP]ow")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 2)
                throw new ParseException("Invalid number of arguments for Pow(). 2 arguments expected.");
            var right = PopOrGet(output);
            var left = PopOrGet(output);
            Pow(output, left, right);
        }

        public void Pow(Stack<object> output, object left, object right)
        {
            double result1;
            double result2;
            if (!CastImplicit(left, out result1) || !CastImplicit(right, out result2))
                throw new InvalidArgumentTypeException("Pow()", left, right);
            output.Push(Math.Pow(result1, result2));
        }
    }
}