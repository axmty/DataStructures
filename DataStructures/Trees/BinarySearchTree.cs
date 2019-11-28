using System;
using DataStructures.Nodes;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; private set; } = null;

        public void Add(T value)
        {
            var newNode = new BinaryTreeNode<T>(value);

            if (this.Root == null)
            {
                this.Root = newNode;
                return;
            }

            var node = this.Root;

            while (node != null)
            {
                var compare = node.Value.CompareTo(value);

                if (compare == 0)
                {
                    throw new InvalidOperationException($"Key {value} must be unique.");
                }
                else if (compare < 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = newNode;
                        return;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
                else if (compare > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        return;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
            }
        }

        public bool Search(T value)
        {
            var node = this.Root;

            while (node != null)
            {
                var compare = node.Value.CompareTo(value);

                if (compare == 0)
                {
                    return true;
                }
                else if (compare < 0)
                {
                    node = node.Right;
                }
                else
                {
                    node = node.Left;
                }
            }

            return false;
        }

        public bool IsEquivalentTo(BinaryTree<T> binaryTree)
        {
            throw new NotImplementedException();
        }
    }
}