using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Sorting.Comparison
{
    public static class QuickSortExtension
    {
        public static void QuickSort(this IList<int> list)
        {
            QuickSort(list, 0, list.Count - 1);
        }

        private static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end)
                return;

            //Partition
            var boundary = Partition(list, start, end);

            //Sort Left
            QuickSort(list, start, boundary - 1);

            //Sort Right
            QuickSort(list, boundary + 1, end);
        }

        // Partitions given section of a list. 
        // Index of pivot after it has moved correct position
        private static int Partition(IList<int> list, int start, int end)
        {
            var pivot = list[end];
            var boundary = start - 1;

            for(var i = start; i <= end; i++)
            {
                if (list[i] <= pivot)
                    Swap(list, i, ++boundary);
            }

            return boundary;
        }

        private static void Swap(IList<int> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
