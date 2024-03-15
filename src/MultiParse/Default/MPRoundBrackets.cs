using System.Collections.Generic;

namespace MultiParse.Default
{
    public class MPRoundBrackets : MPBrackets
    {
        public override int MatchOpen(string expression, object previousToken)
        {
            return expression.Length > 0 && expression[0] == '(' ? 1 : -1;
        }

        public override int MatchSeparator(string expression, object previousToken) => -1;

        public override int MatchClose(string expression, object previousToken)
        {
            return expression.Length > 0 && expression[0] == ')' ? 1 : -1;
        }

        public override bool BracketsMatch(MPBracketInfo left, string right)
        {
            return !(left.Bracket != "(") && !(right != ")") && left.Separators.Count <= 0;
        }

        public override CompiledAction Action(Stack<object> output, MPBracketInfo info)
        {
            return null;
        }
    }
}