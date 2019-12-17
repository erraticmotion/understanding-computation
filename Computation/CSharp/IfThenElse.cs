namespace ErraticMotion
{
    using Extensions;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IThen" />
    /// <seealso cref="IElse" />
    public class IfThenElse : IThen, IElse
    {
        private readonly string target;
        private IReduce consequence;

        /// <summary>
        /// Initializes a new instance of the <see cref="IfThenElse"/> class.
        /// </summary>
        /// <param name="target">The target.</param>
        public IfThenElse(string target)
            => this.target = target;

        /// <inheritdoc />
        public IElse Then(IReduce item)
        {
            this.consequence = item;
            return this;
        }

        /// <inheritdoc />
        public IReduce Else(IReduce alternative)
            => new If(target.IsVariable(), consequence, alternative);
    }
}