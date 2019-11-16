using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.Searching;
using CommonAlgorithmsLibrary.Sorting.Comparison;

namespace CommonAlgorithmsExperimentation.Searching
{
    public class JumpSearchDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Jump Search Demo");
            int[] numbers = { 7, 1, 3, 6, 5 };
            Console.WriteLine($"Input: {string.Join(",", numbers)}");
            Console.WriteLine("Sorting for jump search...");
            numbers.QuickSort();
            Console.WriteLine("");
            Console.WriteLine($"Sorted Input: {string.Join(",", numbers)}");
            Console.WriteLine("");

            Console.WriteLine($"Checking what index 7 is at: {numbers.JumpSearch(7)}");
            Console.WriteLine($"Checking what index 3 is at: {numbers.JumpSearch(3)}");
            Console.WriteLine($"Checking what index 5 is at: {numbers.JumpSearch(5)}");
            Console.WriteLine($"Checking what index 8000 is at: {numbers.JumpSearch(8000)}");
        }
    }
}
