using System;

namespace DataStructures.Stacks
{
    public class ArrayStack<T>
    {
        private readonly T[] _array;
        private int _top = -1;

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
            return _top < 0;
        }

        public bool IsFull()
        {
            return _top >= this.Size - 1;
        }

        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _array[_top];
        }

        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            return _array[_top--];
        }

        public void Push(T item)
        {
            if (this.IsFull())
            {
                throw new InvalidOperationException("Stack is full.");
            }

            _array[++_top] = item;
        }
    }
}