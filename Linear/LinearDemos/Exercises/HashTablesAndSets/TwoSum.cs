using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises.HashTablesAndSets
{
    public class TwoSum : IRunnable
    {
        public void Run()
        {
            int[] myArray = new int[4] { 2, 7, 11, 13 };
            int target = 9;
            Console.WriteLine($"Target: {target}, Array To Check: {string.Join(",", myArray)}");
            var answer = GetTwoSum(myArray, target);

            if (answer == null)
                Console.WriteLine("No matching value");

            else
                Console.WriteLine($"Answer: {answer}");
        }

        /// <summary>
        /// Given an array of integers... return two indices of numbers from that array whose sum is the target
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public Tuple<int,int> GetTwoSum(int[] numbers, int target)
        {
            //Our map will map tried numbers w/ their indice
            Dictionary<int,int> map = new Dictionary<int, int>();

            //Try each number in the array
            for(int i = 0; i < numbers.Length; i++)
            {
                //If the compliment (Target minus the current number) is in the array... we found a match
                int complement = target - numbers[i];
                if (map.ContainsKey(complement))
                    return new Tuple<int, int>(map[complement], i);

                map.Add(numbers[i], i);
            }

            return null;
        }
    }
}
