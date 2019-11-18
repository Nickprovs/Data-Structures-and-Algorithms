using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.StringManipulation;

namespace CommonAlgorithmsExperimentation.StringManipulation
{
    public class ReverseWordsDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Reverse Words Demo");

            var input1 = "HELLO WORLD HOW ARE YOU";
            Console.WriteLine($"Input: {input1}");
            Console.WriteLine($"Vowels: {input1.ReverseWords()}");

            var input2 = "";
            Console.WriteLine($"Input: {input2}");
            Console.WriteLine($"Vowels: {input2.ReverseWords()}");

            string input3 = null;
            Console.WriteLine($"Input: {input3}");
            Console.WriteLine($"Vowels: {input3.ReverseWords()}");
        }
    }
}
