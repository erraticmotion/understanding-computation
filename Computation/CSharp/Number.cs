namespace ErraticMotion
{
    public class Number : SemanticBase
    {
        private readonly int value;

        public Number(int value)
            => this.value = value;

        public override bool Reducible()
            => false;

        public override object Value()
            => this.value;

        public override string ToString()
            => this.value.ToString();
    }
}