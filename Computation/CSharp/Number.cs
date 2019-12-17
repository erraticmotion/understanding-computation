namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IReduce" />
    public class Number : IReduce
    {
        private readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Number"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Number(int value)
            => this.value = value;

        /// <inheritdoc />
        public bool Reducible()
            => false;

        /// <inheritdoc />
        public Reduced Reduce(Environment env)
            => throw new System.NotSupportedException();

        /// <inheritdoc />
        public object Value()
            => this.value;

        /// <inheritdoc />
        public override string ToString()
            => this.value.ToString();
    }
}