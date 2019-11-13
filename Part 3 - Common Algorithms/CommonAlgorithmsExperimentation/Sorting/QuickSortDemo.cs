using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.Sorting;

namespace CommonAlgorithmsExperimentation.Sorting
{
    public class QuickSortDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Quick Sort Demo");
            int[] numbers = { 7, 3, 1, 4, 6, 2, 3 };
            Console.WriteLine($"Unsorted: {string.Join(",", numbers)}");
            numbers.QuickSort();
            Console.WriteLine($"Sorted: {string.Join(",", numbers)}");
        }
    }
}
