namespace DataStructures.Nodes
{
    internal class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public T Value { get; set; }
    }
}