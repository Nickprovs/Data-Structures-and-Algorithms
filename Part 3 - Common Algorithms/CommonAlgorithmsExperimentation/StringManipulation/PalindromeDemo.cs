using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.StringManipulation;

namespace CommonAlgorithmsExperimentation.StringManipulation
{
    public class PalindromeDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Palindrome Demo");

            var input1 = "MADDAM";
            Console.WriteLine($"Input: {input1}");
            Console.WriteLine($"Vowels: {input1.IsPalindrome()}");

            var input2 = "Racecar";
            Console.WriteLine($"Input: {input2}");
            Console.WriteLine($"Vowels: {input2.IsPalindrome()}");

            string input3 = "DOG";
            Console.WriteLine($"Input: {input3}");
            Console.WriteLine($"Vowels: {input3.IsPalindrome()}");

            string input4 = "";
            Console.WriteLine($"Input: {input4}");
            Console.WriteLine($"Vowels: {input4.IsPalindrome()}");
        }
    }
}
