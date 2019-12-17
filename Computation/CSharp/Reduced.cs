namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    public class Reduced
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reduced"/> class.
        /// </summary>
        /// <param name="reduce">The reduce.</param>
        private Reduced(IReduce reduce) 
            => this.Reduce = reduce;

        /// <summary>
        /// Initializes a new instance of the <see cref="Reduced"/> class.
        /// </summary>
        /// <param name="reduce">The reduce.</param>
        /// <param name="env">The env.</param>
        public Reduced(IReduce reduce, Environment env)
            : this(reduce)
            => this.Environment = env;

        public IReduce Reduce { get; }

        public Environment Environment { get; }

        /// <inheritdoc />
        public override string ToString()
            => $"{this.Reduce}, {this.Environment}";
    }
}