namespace ErraticMotion
{
    public abstract class SemanticBase : IReduce
    {
        private readonly bool reducible;

        protected SemanticBase()
            : this(true)
        {
        }

        protected SemanticBase(bool reducible)
            => this.reducible = reducible;

        public bool Reducible() 
            => this.reducible;

        public virtual Reduced Reduce(Environment env)
            => null;

        public virtual object Value()
            => this.ToString();
    }
}