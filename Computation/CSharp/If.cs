namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ErraticMotion.ReduceBase" />
    public class If : ReduceBase
    {
        private readonly IReduce condition;
        private readonly IReduce consequence;
        private readonly IReduce alternative;

        /// <summary>
        /// Initializes a new instance of the <see cref="If"/> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="consequence">The consequence.</param>
        /// <param name="alternative">The alternative.</param>
        public If(
            IReduce condition, 
            IReduce consequence, 
            IReduce alternative)
        {
            this.condition = condition;
            this.consequence = consequence;
            this.alternative = alternative;
        }

        /// <inheritdoc />
        public override Reduced Reduce(Environment env)
        {
            if (this.condition.Reducible())
            {
                var result = condition.Reduce(env);
                return new Reduced(new If(result.Reduce, consequence, alternative), result.Environment);
            }

            if ((bool) this.condition.Value())
            {
                return new Reduced(consequence, env);
            }

            return new Reduced(alternative, env);
        }

        /// <inheritdoc />
        public override string ToString()
            => $"if ({this.condition}) {{ {this.consequence} }} else {{ {this.alternative} }}";
    }
}