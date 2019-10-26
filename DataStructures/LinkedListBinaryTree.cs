using System;
using System.Collections.Generic;
using DataStructures.Interfaces;
using DataStructures.Nodes;

namespace DataStructures
{
    public class LinkedListBinaryTree<T> : IBinaryTree<T>
    {
        private BinaryTreeNode<T> _root = null;

        public void Add(T value)
        {
            var newNode = new BinaryTreeNode<T>(value);

            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                var queue = new Queue<BinaryTreeNode<T>>();

                queue.Enqueue(_root);
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

        public void BFS(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IBinaryTree<T> Copy()
        {
            throw new NotImplementedException();
        }

        public void DFS(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void InOrder(Action<T> action)
        {
            (new LinkedListBinaryTreeAlgorithms(_root)).InOrder(action);
        }

        public void PostOrder(Action<T> action)
        {
            // ---------- Recursive version
            //void rec(BinaryTreeNode<T> node)
            //{
            //    if (node == null)
            //    {
            //        return;
            //    }

            //    rec(node.Left);
            //    rec(node.Right);
            //    action(node.Value);
            //}

            //rec(_root);

            // ---------- Iterative version
            var stack1 = new Stack<BinaryTreeNode<T>>();
            var stack2 = new Stack<BinaryTreeNode<T>>();
            stack1.Push(_root);

            while (stack1.TryPop(out var node))
            {
                if (node == null)
                {
                    continue;
                }

                stack2.Push(node);
                stack1.Push(node.Left);
                stack1.Push(node.Right);
            }

            foreach (var node in stack2)
            {
                action(node.Value);
            }
        }

        public void PreOrder(Action<T> action)
        {
            (new LinkedListBinaryTreeAlgorithms(_root)).PreOrder(action);
        }

        public void Remove(T value)
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