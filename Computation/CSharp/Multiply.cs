namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ReduceBase" />
    public class Multiply : ReduceBase
    {
        private readonly IReduce left;
        private readonly IReduce right;

        /// <summary>
        /// Initializes a new instance of the <see cref="Multiply"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public Multiply(int left, int right)
            : this(new Number(left), new Number(right))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Multiply"/> class.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public Multiply(IReduce left, IReduce right)
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
                return new Reduced(new Multiply(result.Reduce, this.right), result.Environment);
            }

            if (this.right.Reducible())
            {
                var result = this.right.Reduce(env);
                return new Reduced(new Multiply(this.left, result.Reduce), result.Environment);
            }

            return new Reduced(new Number((int) this.left.Value() * (int) this.right.Value()), env);
        }

        /// <inheritdoc />
        public override string ToString()
            => $"{this.left} * {this.right}";
    }
}