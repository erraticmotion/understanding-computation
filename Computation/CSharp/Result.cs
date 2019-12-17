namespace ErraticMotion
{
    public class Result
    {
        private readonly object expressionResult;
        private readonly Environment env = Environment.Empty();

        public Result(object expressionResult)
            => this.expressionResult = expressionResult;

        public Result(object expression, Environment environment)
            : this(expression)
            => this.env = environment;

        public object ExpressionResult()
            => this.expressionResult;

        public object State(string key)
            => this.env.Get(key).Value();

        public override string ToString()
            => $"Result: {this.expressionResult}, {this.env}";
    }
}