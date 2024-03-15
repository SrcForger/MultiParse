namespace MultiParse.Default
{
    public class MPVariableInstance : IMPAssignable, IMPGettable
    {
        private object value;

        public MPVariableInstance() => value = null;

        public MPVariableInstance(object value) => this.value = value;

        public void Assign(object value) => this.value = value;

        public object Get() => value;
    }
}