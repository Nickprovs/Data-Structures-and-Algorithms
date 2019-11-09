using System;
using System.Collections.Generic;
using System.Text;

namespace LinearExperimentation.Exercises.Stacks
{
    /// <summary>
    /// A stack whose push, pops, and peeks occur in a max of O(n) time.
    /// </summary>
    public class ArrayBasedStack
    {
        private int[] _items;
        private int _count;

        /// <summary>
        /// Initializes a MinStack
        /// </summary>
        public ArrayBasedStack()
        {
            this._items = new int[2];
            this._count = 0;
        }

        /// <summary>
        /// Pushes a new item onto the stack
        /// </summary>
        /// <param name="x"></param>
        public void Push(int x)
        {
            if (this._count == this._items.Length)
                this.DoubleInternalArraySize();

            this._items[this._count] = x;
            this._count++;
        }


        /// <summary>
        /// Creates a new array that is double the size of our current array
        /// And copies all previous items into the new array
        /// </summary>
        private void DoubleInternalArraySize()
        {
            int[] newItems = new int[this._count * 2];

            for (int i = 0; i < this._count; i++)
                newItems[i] = this._items[i];

            this._items = newItems;
        }

        /// <summary>
        /// Removes the last element in the array
        /// Per Leet Code spec... does not return it.
        /// </summary>
        public int Pop()
        {
            if (this._count == 0)
                throw new InvalidOperationException();

            var top = this._items[this._count - 1];
            this._count--;
            return top;
        }

        /// <summary>
        /// Returns the last element in the array
        /// </summary>
        /// <returns></returns>
        public int Top()
        {
            if (this._count == 0)
                throw new InvalidOperationException();

            var top = this._items[this._count - 1];
            return top;
        }

        /// <summary>
        /// Gets the smallest number in the stack
        /// </summary>
        /// <returns></returns>
        public int GetMin()
        {
            if (this._count == 0)
                throw new InvalidOperationException();

            int min = this._items[0];
            for (int i = 0; i < this._count; i++)
            {
                if (this._items[i] < min)
                    min = this._items[i];
            }
            return min;
        }
    }
}
