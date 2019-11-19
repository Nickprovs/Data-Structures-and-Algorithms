using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.StringManipulation;

namespace CommonAlgorithmsExperimentation.StringManipulation
{
    public class AnagramDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("AnagramDemo");

            var input1a = "ABCD";
            var input1b = "DABC";
            Console.WriteLine($"Input: A: {input1a}, B: {input1b}");
            Console.WriteLine($"IsAnagram: {input1a.IsAnagram(input1b)}");

            var input2a = "ABCD1X";
            var input2b = "CDABX";
            Console.WriteLine($"Input: A: {input2a}, B: {input2b}");
            Console.WriteLine($"IsAnagram: {input2a.IsAnagram(input2b)}");

            var input3a = "";
            var input3b = "ADBC";
            Console.WriteLine($"Input: A: {input3a}, B: {input3b}");
            Console.WriteLine($"IsAnagram: {input3a.IsAnagram(input3b)}");
        }
    }
}
