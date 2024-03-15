using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPConditionalAnd : MPOperator
    {
        public MPConditionalAnd()
          : base("&&", PrecedenceConditionalAnd, true)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return IsUnary(previousToken) || !expression.StartsWith("&&") ? -1 : 2;
        }

        public override void Execute(Stack<object> output)
        {
            var right = PopOrGet(output);
            var left = PopOrGet(output);
            ConditionalAnd(output, left, right);
        }

        public void ConditionalAnd(Stack<object> output, object left, object right)
        {
            if (!(left is bool) || !(right is bool))
                throw new InvalidOperatorTypesException("&&", left, right);
            output.Push(!(bool)left ? 0 : ((bool)right ? 1 : 0));
        }
    }
}