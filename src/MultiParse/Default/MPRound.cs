using System;
using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPRound : MPFunction
    {
        public MPRound()
          : base("[rR]ound")
        {
        }

        public override void Execute(Stack<object> output, int arguments)
        {
            switch (arguments)
            {
                case 1:
                    object obj = PopOrGet(output);
                    Round(output, obj);
                    break;
                case 2:
                    object right = PopOrGet(output);
                    object left = PopOrGet(output);
                    Round(output, left, right);
                    break;
                default:
                    throw new InvalidArgumentCountException(1, 2, "Round()");
            }
        }

        public void Round(Stack<object> output, object arg)
        {
            double result1;
            bool flag1 = CastImplicit(arg, out result1);
            decimal result2;
            bool flag2 = CastImplicit(arg, out result2);
            if (flag1 && flag2)
                throw new ParseException("Ambiguous call to Round() for type '" + arg.GetType() + "'");
            if (flag1)
            {
                output.Push(Math.Round(result1));
            }
            else
            {
                if (!flag2)
                    throw new InvalidArgumentTypeException("Round()", arg);
                output.Push(Math.Round(result2));
            }
        }

        public void Round(Stack<object> output, object left, object right)
        {
            int result1;
            if (!CastImplicit(right, out result1))
                throw new InvalidArgumentTypeException("Round()", left, right);
            double result2;
            bool flag1 = CastImplicit(left, out result2);
            double result3;
            bool flag2 = CastImplicit(left, out result3);
            if (flag1 && flag2)
                throw new ParseException("Ambiguous call to Round() for type '" + left.GetType() + "'");
            if (flag1)
            {
                output.Push(Math.Round(result2, result1));
            }
            else
            {
                if (!flag2)
                    throw new InvalidArgumentTypeException("Round()", left);
                output.Push(Math.Round(result3, result1));
            }
        }
    }
}