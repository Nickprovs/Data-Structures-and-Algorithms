using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearLibrary
{
    public class PriorityQueueWithHeap
    {
        private Heap _heap;

        public PriorityQueueWithHeap(int size)
        {
            this._heap = new Heap(size);
        }

        public void Enqueue(int item)
        {
            this._heap.Insert(item);
        }

        public int Dequeue()
        {
            return this._heap.Remove();
        }

        public bool IsEmpty()
        {
            return this._heap.IsEmpty();
        }
    }
}
