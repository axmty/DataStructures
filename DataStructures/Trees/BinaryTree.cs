using System;
using System.Collections.Generic;
using DataStructures.Nodes;

namespace DataStructures.Trees
{
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; } = null;

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
            // ---------- Recursive version
            //var queue = new Queue<T>();
            //queue.Enqueue(this.Root);
            //void rec()
            //{
            //    if (!queue.TryDequeue(out var node) || node == null)
            //    {
            //        return;
            //    }
            //    action(node.Value);
            //    queue.Enqueue(node.Left);
            //    queue.Enqueue(node.Right);
            //    rec();
            //}
            //rec();

            // ---------- Iterative version
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(this.Root);

            while (queue.TryDequeue(out var node))
            {
                if (node == null)
                {
                    continue;
                }

                action(node.Value);
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }
        }

        public void InOrder(Action<T> action)
        {
            // ---------- Recursive version
            //void rec(T node)
            //{
            //    if (node == null)
            //    {
            //        return;
            //    }
            //    rec(node.Left);
            //    action(node.Value);
            //    rec(node.Right);
            //}
            //rec(this.Root);

            // ---------- Iterative version
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = this.Root;

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
            // ---------- Recursive version
            //void rec(T node)
            //{
            //    if (node == null)
            //    {
            //        return;
            //    }
            //    rec(node.Left);
            //    rec(node.Right);
            //    action(node.Value);
            //}
            //rec(this.Root);

            // ---------- Iterative version
            var traversalStack = new Stack<BinaryTreeNode<T>>();
            var reversedPostOrderStack = new Stack<BinaryTreeNode<T>>();

            traversalStack.Push(this.Root);

            while (traversalStack.TryPop(out var node))
            {
                if (node == null)
                {
                    continue;
                }

                reversedPostOrderStack.Push(node);
                traversalStack.Push(node.Left);
                traversalStack.Push(node.Right);
            }

            foreach (var node in reversedPostOrderStack)
            {
                action(node.Value);
            }
        }

        public void PreOrder(Action<T> action)
        {
            // ---------- Recursive version
            //void rec(T node)
            //{
            //    if (node == null)
            //    {
            //        return;
            //    }
            //    action(node.Value);
            //    rec(node.Left);
            //    rec(node.Right);
            //}
            //rec(this.Root);

            // ---------- Iterative version
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = this.Root;

            while (node != null || stack.Count > 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    action(node.Value);
                    node = node.Left;
                }

                node = stack.Pop();
                node = node.Right;
            }
        }
    }
}
