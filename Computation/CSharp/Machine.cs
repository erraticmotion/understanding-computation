namespace ErraticMotion
{
    using System;
    using E = System.Tuple<string, IReduce>;

    public class Machine
    {
        public static void Run(IReduce item)
            => new Machine(item).Run();

        public static void Run(IReduce item, Environment env)
            => new Machine(item, env).Run();

        public static void Run(Tuple<IReduce, Environment> item)
            => Run(item.Item1, item.Item2);

        public static void Run(IReduce item, params E[] env)
            => new Machine(item, new Environment(env)).Run();

        private IReduce expression;
        private Environment env;

        public Machine(IReduce expression)
            : this(expression, Environment.Empty())
        {
        }

        public Machine(IReduce expression, params E[] env)
            : this(expression, new Environment(env))
        {
        }

        public Machine(IReduce expression, Environment env)
        {
            this.expression = expression;
            this.env = env;
        } 

        public void Run()
        {
            while (this.expression.Reducible())
            {
                Console.WriteLine($"{this.expression}, {this.env}");
                var result = this.expression.Reduce(this.env);
                this.expression = result.Reduce;
                this.env = result.Environment;
            }

            Console.WriteLine($"{this.expression}, {this.env}");
        }
    }
}