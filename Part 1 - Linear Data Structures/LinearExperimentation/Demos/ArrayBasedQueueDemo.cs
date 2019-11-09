using LinearLibrary;
using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinearExperimentation.Demos
{
    public class ArrayBasedQueueDemo : IRunnable
    {
        public void Run()
        {
            ArrayQueue queue = new ArrayQueue(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue(6);
            queue.Enqueue(7);
            Console.WriteLine(queue.ToString());
        }
    }
}
