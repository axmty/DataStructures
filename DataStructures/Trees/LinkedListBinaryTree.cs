using System;
using System.Collections.Generic;
using DataStructures.Nodes;

namespace DataStructures.Trees
{
    public class LinkedListBinaryTree<T> : IBinaryTree<T>
    {
        protected BinaryTreeNode<T> Root { get; private set; } = null;

        private LinkedListBinaryTreeAlgorithms Algorithms => new LinkedListBinaryTreeAlgorithms(Root);

        public virtual void Add(T value)
        {
            var newNode = new BinaryTreeNode<T>(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                var queue = new Queue<BinaryTreeNode<T>>();

                queue.Enqueue(Root);
                while (queue.TryDequeue(out var node))
                {
                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        break;
                    }
                    else if (node.Right == null)
                    {
                        node.Right = newNode;
                        break;
                    }
                    else
                    {
                        queue.Enqueue(node.Left);
                        queue.Enqueue(node.Right);
                    }
                }
            }
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

        public virtual void Remove(T value)
        {
            throw new NotImplementedException();
        }

        private class LinkedListBinaryTreeAlgorithms : BaseBinaryTreeAlgorithms<T, BinaryTreeNode<T>>
        {
            private readonly BinaryTreeNode<T> _root;

            public LinkedListBinaryTreeAlgorithms(BinaryTreeNode<T> root)
            {
                _root = root;
            }

            protected override BinaryTreeNode<T> GetLeft(BinaryTreeNode<T> node) => node.Left;

            protected override BinaryTreeNode<T> GetRight(BinaryTreeNode<T> node) => node.Right;

            protected override BinaryTreeNode<T> GetRoot() => _root;

            protected override T GetValue(BinaryTreeNode<T> node) => node.Value;

            protected override bool IsEmptyNode(BinaryTreeNode<T> node) => node == null;
        }
    }
}