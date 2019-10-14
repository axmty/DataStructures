using DataStructures.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class SingleLinkedList<T> : IList<T>
    {
        private SingleNode<T> _head;
        private SingleNode<T> _tail;

        public T this[int index]
        {
            get => this.ReachNode(index).Value;
            set => this.ReachNode(index).Value = value;
        }

        public int Count
        {
            get
            {
                var node = _head;
                var count = 0;

                while (node != null)
                {
                    count++;
                    node = node.Next;
                }

                return count;
            }
        }

        public bool IsReadOnly => false;

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
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
        }

        public bool Contains(T item)
        {
            for (var node = _head; node != null; node = node.Next)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (array.Length - arrayIndex < this.Count)
            {
                throw new ArgumentException();
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

        public IEnumerator<T> GetEnumerator()
        {
            return new SingleLinkedListEnumerator(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private SingleNode<T> ReachNode(int index)
        {
            var node = _head;
            var currentIndex = 0;

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

            public void Dispose() { }

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
