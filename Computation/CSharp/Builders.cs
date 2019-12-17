namespace ErraticMotion
{
    using System;
    using System.Collections.Generic;
    using E = System.Tuple<string, IReduce>;

    public static class Builders
    {
        public static IReduce Multiply(int left, int right)
            => new Multiply(left, right);

        public static IReduce Add(int left, int right)
            => Add(left.IsNumber(), right.IsNumber());

        public static IReduce Add(string variable, int value)
            => Add(variable.IsVariable(), value.IsNumber());

        public static IReduce Add(IReduce left, IReduce right)
            => new Add(left, right);

        public static Tuple<IReduce, Environment> Add(E left, E right)
            => new Tuple<IReduce, Environment>(
                new Add(new Variable(left.Item1), 
                    new Variable(right.Item1)), 
                new Environment(new List<E> {left, right}));
    }
}