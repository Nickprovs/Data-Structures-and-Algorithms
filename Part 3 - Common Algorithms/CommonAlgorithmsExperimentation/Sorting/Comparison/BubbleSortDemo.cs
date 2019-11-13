using CommonLibrary;
using System;
using CommonAlgorithmsLibrary.Sorting.Comparison;


namespace CommonAlgorithmsExperimentation.Sorting.Comparison
{
    public class BubbleSortDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Bubble Sort Demo");
            int[] numbers = { 7, 3, 1, 4, 6, 2, 3 };
            Console.WriteLine($"Unsorted: {string.Join(",", numbers)}");
            numbers.BubbleSort();
            Console.WriteLine($"Sorted: {string.Join(",", numbers)}");
        }
    }
}
