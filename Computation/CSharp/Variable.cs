namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ReduceBase" />
    public class Variable : ReduceBase
    {
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Variable"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Variable(string name)
            => this.name = name;

        /// <inheritdoc />
        public override Reduced Reduce(Environment env)
            => new Reduced(env.Get(this.name), env);

        /// <inheritdoc />
        public override string ToString()
            => this.name;
    }
}