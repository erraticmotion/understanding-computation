namespace ErraticMotion
{
    public class If : SemanticBase
    {
        private readonly IReduce condition;
        private readonly IReduce consequence;
        private readonly IReduce alternative;

        public If(
            IReduce condition, 
            IReduce consequence, 
            IReduce alternative)
        {
            this.condition = condition;
            this.consequence = consequence;
            this.alternative = alternative;
        }

        public override Reduced Reduce(Environment env)
        {
            if (this.condition.Reducible())
            {
                var result = condition.Reduce(env);
                return new Reduced(new If(result.Reduce, consequence, alternative), result.Environment);
            }

            if ((bool) this.condition.Value())
            {
                return new Reduced(consequence, env);
            }
            return new Reduced(alternative, env);
        }

        public override string ToString()
            => $"if ({this.condition}) {{ {this.consequence} }} else {{ {this.alternative} }}";
    }
}