namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    public class Result
    {
        private readonly object expressionResult;
        private readonly Environment env = Environment.Empty();

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="expressionResult">The expression result.</param>
        private Result(object expressionResult)
            => this.expressionResult = expressionResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="environment">The environment.</param>
        public Result(object expression, Environment environment)
            : this(expression)
            => this.env = environment;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object ExpressionResult()
            => this.expressionResult;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object State(string key)
            => this.env.Get(key).Value();

        /// <inheritdoc />
        public override string ToString()
            => $"Result: {this.expressionResult}, {this.env}";
    }
}