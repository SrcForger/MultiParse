using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse
{
    public abstract class MPFunction : MPBrackets
    {
        private string name;

        public MPFunction(string name) => this.name = name;

        public override sealed int MatchOpen(string expression, object previousToken)
        {
            Match match = Regex.Match(expression, "^" + name + "\\(");
            return match.Success ? match.Length : -1;
        }

        public override sealed int MatchSeparator(string expression, object previousToken)
        {
            return expression.Length > 0 && expression[0] == ',' ? 1 : -1;
        }

        public override sealed int MatchClose(string expression, object previousToken)
        {
            return expression.Length > 0 && expression[0] == ')' ? 1 : -1;
        }

        public override sealed bool BracketsMatch(MPBracketInfo left, string right)
        {
            return Regex.IsMatch(left.Bracket, "^" + name + "\\($") && !(right != ")") && left.DistinctSeparators.Count <= 1 && (left.DistinctSeparators.Count != 1 || left.DistinctSeparators.Contains(","));
        }

        public override CompiledAction Action(Stack<object> output, MPBracketInfo info)
        {
            int argcount = 0;
            if (!info.IsEmpty)
                argcount = info.Separators.Count + 1;
            CompiledAction compiledAction = () => Execute(output, argcount);
            compiledAction();
            return compiledAction;
        }

        public abstract void Execute(Stack<object> output, int arguments);
    }
}