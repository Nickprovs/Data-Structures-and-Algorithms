using CommonLibrary;
using System;
using CommonAlgorithmsLibrary.Searching;
using CommonAlgorithmsLibrary.Sorting.Comparison;

namespace CommonAlgorithmsExperimentation.Searching
{
    public class ExponentialSearchDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Exponential Search Demo");
            int[] numbers = { 7, 1, 3, 6, 5 };
            Console.WriteLine($"Input: {string.Join(",", numbers)}");
            Console.WriteLine("Sorting for exponential search...");
            numbers.QuickSort();
            Console.WriteLine("");
            Console.WriteLine($"Sorted Input: {string.Join(",", numbers)}");
            Console.WriteLine("");

            Console.WriteLine($"Checking what index 7 is at: {numbers.ExponentialSearch(7)}");
            Console.WriteLine($"Checking what index 3 is at: {numbers.ExponentialSearch(3)}");
            Console.WriteLine($"Checking what index 5 is at: {numbers.ExponentialSearch(5)}");
            Console.WriteLine($"Checking what index 8000 is at: {numbers.ExponentialSearch(8000)}");
        }
    }
}
