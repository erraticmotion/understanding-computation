namespace ErraticMotion
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Environment : IEnumerable<Tuple<string, IReduce>>
    {
        public static Environment Empty() => new Environment(new List<Tuple<string, IReduce>>());

        private readonly List<Tuple<string, IReduce>> collection;

        public Environment(IEnumerable<Tuple<string, IReduce>> collection)
            => this.collection = new List<Tuple<string, IReduce>>(collection);

        public IReduce Get(string key)
            => this.collection.Single(x => x.Item1 == key).Item2;

        public Environment Changed(string key, IReduce change)
        {
            var result = new List<Tuple<string, IReduce>>();
            foreach (var item in this.collection)
            {
                if (item.Item1 != key)
                {
                    result.Add(item);
                }
                else
                {
                    result.Add(new Tuple<string, IReduce>(key, change));
                }
            }
            return new Environment(result);
        }

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