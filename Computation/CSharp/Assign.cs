namespace ErraticMotion
{
    public class Assign : SemanticBase
    {
        private readonly string name;
        private readonly IReduce expression;

        public Assign(string name, IReduce expression)
        {
            this.name = name;
            this.expression = expression;
        }

        public override Reduced Reduce(Environment env)
        {
            if (this.expression.Reducible())
            {
                var result = this.expression.Reduce(env);
                return new Reduced(new Assign(this.name, result.Reduce), result.Environment);
            }

            return new Reduced(new DoNothing(), env.Changed(this.name, this.expression));
        }

        public override string ToString()
            => $"{this.name} = {this.expression}";
    }
}