using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.Searching;

namespace CommonAlgorithmsExperimentation.Searching
{
    public class LinearSearchDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Linear Search Demo");
            int[] numbers = { 7, 1, 3, 6, 5 };
            Console.WriteLine($"Input: {string.Join(",", numbers)}");
            Console.WriteLine($"Checking what index 7 is at: {numbers.LinearSearch(7)}");
            Console.WriteLine($"Checking what index 3 is at: {numbers.LinearSearch(3)}");
            Console.WriteLine($"Checking what index 5 is at: {numbers.LinearSearch(5)}");
            Console.WriteLine($"Checking what index 8000 is at: {numbers.LinearSearch(8000)}");
        }
    }
}
