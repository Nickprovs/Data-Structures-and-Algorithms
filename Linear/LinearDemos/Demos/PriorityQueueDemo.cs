using LinearLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Demos
{
    public class PriorityQueueDemo : IRunnable
    {
        public void Run()
        {
            var priorityQueue = new PriorityQueue(5);
            priorityQueue.Add(4);
            priorityQueue.Add(5);
            priorityQueue.Add(3);
            priorityQueue.Add(6);
            priorityQueue.Add(1);
            Console.WriteLine(priorityQueue.ToString());
        }
    }
}
