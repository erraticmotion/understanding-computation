namespace ErraticMotion
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

        public static IReduce Assign(this string target, int n)
            => Assign(target, n.IsNumber());

        public static IReduce Assign(this string target, IReduce reduce)
            => new Assign(target, reduce);

        public static IReduce Add(this string target, int number)
            => new Assign(target, Builders.Add(target, number));

        public static IReduce DoesNothing(this string target)
            => new Assign(target, new DoNothing());

        public static IThen If(
            this string target)
            => new IfThenElse(target);

        public static E Is(this string target, int n)
            => new E(target, n.IsNumber());

        public static E Is(this string target, bool value)
            => new E(target, value.IsBoolean());

        private class IfThenElse : IThen, IElse
        {
            private readonly string target;
            private IReduce consequence;

            public IfThenElse(string target)
                => this.target = target;

            public IElse Then(IReduce item)
            {
                this.consequence = item;
                return this;
            }

            public IReduce Else(IReduce alternative)
                => new If(target.IsVariable(), consequence, alternative);
        }
    }

    public interface IThen
    {
        IElse Then(IReduce consequence);
    }

    public interface IElse
    {
        IReduce Else(IReduce alternative);
    }

    
}