using LinearLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Demos
{
    public class QueueWithTwoStacksDemo : IRunnable
    {
        public void Run()
        {
            var queue = new QueueWithTwoStacks();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine("Queue has 1,2,3,4");

            Console.WriteLine($"Dequeued: {queue.Dequeue()}");
            Console.WriteLine($"Dequeued: {queue.Dequeue()}");
        }
    }
}
