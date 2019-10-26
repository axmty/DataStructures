using System;
using System.Collections;
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
            //void rec(BinaryTreeNode<T> node)
            //{
            //    if (node == null)
            //    {
            //        return;
            //    }

            //    rec(node.Left);
            //    action(node.Value);
            //    rec(node.Right);
            //}

            //rec(_root);

            // ---------- Iterative version
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = _root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Pop();
                action(node.Value);
                node = node.Right;
            }
        }

        public void PostOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public void PreOrder(Action<T> action)
        {
            // ---------- Recursive version
            //void rec(BinaryTreeNode<T> node)
            //{
            //    if (node == null)
            //    {
            //        return;
            //    }

            //    action(node.Value);
            //}

            //rec(_root);

            // ---------- Iterative version
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = _root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    action(node.Value);
                    node = node.Left;
                }

                node = stack.Pop().Right;
            }
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