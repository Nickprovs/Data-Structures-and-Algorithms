using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises.Stacks
{
    public class ReversingAString : IRunnable
    {
        public void Run()
        {
            var myString = "ABC 123 BABY YOU AND ME";
            Console.WriteLine($"Going to reverse string: {myString}");

            var reversedMyString = this.ReverseString(myString);
            Console.WriteLine($"Reversed: {reversedMyString}");
        }

        /// <summary>
        /// Reverses a string using a stack
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ReverseString(string input)
        {
            if (input == null)
                throw new ArgumentException(nameof(input));

            Stack<char> stack = new Stack<char>();

            foreach (char a in input)
                stack.Push(a);

            //Use a string builder for effeciency.
            StringBuilder reversed = new StringBuilder();

            while (stack.Count != 0)
                reversed.Append(stack.Pop());

            return reversed.ToString();
        }


    }
}
