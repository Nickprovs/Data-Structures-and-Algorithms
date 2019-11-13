using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Sorting.Comparison
{
    public static class SelectionSortExtension
    {
        public static void SelectionSort(this IList<int> list)
        {
            for(var i = 0; i < list.Count; i++)
            {
                var nextMinIndex = i;
                for(var j = i; j < list.Count; j++)
                {
                    if (list[j] < list[nextMinIndex])
                        nextMinIndex = j;
                }

                Swap(list, nextMinIndex, i);
            }
        }

        private static void Swap(IList<int> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
