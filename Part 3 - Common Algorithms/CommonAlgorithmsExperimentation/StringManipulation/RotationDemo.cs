using CommonAlgorithmsLibrary.StringManipulation;
using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsExperimentation.StringManipulation
{
    public class RotationDemo : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("Reverse Words Demo");

            var input1a = "ABCD";
            var input1b = "DABC";
            Console.WriteLine($"Input: A: {input1a}, B: {input1b}");
            Console.WriteLine($"IsRotation: {StringUtilities.IsRotation(input1a, input1b)}");

            var input2a = "ABCD";
            var input2b = "CDAB";
            Console.WriteLine($"Input: A: {input2a}, B: {input2b}");
            Console.WriteLine($"IsRotation: {StringUtilities.IsRotation(input2a, input2b)}");

            var input3a = "ABCD";
            var input3b = "ADBC";
            Console.WriteLine($"Input: A: {input3a}, B: {input3b}");
            Console.WriteLine($"IsRotation: {StringUtilities.IsRotation(input3a, input3b)}");
        }
    }
}
