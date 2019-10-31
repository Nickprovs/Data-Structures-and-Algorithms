using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises.Sets
{
    public class FindFirstRepeatedCharacter : IRunnable
    {
        public void Run()
        {
            string toTest = "a green apple";
            Console.WriteLine($"Finding first repeated character in {toTest}");

            var result = this.FindFirstRepeatedChar(toTest);
            if (result == char.MinValue)
                Console.WriteLine("No duplicate chars");
            else
                Console.WriteLine($"Duplicate: {result}");
        }

        public char FindFirstRepeatedChar(string toTest)
        {
            var nonRepeatedCharacters = new HashSet<char>();

            foreach(char character in toTest)
            {
                bool success = nonRepeatedCharacters.Add(character);
                if (!success)
                    return character;
            }

            return char.MinValue;
        }
    }
}
