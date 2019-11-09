using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises.Dictionaries
{
    public class FindFirstNonRepeatedCharacter : IRunnable
    {
        public void Run()
        {
            string test = "a green apple";
            Console.WriteLine($"Calculating First Non Repeated In: {test}");
            char firstNonRepeated = this.FindFirstNonRepeatedChar(test);
            Console.WriteLine($"Answer: {firstNonRepeated}");
        }

        public char FindFirstNonRepeatedChar(string toCheck)
        {
            if (toCheck == null)
                throw new ArgumentException();

            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach(var character in toCheck)
            {
                if(map.ContainsKey(character))
                {
                    var count = map[character];
                    map[character] = count + 1;
                }
                else
                {
                    map.Add(character, 1);
                }
            }

            foreach (var character in toCheck)
            {
                if (map[character] == 1)
                    return character;          
            }

            return Char.MinValue;
        }
    }
}
