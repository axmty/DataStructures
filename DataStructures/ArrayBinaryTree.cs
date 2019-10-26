using System;
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

        public void InOrder(Action<T> action)
        {
            (new ArrayBinaryTreeAlgorithms(_array)).InOrder(action);
        }

        public void PostOrder(Action<T> action)
        {
            // ---------- Recursive version
            //void rec(int index)
            //{
            //    if (index >= _array.Count)
            //    {
            //        return;
            //    }

            //    rec(index * 2 + 1);
            //    rec(index * 2 + 2);
            //    action(_array[index]);
            //}

            //rec(0);

            // ---------- Iterative version
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();

            stack1.Push(0);

            while (stack1.TryPop(out var index))
            {
                if (index >= _array.Count)
                {
                    continue;
                }

                stack2.Push(index);
                stack1.Push(index * 2 + 1);
                stack1.Push(index * 2 + 2);
            }

            foreach (var index in stack2)
            {
                action(_array[index]);
            }
        }

        public void PreOrder(Action<T> action)
        {
            (new ArrayBinaryTreeAlgorithms(_array)).PreOrder(action);
        }

        public void Remove(T value)
        {
            throw new NotImplementedException();
        }

        private class ArrayBinaryTreeAlgorithms : BaseBinaryTreeAlgorithms<T, int>
        {
            private readonly ArrayList<T> _array;

            public ArrayBinaryTreeAlgorithms(ArrayList<T> array)
            {
                _array = array;
            }

            protected override int GetLeft(int node) => node * 2 + 1;

            protected override int GetRight(int node) => node * 2 + 2;

            protected override int GetRoot() => 0;

            protected override T GetValue(int node) => _array[node];

            protected override bool IsEmptyNode(int node) => node >= _array.Count;
        }
    }
}