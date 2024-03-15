using System;

namespace MultiParse
{
    public class ParseException : Exception
    {
        public ParseException(string msg)
          : base(msg)
        {
        }
    }
}