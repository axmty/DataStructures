using System;
using System.Collections.Generic;

namespace DataStructures.Interfaces
{
    public interface IBinaryTree<T>
    {
        void Add(T value);

        IBinaryTree<T> Copy();

        void InOrder(Action<T> action);

        void PostOrder(Action<T> action);

        void PreOrder(Action<T> action);

        void Remove(T value);
    }
}