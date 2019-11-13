using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Sorting.Comparison
{
    public static class InsertionSortExtension
    {
        public static void InsertionSort(this IList<int> list)
        {
            for(int i = 1; i < list.Count; i++)
            {
                var current = list[i];
                var j = i - 1;
                while(j >= 0 && list[j] > current)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = current;
            }
        }
    }
}
