﻿using CommonLibrary;
using System;
using CommonAlgorithmsLibrary.Sorting.Non_Comparison;

namespace CommonAlgorithmsExperimentation.Sorting.Non_Comparison
{
    public class CountingSortDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Counting Sort Demo");
            int[] numbers = { 7, 3, 1, 4, 6, 2, 3 };
            Console.WriteLine($"Unsorted: {string.Join(",", numbers)}");
            numbers.CountingSort(7);
            Console.WriteLine($"Sorted: {string.Join(",", numbers)}");
        }
    }
}
