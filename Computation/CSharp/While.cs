namespace ErraticMotion
{
    public class While : SemanticBase
    {
        private readonly IReduce condition;
        private readonly IReduce body;

        public While(IReduce condition, IReduce body)
        {
            this.condition = condition;
            this.body = body;
        }

        public override Reduced Reduce(Environment env)
            => new Reduced(new If(this.condition, new Sequence(this.body, this), new DoNothing()), env);

        public override string ToString()
            => $"while ( {this.condition} ) {{ {this.body} }}";
    }
}