using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.StringManipulation;

namespace CommonAlgorithmsExperimentation.StringManipulation
{
    public class ReverseStringDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Reverse String Demo");

            var input1 = "HELLO";
            Console.WriteLine($"Input: {input1}");
            Console.WriteLine($"Vowels: {input1.Reverse()}");

            var input2 = "";
            Console.WriteLine($"Input: {input2}");
            Console.WriteLine($"Vowels: {input2.Reverse()}");

            string input3 = null;
            Console.WriteLine($"Input: {input3}");
            Console.WriteLine($"Vowels: {input3.Reverse()}");
        }
    }
}
