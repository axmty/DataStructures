using System;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    internal abstract class BaseBinaryTreeAlgorithms<T, TNode>
    {
        public void Bfs(Action<T> action)
        {
            // ---------- Recursive version
            var queue = new Queue<TNode>();
            queue.Enqueue(this.GetRoot());
            void rec()
            {
                if (!queue.TryDequeue(out var node))
                {
                    return;
                }

                queue.Enqueue(this.GetLeft(node));
                queue.Enqueue(this.GetRight(node));
                rec();
            }
            rec();
        }

        public void InOrder(Action<T> action)
        {
            // ---------- Recursive version
            //void rec(TNode node)
            //{
            //    if (this.IsEmptyNode(node))
            //    {
            //        return;
            //    }
            //    rec(this.GetLeft(node));
            //    action(this.GetValue(node));
            //    rec(this.GetRight(node));
            //}
            //rec(this.GetRoot());

            // ---------- Iterative version
            var stack = new Stack<TNode>();
            var node = this.GetRoot();

            while (!this.IsEmptyNode(node) || stack.Count > 0)
            {
                while (!this.IsEmptyNode(node))
                {
                    stack.Push(node);
                    node = this.GetLeft(node);
                }

                node = stack.Pop();
                action(this.GetValue(node));
                node = this.GetRight(node);
            }
        }

        public void PostOrder(Action<T> action)
        {
            // ---------- Recursive version
            //void rec(TNode node)
            //{
            //    if (this.IsEmptyNode(node))
            //    {
            //        return;
            //    }
            //    rec(this.GetLeft(node));
            //    rec(this.GetRight(node));
            //    action(this.GetValue(node));
            //}
            //rec(this.GetRoot());

            // ---------- Iterative version
            var traversalStack = new Stack<TNode>();
            var reversedPostOrderStack = new Stack<TNode>();

            traversalStack.Push(this.GetRoot());

            while (traversalStack.TryPop(out var node))
            {
                if (this.IsEmptyNode(node))
                {
                    continue;
                }

                reversedPostOrderStack.Push(node);
                traversalStack.Push(this.GetLeft(node));
                traversalStack.Push(this.GetRight(node));
            }

            foreach (var node in reversedPostOrderStack)
            {
                action(this.GetValue(node));
            }
        }

        public void PreOrder(Action<T> action)
        {
            // ---------- Recursive version
            //void rec(TNode node)
            //{
            //    if (this.IsEmptyNode(node))
            //    {
            //        return;
            //    }
            //    action(this.GetValue(node));
            //    rec(this.GetLeft(node));
            //    rec(this.GetRight(node));
            //}
            //rec(this.GetRoot());

            // ---------- Iterative version
            var stack = new Stack<TNode>();
            var node = this.GetRoot();

            while (!this.IsEmptyNode(node) || stack.Count > 0)
            {
                while (!this.IsEmptyNode(node))
                {
                    stack.Push(node);
                    action(this.GetValue(node));
                    node = this.GetLeft(node);
                }

                node = stack.Pop();
                node = this.GetRight(node);
            }
        }

        protected abstract TNode GetLeft(TNode node);

        protected abstract TNode GetRight(TNode node);

        protected abstract TNode GetRoot();

        protected abstract T GetValue(TNode node);

        protected abstract bool IsEmptyNode(TNode node);
    }
}