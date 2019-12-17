namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ErraticMotion.ReduceBase" />
    public class LessThan : ReduceBase
    {
        private readonly IReduce left;
        private readonly IReduce right;

        /// <summary>
        /// Initializes a new instance of the <see cref="LessThan"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public LessThan(IReduce left, IReduce right)
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
                return new Reduced(new LessThan(result.Reduce, this.right), result.Environment);
            }

            if (this.right.Reducible())
            {
                var result = this.right.Reduce(env);
                return new Reduced(new LessThan(this.left, result.Reduce), result.Environment);
            }

            return new Reduced(new Boolean((int)this.left.Value() < (int)this.right.Value()), env);
        }

        /// <inheritdoc />
        public override string ToString()
            => $"{this.left} < {this.right}";
    }
}