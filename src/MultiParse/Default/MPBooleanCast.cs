using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPBooleanCast : MPOperator
    {
        public MPBooleanCast()
          : base("(bool)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(bool)"))
                return "(bool)".Length;
            return expression.StartsWith("(Boolean)") ? "(Boolean)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            var a = PopOrGet(output);
            if (!(a is bool flag))
                throw new InvalidOperatorTypesException("(Boolean)", a);
            output.Push(flag);
        }
    }
}