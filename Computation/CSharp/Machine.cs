namespace ErraticMotion
{
    using System;
    using System.Collections.Generic;

    public class Machine
    {
        private IReduce expression;
        private Environment env;

        public Machine(IReduce expression)
            : this(expression, Environment.Empty())
        {
        }

        public Machine(IReduce expression, IEnumerable<Tuple<string, IReduce>> env)
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