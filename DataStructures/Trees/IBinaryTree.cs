using System;

namespace DataStructures.Trees
{
    public interface IBinaryTree<T>
    {
        void Add(T value);

        void Bfs(Action<T> action);

        IBinaryTree<T> Copy();

        void InOrder(Action<T> action);

        void PostOrder(Action<T> action);

        void PreOrder(Action<T> action);

        void Remove(T value);
    }
}