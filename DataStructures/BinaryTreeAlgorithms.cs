using System;

namespace DataStructures
{
    internal abstract class BinaryTreeAlgorithms<T, TNode>
    {
        public void InOrder(Action<T> action)
        {
            // ---------- Recursive version
            void rec(TNode node)
            {
                if (this.IsEmptyNode(node))
                {
                    return;
                }

                rec(this.GetLeft(node));
                action(this.GetValue(node));
                rec(this.GetRight(node));
            }

            rec(this.GetRoot());

            // ---------- Iterative version
            //var stack = new Stack<TNode>();
            //var node = this.GetRoot();

            //while (!this.IsEmptyNode(node) || stack.Count > 0)
            //{
            //    while (!this.IsEmptyNode(node))
            //    {
            //        stack.Push(node);
            //        node = this.GetLeft(node);
            //    }

            //    node = stack.Pop();
            //    action(this.GetValue(node));
            //    node = this.GetRight(node);
            //}
        }

        protected abstract TNode GetLeft(TNode node);

        protected abstract TNode GetRight(TNode node);

        protected abstract TNode GetRoot();

        protected abstract T GetValue(TNode node);

        protected abstract bool IsEmptyNode(TNode node);
    }
}