namespace DataStructures.Nodes
{
    internal class SingleNode<T>
    {
        public SingleNode(T value, SingleNode<T> next)
        {
            this.Value = value;
            this.Next = next;
        }

        public T Value { get; set; }

        public SingleNode<T> Next { get; set; }
    }
}
