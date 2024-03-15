using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPFloor : MPFunction
    {
        public MPFloor()
          : base("[fF]loor")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            if (arguments != 1)
                throw new InvalidArgumentCountException(1, 2, "Floor()");
            var obj = PopOrGet(output);
            Floor(output, obj);
        }

        public void Floor(Stack<object> output, object arg)
        {
            double result1;
            var flag1 = CastImplicit(arg, out result1);
            decimal result2;
            var flag2 = CastImplicit(arg, out result2);
            if (flag1 && flag2)
                throw new ParseException("The call to Floor() is ambiguous for the type '" + arg.GetType() + "'");
            if (flag1)
            {
                output.Push(Math.Floor(result1));
            }
            else
            {
                if (!flag2)
                    throw new InvalidArgumentTypeException("Floor()", arg);
                output.Push(Math.Floor(result2));
            }
        }
    }
}