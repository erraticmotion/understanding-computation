namespace ErraticMotion
{
    public class Add : SemanticBase
    {
        private readonly IReduce left;
        private readonly IReduce right;

        //public Add(int left, int right)
        //    : this(new Number(left), new Number(right))
        //{
        //}

        public Add(IReduce left, IReduce right)
        {
            this.left = left;
            this.right = right;
        }

        public override Reduced Reduce(Environment env)
        {
            if (this.left.Reducible())
            {
                var result = this.left.Reduce(env);
                return new Reduced(new Add(result.Reduce, this.right), result.Environment);
            }


            if (this.right.Reducible())
            {
                var result = this.right.Reduce(env);
                return new Reduced(new Add(this.left, result.Reduce), result.Environment);
            }

            return new Reduced(new Number((int)this.left.Value() + (int)this.right.Value()), env);
        }

        public override string ToString()
            => $"{this.left} + {this.right}";
    }
}