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
