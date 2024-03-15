using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPNot : MPOperator
    {
        public MPNot()
          : base("!", PrecedenceUnary, true)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return !IsUnary(previousToken) || !Regex.IsMatch(expression, "^\\!(?![\\!\\=])") ? -1 : 1;
        }

        public override void Execute(Stack<object> output)
        {
            var operand = PopOrGet(output);
            Not(output, operand);
        }

        public void Not(Stack<object> output, object operand)
        {
            if (!(operand is bool flag))
                throw new InvalidOperatorTypesException("!", operand);
            output.Push(!flag);
        }
    }
}