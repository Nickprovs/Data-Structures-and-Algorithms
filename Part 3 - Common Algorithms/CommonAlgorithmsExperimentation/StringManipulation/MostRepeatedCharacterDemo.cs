using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonAlgorithmsLibrary.StringManipulation;

namespace CommonAlgorithmsExperimentation.StringManipulation
{
    public class MostRepeatedCharacterDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Most Repeated Character Demo");

            var input1 = "HELLO";
            Console.WriteLine($"Input: {input1}");
            Console.WriteLine($"Most Repeated Char: {input1.MostRepeatedChar()}");

            Console.WriteLine($"Input: {input1}");
            Console.WriteLine($"Most Repeated Char w/o Hash Table: {input1.MostRepeatedCharWithoutHashTable()}");
        }
    }
}
