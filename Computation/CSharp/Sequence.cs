namespace ErraticMotion
{
    public class Sequence : SemanticBase
    {
        private readonly IReduce first;
        private readonly IReduce second;

        public Sequence(IReduce first, IReduce second)
        {
            this.first = first;
            this.second = second;
        }

        public override Reduced Reduce(Environment env)
        {
            if (this.first.GetType() == typeof(DoNothing))
            {
                return new Reduced(this.second, env);
            }

            var result = this.first.Reduce(env);
            return new Reduced(new Sequence(result.Reduce, this.second), result.Environment);
        }

        public override string ToString()
            => $"{this.first}; {this.second}";
    }
}