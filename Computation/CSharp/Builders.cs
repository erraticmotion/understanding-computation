namespace ErraticMotion
{
    using System;
    using System.Collections.Generic;
    using E = System.Tuple<string, IReduce>;

    public static class Builders
    {
        public static IReduce Add(IReduce left, IReduce right)
            => new Add(left, right);

        public static Tuple<IReduce, Environment> Add(E left, E right)
            => new Tuple<IReduce, Environment>(
                new Add(new Variable(left.Item1),
                    new Variable(right.Item1)),
                new Environment(new List<E> { left, right }));

        public static IReduce Sequence(IReduce first, IReduce second)
            => new Sequence(first, second);

        public static IReduce While(IReduce condition, IReduce body)
            => new While(condition, body);
    }
}