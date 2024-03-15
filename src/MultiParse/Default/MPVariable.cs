using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPVariable : MPDataType
    {
        public bool AutoGenerate;
        private Dictionary<string, MPVariableInstance> variables;

        public Dictionary<string, MPVariableInstance> Variables => variables;

        public MPVariable()
        {
            AutoGenerate = true;
            variables = new Dictionary<string, MPVariableInstance>();
        }

        public override int Match(string expression, object previousToken, out object convertedToken)
        {
            Match match = Regex.Match(expression, "^[a-zA-Z_]\\w*(?![\\w\\.\\(\\[])");
            if (match.Success)
            {
                if (!variables.ContainsKey(match.Value))
                {
                    if (AutoGenerate)
                    {
                        variables.Add(match.Value, new MPVariableInstance());
                    }
                    else
                    {
                        convertedToken = null;
                        return -1;
                    }
                }
                convertedToken = variables[match.Value];
                return match.Length;
            }
            convertedToken = null;
            return -1;
        }
    }
}