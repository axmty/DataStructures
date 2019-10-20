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

        int FindIndex(Predicate<T> match);

        int FindIndex(int startIndex, Predicate<T> match);

        int FindIndex(int startIndex, int count, Predicate<T> match);

        T FindLast(Predicate<T> match);

        int FindLastIndex(Predicate<T> match);

        int FindLastIndex(int startIndex, Predicate<T> match);

        int FindLastIndex(int startIndex, int count, Predicate<T> match);

        void ForEach(Action<T> action);

        bool InsertRange(int index, IEnumerable<T> items);

        int LastIndexOf(T item);

        int RemoveAll(Predicate<T> match);

        void RemoveRange(int index, int count);

        void Reverse();

        void Sort();

        bool TrueForAll(Predicate<T> match);
    }
}