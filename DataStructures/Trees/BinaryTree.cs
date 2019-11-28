using System;
using System.Collections.Generic;
using DataStructures.Nodes;

namespace DataStructures.Trees
{
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; } = null;
        
        public void Bfs(Action<T> action)
        {
            // ---------- Recursive version
            //var queue = new Queue<BinaryTreeNode<T>>();
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

        public void Dfs(Action<T> action)
        {
            // ---------- Iterative version
            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(this.Root);

            while (stack.TryPop(out var node))
            {
                if (node == null)
                {
                    continue;
                }

                action(node.Value);
                stack.Push(node.Right);
                stack.Push(node.Left);
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
