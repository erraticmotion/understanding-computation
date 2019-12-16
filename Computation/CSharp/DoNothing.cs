namespace ErraticMotion
{
    public class DoNothing : SemanticBase
    {
        public override bool Reducible()
            => false;

        public override object Value()
            => "do-nothing";

        public static bool Is(SemanticBase other)
            => other.GetType() == typeof(DoNothing);

        public override string ToString()
            => this.Value().ToString();
    }
}