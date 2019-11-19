using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.StringManipulation;

namespace CommonAlgorithmsExperimentation.StringManipulation
{
    public class CapitalizationDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Capitalize First Letter Of Words In Sentence Demo");

            var input1 = "The quick       brown    fox jumped over the lazy dog.";
            Console.WriteLine($"Input: {input1}");
            Console.WriteLine($"Capitalized: {input1.CapitalizeFirstLetterOfEachWord()}");

            var input2 = "What is good in the hood? That's what I want to know!";
            Console.WriteLine($"Input: {input2}");
            Console.WriteLine($"Capitalized: {input2.CapitalizeFirstLetterOfEachWord()}");

            string input3 = "";
            Console.WriteLine($"Input: {input3}");
            Console.WriteLine($"Capitalized: {input3.CapitalizeFirstLetterOfEachWord()}");
        }
    }
}
