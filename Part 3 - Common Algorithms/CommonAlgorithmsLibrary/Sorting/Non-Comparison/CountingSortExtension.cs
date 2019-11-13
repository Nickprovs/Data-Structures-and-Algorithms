using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Sorting.NonComparison
{
    public static class CountingSortExtension
    {
        public static void CountingSort(this IList<int> list, int max)
        {
            int[] counts = new int[max + 1];
            foreach (var item in list)
                counts[item]++;

            var k = 0;
            for(int i = 0; i < counts.Length; i++)
            {
                for (var j = 0; j < counts[i]; j++)
                    list[k++] = i;
            }
        }
    }
}
