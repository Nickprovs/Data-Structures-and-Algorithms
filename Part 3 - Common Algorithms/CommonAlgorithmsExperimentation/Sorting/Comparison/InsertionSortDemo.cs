using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.Sorting.Comparison;

namespace CommonAlgorithmsExperimentation.Sorting.Comparison
{
    public class InsertionSortDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Insertion Sort Demo");
            int[] numbers = { 7, 3, 1, 4, 6, 2, 3 };
            Console.WriteLine($"Unsorted: {string.Join(",", numbers)}");
            numbers.InsertionSort();
            Console.WriteLine($"Sorted: {string.Join(",", numbers)}");
        }
    }
}
