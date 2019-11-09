using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises
{
    //O(n^2)
    public class O_n_2_ : IRunnable
    {
        public void Run()
        {
            int[] randomArray = Utilities.GetRandomArrayOfSize(1000);
            this.Log1(randomArray);
        }

        /// <summary>
        /// O(n * n) => O(n^2)
        /// Note: This is the algorithm for going through all possible combos in an array.
        /// </summary>
        /// <param name="numbers"></param>
        public void Log1(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++) //O(n)
                for (int j = 0; j < numbers.Length; j++) // O(n)
                    Console.WriteLine($"First: {numbers[i]}, Second: {numbers[j]}");
        }

        /// <summary>
        /// O(n + n ^ 2) => O(n ^ 2)
        /// </summary>
        /// <param name="numbers"></param>
        public void Log2(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++) //O(n)
                Console.WriteLine(numbers[i]);

            for (int i = 0; i < numbers.Length; i++) //O(n)
                for (int j = 0; j < numbers.Length; j++) // O(n)
                    Console.WriteLine($"First: {numbers[i]}, Second: {numbers[j]}");
        }

        /// <summary>
        /// O(n * n * n) => O(n ^ 3)
        /// </summary>
        /// <param name="numbers"></param>
        public void Log3(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++) //O(n)
                for (int j = 0; j < numbers.Length; j++) // O(n)
                    for (int k = 0; k < numbers.Length; k++) // O(n)
                        Console.WriteLine($"First: {numbers[k]}, Second: {numbers[j]}, Third: {numbers[k]}");
        }
    }
}
