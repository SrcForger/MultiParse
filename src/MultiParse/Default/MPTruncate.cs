using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPTruncate : MPFunction
    {
        public MPTruncate()
          : base("[tT]runcate")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, "Truncate()");
            var obj = PopOrGet(output);
            Truncate(output, obj);
        }

        public void Truncate(Stack<object> output, object arg)
        {
            double result1;
            var flag1 = CastImplicit(arg, out result1);
            decimal result2;
            var flag2 = CastImplicit(arg, out result2);
            if (flag1 && flag2)
                throw new ParseException("Ambiguous call to Truncate() for type '" + arg.GetType() + "'");
            if (flag1)
            {
                output.Push(Math.Truncate(result1));
            }
            else
            {
                if (!flag2)
                    throw new InvalidArgumentTypeException("Truncate()", arg);
                output.Push(Math.Truncate(result2));
            }
        }
    }
}