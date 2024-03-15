using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPAtan2 : MPFunction
    {
        public MPAtan2()
          : base("[aA]tan2")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 2)
                throw new ParseException("Invalid number of arguments for Atan2(). 2 arguments expected.");
            var right = PopOrGet(output);
            var left = PopOrGet(output);
            Atan2(output, left, right);
        }

        public void Atan2(Stack<object> output, object left, object right)
        {
            double result1;
            double result2;
            if (!CastImplicit(left, out result1) || !CastImplicit(right, out result2))
                throw new InvalidArgumentTypeException("Atan2()", left, right);
            output.Push(Math.Atan2(result1, result2));
        }
    }
}