using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Sorting
{
    public static class BubbleSortExtension
    {
        public static void BubbleSort(this IList<int> list)
        {
            bool isSorted;
            for(int i = 0; i < list.Count; i++)
            {
                isSorted = true;
                for (var j = 1; j < list.Count - i; j++)
                {
                    if (list[j] < list[j - 1])
                    {
                        Swap(list, j, j - 1);
                        isSorted = false;
                    }

                    if (isSorted)
                        return;
                }
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
