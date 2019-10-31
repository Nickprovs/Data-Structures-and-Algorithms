using CommonLibrary;
using NonLinearLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Exercises.Heaps
{
    public class KthLargestItem : IRunnable
    {
        public void Run()
        {
            int[] numbers = new int[] { 1, 2, 3, -3, 4, -4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine($"Number Set: {string.Join(",", numbers)}");

            int k = 3;

            var kLargest = this.GetKthLargestItem(numbers, k);
            Console.WriteLine($"The {k}th largest number in the set is: {kLargest}");
        }

        private int GetKthLargestItem(int[] numbers, int k)
        {
            if (k < 1 || k > numbers.Length)
                throw new ArgumentException();

            var heap = new Heap(numbers.Length);
            foreach (var number in numbers)
                heap.Insert(number);


            var kthLargest = -1;
            for (int i = 0; i > k - 1; i--)
                kthLargest = heap.Remove();

            return kthLargest;
        }
    }
}
