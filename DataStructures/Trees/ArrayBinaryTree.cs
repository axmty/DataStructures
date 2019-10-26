using System;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    public class ArrayBinaryTree<T> : IBinaryTree<T>
    {
        private readonly List<T> _array = new List<T>();

        private ArrayBinaryTreeAlgorithms Algorithms => new ArrayBinaryTreeAlgorithms(_array);

        public void Add(T value)
        {
            _array.Add(value);
        }

        public void Bfs(Action<T> action)
        {
            this.Algorithms.Bfs(action);
        }

        public IBinaryTree<T> Copy()
        {
            throw new NotImplementedException();
        }

        public void InOrder(Action<T> action)
        {
            this.Algorithms.InOrder(action);
        }

        public void PostOrder(Action<T> action)
        {
            this.Algorithms.PostOrder(action);
        }

        public void PreOrder(Action<T> action)
        {
            this.Algorithms.PreOrder(action);
        }

        public void Remove(T value)
        {
            throw new NotImplementedException();
        }

        private class ArrayBinaryTreeAlgorithms : BaseBinaryTreeAlgorithms<T, int>
        {
            private readonly List<T> _array;

            public ArrayBinaryTreeAlgorithms(List<T> array)
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