namespace MultiParse
{
    public class InvalidArgumentCountException : ParseException
    {
        public InvalidArgumentCountException(int expected, string function)
          : base($"Invalid amount of arguments. {expected} argument{(expected > 1 ? "s" : (object)"")} expected for {function}")
        {
        }

        public InvalidArgumentCountException(int expected1, int expected2, string function)
          : base($"Invalid amount of arguments. {expected1} or {expected2} arguments expected for {function}")
        {
        }
    }
}