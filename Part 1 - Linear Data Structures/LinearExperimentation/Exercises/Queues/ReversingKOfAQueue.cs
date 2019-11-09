using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises.Queues
{
    public class ReversingKOfAQueue : IRunnable
    {
        public void Run()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine($"Queue Prior To Reversal: {string.Join(',', queue.ToArray())}");
            this.Reverse(queue, 3);
            Console.WriteLine($"Queue After Reversing the First 3 Elements: {string.Join(',', queue.ToArray())}");
        }

        public void Reverse(Queue<int> queueToReverse, int amountToReverse)
        {
            if (queueToReverse == null)
                throw new ArgumentNullException();

            if (queueToReverse.Count == 0)
                return;

            int remainderSize = queueToReverse.Count - amountToReverse;
            if (remainderSize < 0)
                throw new ArgumentException("K must be less than or equal to size of queue", nameof(amountToReverse));

            Stack<int> stack = new Stack<int>();
            int[] nonReversing = new int[remainderSize];

            for (int i = 0; i < amountToReverse; i++)
                stack.Push(queueToReverse.Dequeue());

            for (int i = 0; i < remainderSize; i++)
                nonReversing[i] = queueToReverse.Dequeue();

            while (stack.Count != 0)
                queueToReverse.Enqueue(stack.Pop());

            for (int i = 0; i < nonReversing.Length; i++)
                queueToReverse.Enqueue(nonReversing[i]);
        }
    }
}
