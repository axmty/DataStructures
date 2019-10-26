using System;

namespace DataStructures.Trees
{
    public interface IBinaryTree<T>
    {
        void Add(T value);

        void BFS(Action<T> action);

        IBinaryTree<T> Copy();

        void DFS(Action<T> action);

        void InOrder(Action<T> action);

        void PostOrder(Action<T> action);

        void PreOrder(Action<T> action);

        void Remove(T value);
    }
}