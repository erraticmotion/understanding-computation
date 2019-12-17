namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IReduce" />
    public class DoNothing : IReduce
    {
        /// <inheritdoc />
        public bool Reducible()
            => false;

        /// <inheritdoc />
        public Reduced Reduce(Environment env)
            => throw new System.NotSupportedException();

        /// <inheritdoc />
        public object Value()
            => "do-nothing";

        /// <inheritdoc />
        public override string ToString()
            => this.Value().ToString();
    }
}