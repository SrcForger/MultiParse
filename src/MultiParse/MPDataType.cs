using System.Collections.Generic;

namespace MultiParse
{
    public abstract class MPDataType : MPExecutable
    {
        public abstract int Match(string expression, object previousToken, out object convertedToken);

        public virtual CompiledAction Action(Stack<object> output, object convertedToken)
        {
            CompiledAction compiledAction = () => output.Push(convertedToken);
            compiledAction();
            return compiledAction;
        }
    }
}