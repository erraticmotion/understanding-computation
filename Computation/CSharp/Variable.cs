namespace ErraticMotion
{
    public class Variable : SemanticBase
    {
        private readonly string name;

        public Variable(string name)
            => this.name = name;

        public override Reduced Reduce(Environment env)
            => new Reduced(env.Get(this.name), env);

        public override string ToString()
            => this.name;
    }
}