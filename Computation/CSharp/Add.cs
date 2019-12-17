namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ReduceBase" />
    public class Add : ReduceBase
    {
        private readonly IReduce left;
        private readonly IReduce right;

        /// <summary>
        /// Initializes a new instance of the <see cref="Add"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public Add(IReduce left, IReduce right)
        {
            this.left = left;
            this.right = right;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public override string ToString()
            => $"{this.left} + {this.right}";
    }
}