using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises
{
    public class O_1_ : IRunnable
    {
        public void Run()
        {
            int[] randomArray = Utilities.GetRandomArrayOfSize(1000);
            this.Log(randomArray);
        }

        /// <summary>
        /// Here, log has a complexity of O(1)
        /// </summary>
        /// <param name="numbers"></param>
        public void Log(int[] numbers)
        {
            Console.WriteLine(numbers[0]);
        }
    }
}
