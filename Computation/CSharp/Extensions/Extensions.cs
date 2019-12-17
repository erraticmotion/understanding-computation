namespace ErraticMotion.Extensions
{
    using E = System.Tuple<string, IReduce>;

    public static class Extensions
    {
        public static IReduce IsVariable(this string target)
            => new Variable(target);

        public static IReduce IsNumber(this int target)
            => new Number(target);

        public static IReduce IsBoolean(this bool target)
            => new Boolean(target);

        public static IReduce LessThan(this int left, IReduce right)
            => new LessThan(new Number(left), right);

        public static IReduce LessThan(this string target, int n)
            => new LessThan(target.IsVariable(), n.IsNumber());

        public static IReduce Assign(this string target, int n)
            => Assign(target, n.IsNumber());

        public static IReduce Assign(this string target, IReduce reduce)
            => new Assign(target, reduce);

        public static IReduce Add(this int target, int n)
            => new Add(target.IsNumber(), n.IsNumber());

        public static IReduce Add(this string target, int n)
            => new Add(target.IsVariable(), n.IsNumber());

        public static IReduce Multiply(this int target, int n)
            => new Multiply(target, n);

        public static IReduce Multiply(this string target, int n)
            => new Multiply(new Variable(target), new Number(n));

        public static IReduce DoesNothing(this string target)
            => new Assign(target, new DoNothing());

        public static IThen If(this string target)
            => new IfThenElse(target);

        public static E Is(this string target, int n)
            => new E(target, n.IsNumber());

        public static E Is(this string target, bool value)
            => new E(target, value.IsBoolean());
    }
}