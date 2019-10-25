using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Interfaces;

namespace DataStructures
{
    public class ArrayBinaryTree<T> : IBinaryTree<T>
    {
        public void Add(T value)
        {
            throw new NotImplementedException();
        }

        public IBinaryTree<T> Copy()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void InOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void PostOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void PreOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void Remove(T value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}