using System.Collections.Generic;

namespace MultiParse
{
    public abstract class MPBrackets : MPExecutable
    {
        public abstract int MatchOpen(string expression, object previousToken);

        public abstract int MatchSeparator(string expression, object previousToken);

        public abstract int MatchClose(string expression, object previousToken);

        public abstract bool BracketsMatch(MPBracketInfo left, string right);

        public virtual void Execute(Stack<object> output, MPBracketInfo info)
        {
        }

        public virtual CompiledAction Action(Stack<object> output, MPBracketInfo info)
        {
            CompiledAction compiledAction = () => Execute(output, info);
            compiledAction();
            return compiledAction;
        }
    }
}