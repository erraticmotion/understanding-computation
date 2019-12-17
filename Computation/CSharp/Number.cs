namespace ErraticMotion
{
    public class Number : SemanticBase
    {
        private readonly int value;

        public Number(int value)
            : base(false)
            => this.value = value;

        public override object Value()
            => this.value;

        public override string ToString()
            => this.value.ToString();
    }
}