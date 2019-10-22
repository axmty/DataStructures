﻿using System;
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

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public int FindIndex(Predicate<T> match)
        {
            return this.FindIndex(0, _head, match);
        }

        /// <summary>
        /// Complexity: O(n).
        /// </summary>
        public int FindIndex(int startIndex, Predicate<T> match)
        {
            if (startIndex < 0 || startIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.FindIndex(startIndex, this.ReachNode(startIndex), match);
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
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (index == this.Count)
            {
                this.Add(item);
            }
            else if (index == 0)
            {
                _head = new SingleNode<T>(item, _head);
            }
            else
            {
                var node = _head;

                for (var currentIndex = 0; currentIndex < index - 1; currentIndex++)
                {
                    node = node.Next;
                }

                node.Next = new SingleNode<T>(item, node.Next);
            }
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
            SingleNode<T> previousNode = null;
            var currentNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (previousNode == null)
                    {
                        _head = _head.Next;
                    }
                    else
                    {
                        previousNode.Next = currentNode.Next;

                        if (previousNode.Next == null)
                        {
                            _tail = previousNode;
                        }
                    }

                    return true;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

        public int RemoveAll(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            SingleNode<T> previousNode = null;
            var currentNode = _head;

            for (int i = 0; i < index; i++)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (previousNode == null)
            {
                _head = _head.Next;
            }
            else
            {
                previousNode.Next = currentNode.Next;

                if (previousNode.Next == null)
                {
                    _tail = previousNode;
                }
            }
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