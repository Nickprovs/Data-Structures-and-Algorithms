using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.Searching;
using CommonAlgorithmsLibrary.Sorting.Comparison;

namespace CommonAlgorithmsExperimentation.Searching
{
    public class TernarySearchDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Ternary Search Demo");
            int[] numbers = { 7, 1, 3, 6, 5 };
            Console.WriteLine($"Input: {string.Join(",", numbers)}");
            Console.WriteLine("Sorting for ternary search...");
            numbers.QuickSort();
            Console.WriteLine("");
            Console.WriteLine($"Sorted Input: {string.Join(",", numbers)}");
            Console.WriteLine("");

            Console.WriteLine($"Checking what index 7 is at: {numbers.TernarySearch(7)}");
            Console.WriteLine($"Checking what index 3 is at: {numbers.TernarySearch(3)}");
            Console.WriteLine($"Checking what index 5 is at: {numbers.TernarySearch(5)}");
            Console.WriteLine($"Checking what index 8000 is at: {numbers.TernarySearch(8000)}");
        }
    }
}
