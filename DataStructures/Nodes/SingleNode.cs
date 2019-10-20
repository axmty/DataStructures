namespace DataStructures.Nodes
{
    internal class SingleNode<T>
    {
        public SingleNode(T value, SingleNode<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }

        public SingleNode<T> Next { get; set; }

        public T Value { get; set; }
    }
}