using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.Searching;
using CommonAlgorithmsLibrary.Sorting.Comparison;

namespace CommonAlgorithmsExperimentation.Searching
{
    public class BinarySearchDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Binary Search Demo");
            int[] numbers = { 7, 1, 3, 6, 5 };
            Console.WriteLine($"Input: {string.Join(",", numbers)}");
            Console.WriteLine("Sorting for binary search...");
            numbers.QuickSort();
            Console.WriteLine("");
            Console.WriteLine($"Sorted Input: {string.Join(",", numbers)}");
            Console.WriteLine("");

            Console.WriteLine("Recursive Approach");
            Console.WriteLine($"Checking what index 7 is at: {numbers.BinarySearchRecursive(7)}");
            Console.WriteLine($"Checking what index 3 is at: {numbers.BinarySearchRecursive(3)}");
            Console.WriteLine($"Checking what index 5 is at: {numbers.BinarySearchRecursive(5)}");
            Console.WriteLine($"Checking what index 8000 is at: {numbers.BinarySearchRecursive(8000)}");
            Console.WriteLine("");

            Console.WriteLine("Iterative Approach");
            Console.WriteLine($"Checking what index 7 is at: {numbers.BinarySearchIterative(7)}");
            Console.WriteLine($"Checking what index 3 is at: {numbers.BinarySearchIterative(3)}");
            Console.WriteLine($"Checking what index 5 is at: {numbers.BinarySearchIterative(5)}");
            Console.WriteLine($"Checking what index 8000 is at: {numbers.BinarySearchIterative(8000)}");
            Console.WriteLine("");

        }
    }
}
