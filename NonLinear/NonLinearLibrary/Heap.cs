using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearLibrary
{
    public class Heap
    {
        private int[] _items;
        private int _size;

        public Heap(int size)
        {
            this._items = new int[size];
            this._size = 0;
        }

        public void Insert(int value)
        {
            if (this.IsFull())
                throw new InvalidOperationException("Heap is full");

            this._items[this._size] = value;
            this._size++;

            this.BubbleUp();
        }

        public int Remove()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException("Heap is empty");

            var oldRoot = this._items[0];
            this._size--;
            this._items[0] = this._items[this._size];

            this.BubbleDown();

            return oldRoot;
        }

        public bool IsFull()
        {
            return this._size == this._items.Length;
        }

        public bool IsEmpty()
        {
            return this._size == 0;
        }

        private void BubbleUp()
        {
            var childIndex = this._size - 1;
            while (childIndex > 0 && this._items[childIndex] > this.GetParentValueFromChildIndex(childIndex))
            {
                this.Swap(childIndex, this.GetParentIndexFromChildIndex(childIndex));
                childIndex = this.GetParentIndexFromChildIndex(childIndex);
            }
        }

        private void BubbleDown()
        {
            var parentIndex = 0;
            while (parentIndex <= this._size && !this.IsValidParent(parentIndex))
            {

                var largerChildIndex = this.GetLargerChildIndex(parentIndex);
                this.Swap(parentIndex, largerChildIndex);
                parentIndex = largerChildIndex;
            }

        }

        private bool IsValidParent(int parentIndex)
        {
            if (!this.HasLeftChild(parentIndex))
                return true;

            bool isLeftSideValid = this._items[parentIndex] >= this.GetLeftChildValueFromParentIndex(parentIndex);

            if (!this.HasRightChild(parentIndex))
                return isLeftSideValid;

            bool isRightSideValid = this._items[parentIndex] >= this.GetRightChildValueFromParentIndex(parentIndex);

            return isLeftSideValid && isRightSideValid;
        }

        private int GetLargerChildIndex(int parentIndex)
        {
            if (!this.HasLeftChild(parentIndex))
                return parentIndex;

            if (!this.HasRightChild(parentIndex))
                return this.GetLeftChildIndexFromParentIndex(parentIndex);

            return (this.GetLeftChildValueFromParentIndex(parentIndex) > this.GetRightChildValueFromParentIndex(parentIndex)) ?
                    this.GetLeftChildIndexFromParentIndex(parentIndex) :
                    this.GetRightChildIndexFromParentIndex(parentIndex); 
        }

        private void Swap(int first, int second)
        {
            var temp = this._items[first];
            this._items[first] = this._items[second];
            this._items[second] = temp;
        }

        private bool HasLeftChild(int parentIndex)
        {
            return this.GetLeftChildIndexFromParentIndex(parentIndex) <= this._size;
        }

        private int GetLeftChildIndexFromParentIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int GetLeftChildValueFromParentIndex(int parentIndex)
        {
            return this._items[this.GetLeftChildIndexFromParentIndex(parentIndex)];
        }

        private bool HasRightChild(int parentIndex)
        {
            return this.GetRightChildIndexFromParentIndex(parentIndex) <= this._size;
        }

        private int GetRightChildIndexFromParentIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }

        private int GetRightChildValueFromParentIndex(int parentIndex)
        {
            return this._items[this.GetRightChildIndexFromParentIndex(parentIndex)];
        }

        private int GetParentIndexFromChildIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetParentValueFromChildIndex(int childIndex)
        {
            return this._items[this.GetParentIndexFromChildIndex(childIndex)];
        }
    }
}
