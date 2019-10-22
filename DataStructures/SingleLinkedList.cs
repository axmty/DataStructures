using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Nodes;

namespace DataStructures
{
    public class SingleLinkedList<T> : Interfaces.IList<T>
    {
        private SingleNode<T> _head;
        private SingleNode<T> _tail;

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => this.ReachNode(index).Value;
            set => this.ReachNode(index).Value = value;
        }

        /// <summary>
        /// Complexity: O(1).
        /// </summary>
        public void Add(T item)
        {
            var newNode = new SingleNode<T>(item);

            if (_tail == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = _tail.Next;
            }

            this.Count++;
        }

        /// <summary>
        /// Complexity: O(m), where m = items.Length.
        /// </summary>
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Complexity: O(1).
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            this.Count = 0;
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public bool Contains(T item)
        {
            Func<T, bool> compare;

            if (item == null)
            {
                compare = x => x == null;
            }
            else
            {
                var equalityComparer = EqualityComparer<T>.Default;
                compare = x => equalityComparer.Equals(x, item);
            }

            for (var node = _head; node != null; node = node.Next)
            {
                if (compare(node.Value))
                {
                    return true;
                }
            }

            return false;
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

            var node = _head;
            var index = arrayIndex;

            while (node != null)
            {
                array[index] = node.Value;
                index++;
                node = node.Next;
            }
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public bool Exists(Predicate<T> match)
        {
            var node = _head;

            while (node != null && !match(node.Value))
            {
                node = node.Next;
            }

            return node != null;
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public T Find(Predicate<T> match)
        {
            var node = _head;

            while (node != null && !match(node.Value))
            {
                node = node.Next;
            }

            return node != null ? node.Value : default;
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public IEnumerable<T> FindAll(Predicate<T> match)
        {
            var result = new SingleLinkedList<T>();
            var node = _head;

            while (node != null)
            {
                if (match(node.Value))
                {
                    result.Add(node.Value);
                }

                node = node.Next;
            }

            return result;
        }

        public void ForEach(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SingleLinkedListEnumerator(_head);
        }

        public int IndexOf(T item)
        {
            var index = 0;
            var node = _head;

            while (node != null && !node.Value.Equals(item))
            {
                index++;
                node = node.Next;
            }

            return node == null ? -1 : index;
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
            return this.GetEnumerator();
        }

        private int FindIndex(int startIndex, SingleNode<T> startNode, Predicate<T> match)
        {
            var node = startNode;
            var index = startIndex;

            while (node != null && !match(node.Value))
            {
                node = node.Next;
                index++;
            }

            return node != null ? index : -1;
        }

        private SingleNode<T> ReachNode(int index)
        {
            var node = _head;
            var currentIndex = 0;

            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            while (node != null && currentIndex < index)
            {
                node = node.Next;
                currentIndex++;
            }

            if (node == null)
            {
                throw new IndexOutOfRangeException();
            }

            return node;
        }

        private class SingleLinkedListEnumerator : IEnumerator<T>
        {
            private readonly SingleNode<T> _startNode;
            private SingleNode<T> _currentNode;

            public SingleLinkedListEnumerator(SingleNode<T> startNode)
            {
                _startNode = startNode;
            }

            public T Current { get; private set; }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                _currentNode = _currentNode == null ? _startNode : _currentNode.Next;

                if (_currentNode == null)
                {
                    return false;
                }
                else
                {
                    this.Current = _currentNode.Value;
                    return true;
                }
            }

            public void Reset()
            {
                _currentNode = null;
            }
        }
    }
}