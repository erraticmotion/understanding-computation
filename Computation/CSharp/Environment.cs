namespace ErraticMotion
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using E = System.Tuple<string, IReduce>;

    public class Environment : IEnumerable<Tuple<string, IReduce>>
    {
        public static Environment Empty() => new Environment(new List<E>());

        private readonly List<E> collection;

        public Environment(IEnumerable<E> collection)
            => this.collection = new List<E>(collection);

        public Environment(params E[] values)
            : this(new List<E>(values))
        {
        }

        public IReduce Get(string key)
            => this.collection.Single(x => x.Item1 == key).Item2;

        public Environment Changed(string key, IReduce change)
            =>  new Environment(this.collection.Select(
                x => x.Item1 != key 
                ? x 
                : new E(key, change)).ToList());

        public IEnumerator<Tuple<string, IReduce>> GetEnumerator()
            => this.collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{ ");
            foreach (var (key, reduce) in collection)
            {
                builder.Append($":{key}=>{reduce},");
            }

            var result = builder.ToString();
            return result.TrimEnd(',') + " }";
        }
    }
}