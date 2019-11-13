using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Sorting
{
    public static class QuickSortExtension
    {
        public static void QuickSort(this IList<int> list)
        {

        }

        private static void Swap(IList<int> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
