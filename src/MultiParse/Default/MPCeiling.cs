using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPCeiling : MPFunction
    {
        public MPCeiling()
          : base("[cC]eiling")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1 && arguments != 2)
                throw new InvalidArgumentCountException(1, 2, "Ceiling()");
            var obj = PopOrGet(output);
            Ceiling(output, obj);
        }

        public void Ceiling(Stack<object> output, object arg)
        {
            double result1;
            var flag1 = CastImplicit(arg, out result1);
            decimal result2;
            var flag2 = CastImplicit(arg, out result2);
            if (flag1 && flag2)
                throw new ParseException("The call to Ceiling() is ambiguous for the type '" + arg.GetType() + "'");
            if (flag1)
            {
                output.Push(Math.Ceiling(result1));
            }
            else
            {
                if (!flag2)
                    throw new InvalidArgumentTypeException("Ceiling()", arg);
                output.Push(Math.Ceiling(result2));
            }
        }
    }
}