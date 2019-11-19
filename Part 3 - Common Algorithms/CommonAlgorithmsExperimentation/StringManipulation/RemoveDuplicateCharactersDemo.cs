using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.StringManipulation;


namespace CommonAlgorithmsExperimentation.StringManipulation
{
    public class RemoveDuplicateCharactersDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Remove Duplicate Characters Demo");

            var input1 = "Helloooo!!!";
            Console.WriteLine($"Input: {input1}");
            Console.WriteLine($"Duplicates Chars Removed: {input1.RemoveDuplicateCharacters()}");

            var input2 = "";
            Console.WriteLine($"Input: {input2}");
            Console.WriteLine($"Duplicates Chars Removed:: {input2.RemoveDuplicateCharacters()}");

            string input3 = null;
            Console.WriteLine($"Input: {input3}");
            Console.WriteLine($"Duplicates Chars Removed:: {input3.RemoveDuplicateCharacters()}");
        }
    }
}
