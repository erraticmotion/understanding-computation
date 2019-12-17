namespace ErraticMotion
{
    public class Boolean : SemanticBase
    {
        private readonly bool value;

        public Boolean(bool value)
            : base(false)
            => this.value = value;

        public override object Value()
            => this.value;

        public override string ToString()
            => this.value.ToString();
    }
}