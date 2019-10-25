﻿using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.Interfaces;

namespace DataStructures
{
    public class ArrayBinaryTree<T> : IBinaryTree<T>
    {
        private readonly ArrayList<T> _array = new ArrayList<T>();

        public void Add(T value)
        {
            _array.Add(value);
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
            void rec(int index)
            {
                if (index >= _array.Count)
                {
                    return;
                }

                rec(2 * index + 1);
                action(_array[index]);
                rec(2 * index + 2);
            }

            rec(0);
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