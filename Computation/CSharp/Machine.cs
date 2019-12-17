namespace ErraticMotion
{
    using System;
    using E = System.Tuple<string, IReduce>;

    public class Machine
    {
        public static Result Run(IReduce item)
            => new Machine(item).Run();

        public static Result Run(IReduce item, Environment env)
            => new Machine(item, env).Run();

        public static Result Run(Tuple<IReduce, Environment> item)
            => Run(item.Item1, item.Item2);

        public static Result Run(IReduce item, params E[] env)
            => new Machine(item, new Environment(env)).Run();

        private IReduce expression;
        private Environment env = Environment.Empty();

        private Machine(IReduce expression)
            => this.expression = expression;

        private Machine(IReduce expression, Environment env)
            : this(expression)
            => this.env = env;

        public Result Run()
        {
            while (this.expression.Reducible())
            {
                Console.WriteLine($"Reduce: {this.expression}, {this.env}");
                var reduced = this.expression.Reduce(this.env);
                this.expression = reduced.Reduce;
                this.env = reduced.Environment;
            }

            var result = new Result(this.expression.Value(), this.env);
            Console.WriteLine(result);
            return result;
        }
    }
}