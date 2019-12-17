namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IReduce" />
    public class Boolean : IReduce
    {
        private readonly bool value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Boolean"/> class.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public Boolean(bool value)
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