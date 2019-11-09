using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.Sorting;


namespace CommonAlgorithmsExperimentation.Sorting
{
    public class BubbleSortDemo : IRunnable
    {
        public void Run()
        {
            int[] numbers = { 7, 3, 1, 4, 6, 2, 3 };
            Console.WriteLine($"Unsorted: {string.Join(",", numbers)}");
            numbers.Sort();
            Console.WriteLine($"Sorted: {string.Join(",", numbers)}");
        }
    }
}
