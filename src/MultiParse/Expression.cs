using MultiParse.Default;
using System;
using System.Collections.Generic;

namespace MultiParse
{
    public class Expression
    {
        protected LinkedList<CompiledAction> compiledQueue;
        private Stack<object> outputStack;
        protected Stack<object> operatorStack;
        private object lastToken;
        protected bool isCompiled = false;
        private string expression;
        private List<MPOperator> operatorList;
        private List<MPDataType> typeList;
        private List<MPBrackets> bracketList;

        public List<MPOperator> Operators
        {
            get
            {
                isCompiled = false;
                return operatorList;
            }
        }

        public List<MPDataType> DataTypes
        {
            get
            {
                isCompiled = false;
                return typeList;
            }
        }

        public List<MPBrackets> Bracketted
        {
            get
            {
                isCompiled = false;
                return bracketList;
            }
        }

        public string ParseExpression
        {
            get => expression;
            set
            {
                expression = value;
                isCompiled = false;
            }
        }

        public int CompiledOperationCount => isCompiled ? compiledQueue.Count : -1;

        public Expression()
          : this(MPDefault.DataTypes.All, MPDefault.Operators.All, MPDefault.Functions.All)
        {
        }

        public Expression(MPDefault.DataTypes datatypes)
          : this(datatypes, MPDefault.Operators.None, MPDefault.Functions.RoundBrackets)
        {
        }

        public Expression(
          MPDefault.DataTypes datatypes,
          MPDefault.Operators operators,
          MPDefault.Functions functions)
        {
            operatorList = new List<MPOperator>();
            typeList = new List<MPDataType>();
            bracketList = new List<MPBrackets>();
            compiledQueue = new LinkedList<CompiledAction>();
            outputStack = new Stack<object>();
            operatorStack = new Stack<object>();
            lastToken = null;
            isCompiled = false;
            MPDefault.RegisterDataTypes(typeList, datatypes);
            MPDefault.RegisterTypeCasts(operatorList, datatypes);
            MPDefault.RegisterOperators(operatorList, operators);
            MPDefault.RegisterFunctions(bracketList, functions);
        }

        public Expression(Expression e)
        {
            operatorList = new List<MPOperator>(e.operatorList);
            typeList = new List<MPDataType>(e.typeList);
            bracketList = new List<MPBrackets>(e.bracketList);
            isCompiled = e.isCompiled;
            expression = e.expression;
            compiledQueue = !e.isCompiled ? new LinkedList<CompiledAction>() : new LinkedList<CompiledAction>(e.compiledQueue);
            outputStack = new Stack<object>();
            operatorStack = new Stack<object>();
            lastToken = null;
        }

        public object Evaluate() => !isCompiled ? Compile() : Execute();

        public object Evaluate(string expression)
        {
            this.expression = expression;
            return Compile();
        }

        protected object Compile()
        {
            if (string.IsNullOrEmpty(this.expression))
                throw new ParseException("No expression specified.");
            outputStack.Clear();
            operatorStack.Clear();
            compiledQueue.Clear();
            lastToken = null;
            var expression = (string)this.expression.Clone();
            while (!string.IsNullOrWhiteSpace(expression))
                ProcessToken(ref expression);
            ExecuteStack();
            if (outputStack.Count != 1)
                throw new ParseException("Invalid output stack. Cannot resolve to a determined result.");
            isCompiled = true;
            var obj = outputStack.Pop();
            if (obj is IMPGettable)
            {
                compiledQueue.AddLast(() => (outputStack.Pop() as IMPGettable).Get());
                obj = (obj as IMPGettable).Get();
            }
            return obj;
        }

        protected object Execute()
        {
            outputStack.Clear();
            foreach (var compiled in compiledQueue)
                compiled();
            return outputStack.Count == 1 ? outputStack.Pop() : throw new ParseException("Invalid output stack. Cannot resolve to a determined result.");
        }

        protected void ProcessToken(ref string expression)
        {
            foreach (var bracket1 in bracketList)
            {
                var num = bracket1.MatchSeparator(expression, lastToken);
                if (num > 0)
                {
                    var bracket2 = CompileToBracket();
                    operatorStack.Push(bracket2);
                    bracket2.AddSeparator(expression.Substring(0, num));
                    expression = expression.Substring(num);
                    lastToken = null;
                    return;
                }
            }
            foreach (var mpOperator1 in operatorList)
            {
                var startIndex = mpOperator1.Match(expression, lastToken);
                if (startIndex > 0)
                {
                    expression = expression.Substring(startIndex);
                    object obj;
                    while (true)
                    {
                        if (operatorStack.Count != 0)
                        {
                            obj = operatorStack.Peek();
                            switch (obj)
                            {
                                case MPBracketInfo _:
                                    goto label_17;
                                case MPOperator _:
                                    var mpOperator2 = obj as MPOperator;
                                    if (mpOperator1.LeftAssociative && mpOperator1.Precedence == mpOperator2.Precedence || mpOperator1.Precedence < mpOperator2.Precedence)
                                    {
                                        var compiledAction = (operatorStack.Pop() as MPOperator).Action(outputStack);
                                        if (compiledAction != null)
                                            compiledQueue.AddLast(compiledAction);
                                        continue;
                                    }
                                    goto label_17;
                                default:
                                    goto label_14;
                            }
                        }
                        else
                            goto label_17;
                    }
                label_14:
                    throw new ParseException("Invalid object " + obj + " found on the operator stack");
                label_17:
                    operatorStack.Push(mpOperator1);
                    lastToken = mpOperator1;
                    return;
                }
            }
            foreach (var type in typeList)
            {
                object convertedToken = null;
                var startIndex = type.Match(expression, lastToken, out convertedToken);
                if (startIndex > 0)
                {
                    expression = expression.Substring(startIndex);
                    var compiledAction = type.Action(outputStack, convertedToken);
                    if (compiledAction != null)
                        compiledQueue.AddLast(compiledAction);
                    lastToken = convertedToken;
                    return;
                }
            }
            foreach (var bracket in bracketList)
            {
                var num = bracket.MatchOpen(expression, lastToken);
                if (num > 0)
                {
                    var mpBracketInfo = new MPBracketInfo(expression.Substring(0, num));
                    operatorStack.Push(mpBracketInfo);
                    expression = expression.Substring(num);
                    lastToken = mpBracketInfo;
                    return;
                }
            }
            MPBracketInfo mpBracketInfo1 = null;
            foreach (var bracket in bracketList)
            {
                var num = bracket.MatchClose(expression, lastToken);
                if (num > 0)
                {
                    if (mpBracketInfo1 == null)
                    {
                        if (lastToken is MPBracketInfo)
                            (lastToken as MPBracketInfo).IsEmpty = true;
                        mpBracketInfo1 = CompileToBracket();
                    }
                    if (bracket.BracketsMatch(mpBracketInfo1, expression.Substring(0, num)))
                    {
                        var compiledAction = bracket.Action(outputStack, mpBracketInfo1);
                        if (compiledAction != null)
                            compiledQueue.AddLast(compiledAction);
                        expression = expression.Substring(num);
                        return;
                    }
                }
            }
            if (mpBracketInfo1 != null)
                throw new ParseException("Bracket mismatch. Could not find matching opening bracket for '" + mpBracketInfo1.Bracket + "'");
            throw new ParseException("Invalid token found for '" + expression + "'");
        }

        protected MPBracketInfo CompileToBracket()
        {
            object bracket;
            while (true)
            {
                if (operatorStack.Count != 0)
                {
                    bracket = operatorStack.Pop();
                    switch (bracket)
                    {
                        case MPBracketInfo _:
                            goto label_3;
                        case MPOperator _:
                            var compiledAction = (bracket as MPOperator).Action(outputStack);
                            if (compiledAction != null)
                                compiledQueue.AddLast(compiledAction);
                            continue;
                        default:
                            goto label_6;
                    }
                }
                else
                    break;
            }
            throw new ParseException("Bracket mismatch. Could not find an opening bracket");
        label_3:
            return bracket as MPBracketInfo;
        label_6:
            throw new ParseException("Unrecognized object " + bracket + " on the operator stack.");
        }

        protected void ExecuteStack()
        {
            while (operatorStack.Count > 0)
            {
                var obj = operatorStack.Pop();
                switch (obj)
                {
                    case MPOperator _:
                        var compiledAction = (obj as MPOperator).Action(outputStack);
                        if (compiledAction != null)
                            compiledQueue.AddLast(compiledAction);
                        continue;
                    case MPBracketInfo _:
                        throw new ParseException("Bracket mismatch. Too many opening brackets found");
                    default:
                        throw new ParseException("Invalid object " + obj + " on the operator stack");
                }
            }
        }

        public MPDataType[] FindDataType(Type dt)
        {
            var mpDataTypeList = new List<MPDataType>();
            foreach (var type in typeList)
            {
                if (type.GetType().Equals(dt))
                    mpDataTypeList.Add(type);
            }
            return mpDataTypeList.ToArray();
        }

        public MPOperator[] FindOperator(Type op)
        {
            var mpOperatorList = new List<MPOperator>();
            foreach (var mpOperator in operatorList)
            {
                if (mpOperator.GetType().Equals(op))
                    mpOperatorList.Add(mpOperator);
            }
            return mpOperatorList.ToArray();
        }

        public MPBrackets[] FindBracketted(Type br)
        {
            var mpBracketsList = new List<MPBrackets>();
            foreach (var bracket in bracketList)
            {
                if (bracket.GetType().Equals(br))
                    mpBracketsList.Add(bracket);
            }
            return mpBracketsList.ToArray();
        }
    }
}