namespace ErraticMotion
{
    public abstract class SemanticBase : IReduce
    {
        public virtual bool Reducible() 
            => true;

        public virtual Reduced Reduce(Environment env)
            => null;

        public virtual object Value()
            => this.ToString();
    }
}