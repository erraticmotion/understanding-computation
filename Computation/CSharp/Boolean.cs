namespace ErraticMotion
{
    public class Boolean : SemanticBase
    {
        private readonly bool value;

        public Boolean(bool value)
            => this.value = value;

        public override bool Reducible()
            => false;

        public override object Value()
            => this.value;

        public override string ToString()
            => this.value.ToString();
    }
}