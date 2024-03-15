using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPLog : MPFunction
    {
        public MPLog()
          : base("[lL]og")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            switch (arguments)
            {
                case 1:
                    object obj = PopOrGet(output);
                    Log(output, obj);
                    break;
                case 2:
                    object right = PopOrGet(output);
                    object left = PopOrGet(output);
                    Log(output, left, right);
                    break;
                default:
                    throw new InvalidArgumentCountException(1, 2, "Log()");
            }
        }

        public void Log(Stack<object> output, object arg)
        {
            double result;
            if (!CastImplicit(arg, out result))
                throw new InvalidArgumentTypeException("Log()", arg);
            output.Push(Math.Log(result));
        }

        public void Log(Stack<object> output, object left, object right)
        {
            double result1;
            double result2;
            if (!CastImplicit(left, out result1) || !CastImplicit(right, out result2))
                throw new InvalidArgumentTypeException("Log()", left, right);
            output.Push(Math.Log(result1, result2));
        }
    }
}