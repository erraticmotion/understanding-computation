namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ErraticMotion.ReduceBase" />
    public class Assign : ReduceBase
    {
        private readonly string name;
        private readonly IReduce expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="Assign"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="expression">The expression.</param>
        public Assign(string name, IReduce expression)
        {
            this.name = name;
            this.expression = expression;
        }

        /// <inheritdoc />
        public override Reduced Reduce(Environment env)
        {
            if (this.expression.Reducible())
            {
                var result = this.expression.Reduce(env);
                return new Reduced(new Assign(this.name, result.Reduce), result.Environment);
            }

            return new Reduced(new DoNothing(), env.Changed(this.name, this.expression));
        }

        /// <inheritdoc />
        public override string ToString()
            => $"{this.name} = {this.expression}";
    }
}