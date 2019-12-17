namespace ErraticMotion
{
    /// <summary>
    /// Acts as a base class for reducible syntax elements
    /// </summary>
    public abstract class ReduceBase : IReduce
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Reducible() 
            => true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public abstract Reduced Reduce(Environment env);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual object Value()
            => this.ToString();
    }
}