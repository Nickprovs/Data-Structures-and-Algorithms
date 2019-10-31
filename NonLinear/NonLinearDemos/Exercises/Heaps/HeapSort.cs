using CommonLibrary;
using NonLinearLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Exercises.Heaps
{
    public class HeapSort : IRunnable
    {
        public void Run()
        {
            var numbers = new int[] { 44, 1, 22, 8, 9, 104, 22, 6, 8, 2, 12 };
            Console.WriteLine($"Unsorted: {string.Join(",", numbers)}");

            this.Sort(numbers);
            Console.WriteLine($"Sorted w/ Heap Sort: {string.Join(",", numbers)}");
        }

        private void Sort(int[] numbers)
        {
            var heap = new Heap(numbers.Length);

            foreach (var num in numbers)
                heap.Insert(num);

            for (int i = numbers.Length - 1; i >= 0; i--)
                numbers[i] = heap.Remove();
        }
    }
}
