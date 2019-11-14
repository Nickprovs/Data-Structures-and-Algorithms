using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.Sorting.Non_Comparison;

namespace CommonAlgorithmsExperimentation.Sorting.Non_Comparison
{
    public class BucketSortDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Counting Sort Demo");
            int[] numbers = { 7, 1, 3, 5, 3};
            Console.WriteLine($"Unsorted: {string.Join(",", numbers)}");
            numbers.BucketSort(3);
            Console.WriteLine($"Sorted: {string.Join(",", numbers)}");
        }
    }
}
