using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class ArrayList<T> : Interfaces.IList<T>
    {
        private T[] _array = new T[0];

        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public T Find(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public SingleLinkedList<T> FindAll(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public int FindIndex(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public T FindLast(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public int FindLastIndex(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public int FindLastIndex(int startIndex, Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public int FindLastIndex(int startIndex, int count, Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public void ForEach(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool InsertRange(int index, IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public int LastIndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int RemoveAll(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(int index, int count)
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public bool TrueForAll(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
