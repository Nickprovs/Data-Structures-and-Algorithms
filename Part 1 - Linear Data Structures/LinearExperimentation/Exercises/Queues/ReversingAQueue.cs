using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises.Queues
{
    public class ReversingAQueue : IRunnable
    {
        public void Run()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine($"Queue Prior To Reversal: {string.Join(',', queue.ToArray())}");
            this.Reverse(queue);
            Console.WriteLine($"Queue After Reversal: {string.Join(',', queue.ToArray())}");
        }

        /// <summary>
        /// Reverses a queue
        /// Only add to use
        /// Add
        /// Remove
        /// IsEmpty 
        /// From Queue
        /// </summary>
        public void Reverse(Queue<int> queueToReverse)
        {
            if (queueToReverse == null)
                throw new ArgumentNullException();

            if (queueToReverse.Count == 0)
                return;

            Stack<int> stack = new Stack<int>();
            while(queueToReverse.Count != 0)
                stack.Push(queueToReverse.Dequeue());

            while (stack.Count != 0)
                queueToReverse.Enqueue(stack.Pop());
        }
    }
}
