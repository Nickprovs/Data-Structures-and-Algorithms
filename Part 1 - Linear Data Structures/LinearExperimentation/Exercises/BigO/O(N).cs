using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises
{
    //O(n)
    public class O_n_ : IRunnable
    {
        public void Run()
        {
            int[] randomArray = Utilities.GetRandomArrayOfSize(1000);
            this.Log1(randomArray);
        }

        /// <summary>
        /// Here, log has a complexity of O(n)
        /// </summary>      
        /// <param name="numbers"></param>
        public void Log1(int [] numbers)
        {
            for (int i = 0; i < numbers.Length; i++) //O(n)
                Console.WriteLine($"NUM: {numbers[i]}");
        }

        /// <summary>
        /// O(n + 1 + 1) => O(n + 2) => (n)
        /// We drop constants when measuring performance
        /// </summary>      
        /// <param name="numbers"></param>
        public void Log2(int[] numbers)
        {
            Console.WriteLine("Hi"); //O(1)
            for (int i = 0; i < numbers.Length; i++) //O(n)
                Console.WriteLine(numbers[i]);
            Console.WriteLine("Hi"); //O(1)
        }

        /// <summary>
        /// O(2n) => O(n)
        /// Whether we have O(2n) or O(n), we still have linear growth
        /// So we drop the constant
        /// </summary>      
        /// <param name="numbers"></param>
        public void Log3(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++) //O(n)
                Console.WriteLine(numbers[i]);

            for (int i = 0; i < numbers.Length; i++) //O(n)
                Console.WriteLine(numbers[i]);
        }

        /// <summary>
        /// O(n + m) => O(n)
        /// The performance can still be reduced to O(n)
        /// As the runtime still increases linearly.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="names"></param>
        public void Log4(int[] numbers, string[] names)
        {
            for (int i = 0; i < numbers.Length; i++) //O(n)
                Console.WriteLine(numbers[i]);

            for (int i = 0; i < names.Length; i++) //O(m)
                Console.WriteLine(names[i]);
        }
    }
}
