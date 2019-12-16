namespace ErraticMotion
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            new Machine(
                new Add(
                    new Multiply(new Number(1), new Number(2)), 
                    new Multiply(new Number(3), new Number(4))))
                .Run();

            new Machine(
                    new LessThan(
                        new Number(5), 
                        new Add(new Number(2), new Number(2))))
                .Run();

            new Machine(
                new Add(new Variable("x"), new Variable("y")),
                new List<Tuple<string, IReduce>>
                {
                    new Tuple<string, IReduce>("x", new Number(3)),
                    new Tuple<string, IReduce>("y", new Number(4))
                }
                ).Run();

            new Machine(
                new Assign("x", new Add(new Variable("x"), new Number(1))),
                new Environment(new List<Tuple<string, IReduce>>
                {
                    new Tuple<string, IReduce>("x", new Number(2))
                })
                ).Run();


            Console.ReadLine();
        }
    }
}
