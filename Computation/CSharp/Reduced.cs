namespace ErraticMotion
{
    public class Reduced
    {
        private Reduced(IReduce reduce) 
            => this.Reduce = reduce;

        public Reduced(IReduce reduce, Environment env)
            : this(reduce)
            => this.Environment = env;

        public IReduce Reduce { get; }

        public Environment Environment { get; }

        public override string ToString()
            => $"{this.Reduce}, {this.Environment}";
    }
}