namespace MultiParse
{
    public class InvalidArgumentTypeException : ParseException
    {
        public InvalidArgumentTypeException(string function, object a)
          : base($"Function {function} can not execute with argument of type '{a.GetType()}'")
        {
        }

        public InvalidArgumentTypeException(string function, object a, object b)
          : base($"Function {function} can not execute with arguments of type '{a.GetType()}' and '{b.GetType()}'")
        {
        }
    }
}