using DataStructures.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class SingleLinkedList<T> : IEnumerable<T>
    {
        public SingleLinkedList()
        {
            this.Head = null;
            this.Tail = null;
        }

        private SingleNode<T> Head { get; set; }

        private SingleNode<T> Tail { get; set; }

        public void Insert(T value, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SingleLinkedListEnumerator(this.Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
