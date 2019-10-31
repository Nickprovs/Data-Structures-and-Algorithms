using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Exercises.HashTablesAndSets
{
    public class CountPairsWithDiff : IRunnable
    {
        public void Run()
        {
            List<int> inputNumbers = new List<int> { 1, 7, 5, 9, 2, 12, 3 };
            int difference = 2;
            Console.WriteLine($"Looking for pairs with diff: {difference} from set: {string.Join(",", inputNumbers)}");
            Console.WriteLine($"Answer: {this.GetNumberOfPairsWithDiffFAST(inputNumbers, difference)}");
        }


        /// <summary>
        /// Runs in O(N) time
        /// Note: It doesn't really matter that we're using a HashSet here oppose to a Dict in the SLOW example
        ///       Printing the actual pairs was never a requirement
        /// </summary>
        public int GetNumberOfPairsWithDiffFAST(IEnumerable<int> enumerableNumbers, int difference)
        {
            var numbers = enumerableNumbers.ToList();

            //Add the numbers to a hash set (O(N))
            HashSet<int> set = new HashSet<int>();
            foreach (var number in numbers)
                set.Add(number);

            var numPairsWhoseDiffMatchesK = 0;

            //Loop through the numbers once more to see...
            //If that number + or - the difference is equal to a number in our set
            //If it is...we have a pair!
            foreach (var number in numbers)
            {
                if (set.Contains(number + difference))
                    numPairsWhoseDiffMatchesK++;
                if (set.Contains(number - difference))
                    numPairsWhoseDiffMatchesK++;
                set.Remove(number);
            }

            return numPairsWhoseDiffMatchesK;
        }

        /// <summary>
        /// Time Complexity here is O(N^2)
        /// That's pretty slow
        /// </summary>
        /// <param name="integers"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetNumberOfPairsWithDiffSLOW(IEnumerable<int> integers, int k)
        {
            if (integers == null)
                throw new ArgumentException();

            var integerList = integers.ToList();
            //First int is the key (difference value of a pair)
            //Second int is the value (count of pairs with that difference).
            Dictionary<int, List<Tuple<int, int>>> pairsWithDiff = new Dictionary<int, List<Tuple<int, int>>>();
            for(int i = 0; i < integerList.Count; i++)
            {
                for(int j = i + 1; j < integerList.Count; j++)
                {
                    int first = integerList[i];
                    int second = integerList[j];
                    int biggestOfPair = Math.Max(first, second);
                    int smallestOfPair = Math.Min(first, second);

                    int diff = biggestOfPair - smallestOfPair;

                    if (pairsWithDiff.ContainsKey(diff))
                        pairsWithDiff[diff].Add(new Tuple<int, int>(smallestOfPair, biggestOfPair));
                    else
                        pairsWithDiff.Add(diff, new List<Tuple<int, int>> { new Tuple<int,int>(biggestOfPair, smallestOfPair) });
                }
            }

            if (pairsWithDiff.ContainsKey(k))
            {
                var relatedDiffs = pairsWithDiff[k];
                var pairsInStringForm = string.Join(",", relatedDiffs);
                Console.WriteLine($"Our Pairs Are... {pairsInStringForm}");
                return relatedDiffs.Count;
            }
            else
                return 0;
        }
    }
}
