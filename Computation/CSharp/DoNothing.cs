namespace ErraticMotion
{
    public class DoNothing : SemanticBase
    {
        public DoNothing()
            : base(false)
        {
        }

        public override object Value()
            => "do-nothing";

        public override string ToString()
            => this.Value().ToString();
    }
}