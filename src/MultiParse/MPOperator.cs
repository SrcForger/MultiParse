using System.Collections.Generic;

namespace MultiParse
{
    public abstract class MPOperator : MPExecutable
    {
        protected static int PrecedenceAssignment = 0;
        protected static int PrecedenceConditional = 1;
        protected static int PrecedenceConditionalOr = 2;
        protected static int PrecedenceConditionalAnd = 3;
        protected static int PrecedenceLogicalOr = 4;
        protected static int PrecedenceLogicalXOr = 5;
        protected static int PrecedenceLogicalAnd = 6;
        protected static int PrecedenceEquality = 7;
        protected static int PrecedenceRelational = 8;
        protected static int PrecedenceShift = 9;
        protected static int PrecedenceAdditive = 10;
        protected static int PrecedenceMultiplicative = 11;
        protected static int PrecedenceUnary = 12;
        protected static int PrecedencePrimary = 13;
        protected int precedence;
        protected bool leftAssociative;
        protected string key;

        public string Key => key;

        public MPOperator(string key, int precedence, bool leftAssociative)
        {
            this.key = key;
            this.precedence = precedence;
            this.leftAssociative = leftAssociative;
        }

        public int Precedence => precedence;

        public bool LeftAssociative => leftAssociative;

        public abstract int Match(string expression, object previousToken);

        public virtual void Execute(Stack<object> output)
        {
        }

        public virtual CompiledAction Action(Stack<object> output)
        {
            CompiledAction compiledAction = () => Execute(output);
            compiledAction();
            return compiledAction;
        }
    }
}