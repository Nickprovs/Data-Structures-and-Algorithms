using System;
using System.Collections.Generic;
using System.Text;

namespace LinearLibrary
{
    public class PriorityQueue
    {
        private int[] _items;
        private int _count;

        public PriorityQueue(int size)
        {
            this._items = new int[size];
            this._count = 0;
        }

        public void Add(int item)
        {

            if (this.IsFull())
                throw new InvalidOperationException("");

            int insertionIndex = this.ShiftItemsAndFindInsertionPointFor(item);

            this._items[insertionIndex] = item;
            this._count++;
        }

        private int ShiftItemsAndFindInsertionPointFor(int itemToInsert)
        {
            int i;
            for (i = this._count - 1; i >= 0; i--)
            {
                if (this._items[i] > itemToInsert)
                    this._items[i + 1] = this._items[i];

                else
                    break;
            }

            return i + 1;
        }

        public int Remove()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException();

            this._count--;
            return this._items[this._count];
        }

        public bool IsFull()
        {
            return this._count == this._items.Length;
        }

        public bool IsEmpty()
        {
            return this._count == 0;
        }

        public override string ToString()
        {
            return string.Join(",", this._items);
        }
    }
}
