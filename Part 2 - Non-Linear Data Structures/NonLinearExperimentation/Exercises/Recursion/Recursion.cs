using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Exercises.Recursion
{
    /// <summary>
    /// 4! = 4 * 3 * 2 * 1
    /// 3! = 3 * 2 * 1
    /// So...
    /// 4! = 4* 3!
    /// Also...
    /// n! = n * (n-1)!
    /// </summary>
    public class Recursion : IRunnable
    {
        public void Run()
        {
            Console.WriteLine($"4 Factorial Calculated w/ Loop: {this.FactorialUsingIteration(4)}");
            Console.WriteLine($"4 Factorial Calculated w/ Recursion: {this.FactorialUsingRecursion(4)}");
        }

        public int FactorialUsingIteration(int n)
        {
            var factorial = 1;
            for (int i = n; i > 1; i--)
                factorial *= i;

            return factorial;
        }

        /// <summary>
        /// Languages use a stack to keep track of the memory... 
        /// ...at each recursive step!
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FactorialUsingRecursion(int n)
        {
            //Base Condition (A Way To Terminate The Recursion)
            //0 Factorial is 1
            if (n == 0)
                return 1;

            return n * this.FactorialUsingRecursion(n - 1);
        }
    }
}
