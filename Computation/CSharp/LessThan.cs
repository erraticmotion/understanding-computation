namespace ErraticMotion
{
    public class LessThan : SemanticBase
    {
        private readonly IReduce left;
        private readonly IReduce right;

        public LessThan(IReduce left, IReduce right)
        {
            this.left = left;
            this.right = right;
        }

        public override Reduced Reduce(Environment env)
        {
            if (this.left.Reducible())
            {
                var result = this.left.Reduce(env);
                return new Reduced(new LessThan(result.Reduce, this.right), result.Environment);
            }

            if (this.right.Reducible())
            {
                var result = this.right.Reduce(env);
                return new Reduced(new LessThan(this.left, result.Reduce), result.Environment);
            }

            return new Reduced(new Boolean((int)this.left.Value() < (int)this.right.Value()), env);
        }

        public override string ToString()
            => $"{this.left} < {this.right}";
    }
}