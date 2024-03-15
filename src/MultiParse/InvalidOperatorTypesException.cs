namespace MultiParse
{
    public class InvalidOperatorTypesException : ParseException
    {
        public InvalidOperatorTypesException(string op, object a)
          : base($"Operator '{op}' cannot be applied to operand of type '{a.GetType()}'")
        {
        }

        public InvalidOperatorTypesException(string op, object a, object b)
          : base($"Operator '{op}' cannot be applied to operands of type '{a.GetType()}' and '{b.GetType()}'")
        {
        }
    }
}