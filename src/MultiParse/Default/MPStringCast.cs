using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPStringCast : MPOperator
    {
        public MPStringCast()
          : base("(string)", PrecedenceUnary, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            if (expression.StartsWith("(string)"))
                return "(string)".Length;
            return expression.StartsWith("(String)") ? "(String)".Length : -1;
        }

        public override void Execute(Stack<object> output)
        {
            var a = PopOrGet(output);
            if (!(a is string))
                throw new InvalidOperatorTypesException("(String)", a);
            output.Push((string)a);
        }
    }
}