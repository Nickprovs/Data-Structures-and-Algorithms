using CommonLibrary;
using NonLinearLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Demos
{
    public class HeapDemo : IRunnable
    {
        public void Run()
        {
            var myHeap = new Heap(10);
            myHeap.Insert(10);
            myHeap.Insert(5);
            myHeap.Insert(17);
            myHeap.Insert(4);
            myHeap.Insert(22);
            myHeap.Remove();

        }
    }
}
