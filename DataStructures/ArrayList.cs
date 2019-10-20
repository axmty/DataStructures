using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Extensions;

namespace DataStructures
{
    public class ArrayList<T> : Interfaces.IList<T>
    {
        private T[] _array = new T[0];

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        private int Capacity => _array.Length;

        public T this[int index]
        {
            get => index < this.Count ? _array[index] : throw new IndexOutOfRangeException();

            set
            {
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public void Add(T item)
        {
            this.ResizeForNewItems(1);

            _array[this.Count] = item;
            this.Count++;
        }

        public void AddRange(IEnumerable<T> items)
        {
            this.ResizeForNewItems(items.Count());

            foreach (var item in items)
            {
                _array[this.Count] = item;
                this.Count++;
            }
        }

        public void Clear()
        {
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            return _array[..this.Count].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_array, 0, array, arrayIndex, this.Count);
        }

        public bool Exists(Predicate<T> match)
        {
            return _array[..this.Count].Exists(match);
        }

        public T Find(Predicate<T> match)
        {
            return _array[..this.Count].Find(match);
        }

        public IEnumerable<T> FindAll(Predicate<T> match)
        {
            return _array[..this.Count].FindAll(match);
        }

        public int FindIndex(Predicate<T> match)
        {
            return _array[..this.Count].FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<T> match)
        {
            if (startIndex < 0 || startIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _array[startIndex..this.Count].FindIndex(match);
        }

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex < 0 || count < 1 || count + startIndex > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _array[startIndex..(startIndex + count)].FindIndex(match);
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
            foreach (var item in _array[..this.Count])
            {
                action(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _array[..this.Count].Cast<T>().GetEnumerator();
        }

        public int IndexOf(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            return _array[..this.Count].FindIndex(x => item.Equals(x));
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
            return _array[..this.Count].GetEnumerator();
        }

        private void ResizeForNewItems(int numberToAdd)
        {
            var requiredSize = this.Count + numberToAdd;
            var newSize = Math.Max(1, this.Capacity);

            while (requiredSize > newSize)
            {
                newSize <<= 1;
            }

            if (newSize != this.Capacity)
            {
                var newArray = new T[newSize];

                Array.Copy(_array, newArray, this.Count);
                _array = newArray;
            }
        }
    }
}