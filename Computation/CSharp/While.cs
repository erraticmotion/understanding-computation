namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ReduceBase" />
    public class While : ReduceBase
    {
        private readonly IReduce condition;
        private readonly IReduce body;

        /// <summary>
        /// Initializes a new instance of the <see cref="While"/> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="body">The body.</param>
        public While(IReduce condition, IReduce body)
        {
            this.condition = condition;
            this.body = body;
        }

        /// <inheritdoc />
        public override Reduced Reduce(Environment env)
            => new Reduced(new If(this.condition, new Sequence(this.body, this), new DoNothing()), env);

        /// <inheritdoc />
        public override string ToString()
            => $"while ( {this.condition} ) {{ {this.body} }}";
    }
}