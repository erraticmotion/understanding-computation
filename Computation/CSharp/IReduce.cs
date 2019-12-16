namespace ErraticMotion
{
    public interface IReduce
    {
        bool Reducible();

        Reduced Reduce(Environment env);

        object Value();
    }
}