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
            // ---------- Recursive version
            //void rec(int index)
            //{
            //    if (index >= _array.Count)
            //    {
            //        return;
            //    }

            //    rec(2 * index + 1);
            //    action(_array[index]);
            //    rec(2 * index + 2);
            //}

            //rec(0);

            // ---------- Iterative version
            var stack = new Stack<int>();
            var index = 0;

            while (index < _array.Count || stack.Count > 0)
            {
                while (index < _array.Count)
                {
                    stack.Push(index);
                    index = index * 2 + 1;
                }

                index = stack.Pop();
                action(_array[index]);
                index = index * 2 + 2;
            }
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
            // ---------- Recursive version
            //void rec(int index)
            //{
            //    if (index >= _array.Count)
            //    {
            //        return;
            //    }

            //    action(_array[index]);
            //    rec(2 * index + 1);
            //    rec(2 * index + 2);
            //}

            //rec(0);

            // ---------- Iterative version
            var stack = new Stack<int>();
            var index = 0;

            while (index < _array.Count || stack.Count > 0)
            {
                while (index < _array.Count)
                {
                    stack.Push(index);
                    action(_array[index]);
                    index = index * 2 + 1;
                }

                index = stack.Pop() * 2 + 2;
            }
        }

        public void Remove(T value)
        {
            throw new NotImplementedException();
        }
    }
}