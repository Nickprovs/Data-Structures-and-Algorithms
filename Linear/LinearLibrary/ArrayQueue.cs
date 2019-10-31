using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearLibrary
{
    /// <summary>
    /// This particular queue solution is array based. 
    /// It has a limited capacity... but used a circular array implementation to maximize space
    /// The circular array implementation comes from how we keep track of front and rear using modulus division.
    /// </summary>
    public class ArrayQueue
    {
        private int[] _items;
        private int _rear;
        private int _front;
        private int _count;

        public ArrayQueue(int capacity)
        {
            this._items = new int[capacity];
        }

        public void Enqueue(int item)
        {
            if (this._count == this._items.Length)
                throw new InvalidOperationException();

            this._items[this._rear] = item;
            this._rear = (this._rear + 1) % this._items.Length;
            this._count++;
        }

        public int Dequeue()
        {
            var item = this._items[this._front];
            this._items[this._front] = 0;
            this._front = (this._front + 1) % this._items.Length;
            this._count--;
            return item;
        }

        public override string ToString()
        {
            return string.Join(",", this._items.Select(i => i.ToString()).ToArray());
        }
    }
}
