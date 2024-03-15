using System.Collections.Generic;

namespace MultiParse
{
    public class MPBracketInfo : MPExecutable
    {
        private List<string> separators;
        private HashSet<string> distinct;
        private string bracket;
        public bool IsEmpty;

        public string Bracket => bracket;

        public List<string> Separators => separators;

        public HashSet<string> DistinctSeparators => distinct;

        public MPBracketInfo(string bracket)
        {
            this.bracket = bracket;
            separators = new List<string>();
            distinct = new HashSet<string>();
            IsEmpty = false;
        }

        public void AddSeparator(string separator)
        {
            separators.Add(separator);
            if (distinct.Contains(separator))
                return;
            distinct.Add(separator);
        }
    }
}