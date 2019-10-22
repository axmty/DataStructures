using System;
using System.Collections.Generic;

namespace DataStructures.Interfaces
{
    public interface IList<T> : System.Collections.Generic.IList<T>
    {
        void AddRange(IEnumerable<T> items);

        bool Exists(Predicate<T> match);

        T Find(Predicate<T> match);

        IEnumerable<T> FindAll(Predicate<T> match);

        void ForEach(Action<T> action);
    }
}