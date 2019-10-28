using System;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> : LinkedListBinaryTree<T>
        where T : IComparable<T>
    {
        public override void Add(T value)
        {
            base.Add(value);
        }

        public override void Remove(T value)
        {
            base.Remove(value);
        }

        /// <summary>
        /// Complexity: O(log(n)).
        /// </summary>
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
    }
}