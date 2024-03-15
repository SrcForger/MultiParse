using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPConditionalOr : MPOperator
    {
        public MPConditionalOr()
          : base("||", PrecedenceConditionalOr, true)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return IsUnary(previousToken) || !expression.StartsWith("||") ? -1 : 2;
        }

        public override void Execute(Stack<object> output)
        {
            var right = PopOrGet(output);
            var left = PopOrGet(output);
            ConditionalOr(output, left, right);
        }

        public void ConditionalOr(Stack<object> output, object left, object right)
        {
            if (!(left is bool) || !(right is bool))
                throw new InvalidOperatorTypesException("||", left, right);
            output.Push((bool)left ? 1 : ((bool)right ? 1 : 0));
        }
    }
}