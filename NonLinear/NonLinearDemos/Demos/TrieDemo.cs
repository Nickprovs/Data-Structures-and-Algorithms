using CommonLibrary;
using NonLinearLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Demos
{
    public class TrieDemo : IRunnable
    {
        public void Run()
        {
            var trie = new Trie();
            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("canny");
            trie.Insert("careful");
            trie.Insert("cargo");
            trie.Insert("con");
            trie.Insert("canada");
            trie.Insert("dog");
            trie.Insert("dimmsdale");
            trie.Insert("dimmedone");

            Console.WriteLine($"Total number of words in Trie: {trie.CountWords()}");

            Console.WriteLine($"Trie contains word canada: {trie.Contains("canada")}");
            Console.WriteLine($"Trie contains word canada (recursive check): {trie.ContainsRecursive("canada")}");

            Console.WriteLine("Traversing...");
            trie.Traverse();

            Console.WriteLine("Removing Canada");
            trie.Remove("canada");

            Console.WriteLine("Traversing...");
            trie.Traverse();

            var autoCompletionPrefix = "d";
            Console.WriteLine($"Auto Completion Words for {autoCompletionPrefix}");
            Console.WriteLine($"{string.Join(",",trie.GetAutoCompletedWords(autoCompletionPrefix))}");

            Console.WriteLine("STARTING LONGEST COMMON PREFIX TEST... Unrelated to above tests");

            var testData1 = new List<string> { "card", "care", "can" };
            Console.WriteLine($"Getting Longest Common Prefix For {string.Join(",", testData1)}: {Trie.GetLongestCommonPrefix(testData1)}");

            var testData2 = new List<string> { "care", "card" };
            Console.WriteLine($"Getting Longest Common Prefix For {string.Join(",", testData2)}: {Trie.GetLongestCommonPrefix(testData2)}");

            var testData3 = new List<string> { "car" };
            Console.WriteLine($"Getting Longest Common Prefix For {string.Join(",", testData3)}: {Trie.GetLongestCommonPrefix(testData3)}");

            var testData4 = new List<string>();
            Console.WriteLine($"Getting Longest Common Prefix For {string.Join(",", testData4)}: {Trie.GetLongestCommonPrefix(testData4)}");

            List<string> testData5 = null;
            Console.WriteLine($"Getting Longest Common Prefix For {testData5}: {Trie.GetLongestCommonPrefix(testData5)}");

        }
    }
}
