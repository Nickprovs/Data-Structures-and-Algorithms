using CommonLibrary;
using System;
using CommonAlgorithmsLibrary.Sorting.Comparison;

namespace CommonAlgorithmsExperimentation.Sorting.Comparison
{
    public class SelectionSortDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Selection Sort Demo");
            int[] numbers = { 7, 3, 1, 4, 6, 2, 3 };
            Console.WriteLine($"Unsorted: {string.Join(",", numbers)}");
            numbers.SelectionSort();
            Console.WriteLine($"Sorted: {string.Join(",", numbers)}");
        }
    }
}
