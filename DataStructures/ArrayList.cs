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

        /// <summary>
        /// Complexity: O(1) / O(n) if resizing.
        /// </summary>
        public void Add(T item)
        {
            this.ResizeForNewItems(1);

            _array[this.Count] = item;
            this.Count++;
        }

        /// <summary>
        /// Complexity: O(m) / O(n + m) if resizing, where m = items.Length.
        /// </summary>
        public void AddRange(IEnumerable<T> items)
        {
            this.ResizeForNewItems(items.Count());

            foreach (var item in items)
            {
                _array[this.Count] = item;
                this.Count++;
            }
        }

        /// <summary>
        /// Complexity: O(1).
        /// </summary>
        public void Clear()
        {
            this.Count = 0;
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public bool Contains(T item)
        {
            return _array[..this.Count].Contains(item);
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            else if (arrayIndex < 0 || arrayIndex >= array.Length || array.Length - arrayIndex < this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Array.Copy(_array, 0, array, arrayIndex, this.Count);
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public bool Exists(Predicate<T> match)
        {
            return _array[..this.Count].Exists(match);
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public T Find(Predicate<T> match)
        {
            return _array[..this.Count].Find(match);
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public IEnumerable<T> FindAll(Predicate<T> match)
        {
            return _array[..this.Count].FindAll(match);
        }

        public void ForEach(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _array[..this.Count].Cast<T>().GetEnumerator();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
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