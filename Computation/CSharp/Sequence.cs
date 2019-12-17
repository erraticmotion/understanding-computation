namespace ErraticMotion
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ErraticMotion.ReduceBase" />
    public class Sequence : ReduceBase
    {
        private readonly IReduce first;
        private readonly IReduce second;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sequence"/> class.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        public Sequence(IReduce first, IReduce second)
        {
            this.first = first;
            this.second = second;
        }

        /// <inheritdoc />
        public override Reduced Reduce(Environment env)
        {
            if (this.first.GetType() == typeof(DoNothing))
            {
                return new Reduced(this.second, env);
            }

            var result = this.first.Reduce(env);
            return new Reduced(new Sequence(result.Reduce, this.second), result.Environment);
        }

        /// <inheritdoc />
        public override string ToString()
            => $"{this.first}; {this.second}";
    }
}