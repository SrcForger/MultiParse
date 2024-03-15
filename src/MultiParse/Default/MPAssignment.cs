using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPAssignment : MPOperator
    {
        public MPAssignment()
          : base("=", PrecedenceAssignment, false)
        {
        }

        public override int Match(string expression, object previousToken)
        {
            return Regex.IsMatch(expression, "^\\=(?!\\=)") ? 1 : -1;
        }

        public override void Execute(Stack<object> output)
        {
            object obj1 = PopOrGet(output);
            object obj2 = output.Pop();
            if (!(obj2 is IMPAssignable))
                throw new ParseException("Cannot assign to a non-assignable");
            ((IMPAssignable)obj2).Assign(obj1);
            output.Push(obj1);
        }
    }
}