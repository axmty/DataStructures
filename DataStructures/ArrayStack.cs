using System;

namespace DataStructures.Interfaces
{
    public class ArrayStack<T>
    {
        private readonly T[] _array;
        private readonly int _top = 0;

        public ArrayStack(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("Stack size must be strictly positive.");
            }

            _array = new T[size];
        }

        public int Size => _array.Length;

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(T item)
        {
            throw new NotImplementedException();
        }
    }
}