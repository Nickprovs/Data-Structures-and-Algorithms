using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgorithmsLibrary.Sorting
{
    public static class MergeSortExtension
    {
        public static void MergeSort(this IList<int> list)
        {
            //Base condition
            //An array w/ a single item does not need to be halved, sorted, etc.
            if (list.Count < 2)
                return;

            //Divide this array into half
            var middle = list.Count / 2;

            var left = new int[middle];
            for (var i = 0; i < middle; i++)
                left[i] = list[i];

            int[] right = new int[list.Count - middle];
            for (var i = middle; i < list.Count; i++)
                right[i - middle] = list[i];

            //Sort each half
            MergeSort(left);
            MergeSort(right);

            //Merge the result
            Merge(left, right, list);
        }

        private static void Merge(int[] left, int[] right, IList<int> result)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while(i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }

            while (i < left.Length)
                result[k++] = left[i++];

            while (j < right.Length)
                result[k++] = right[j++];
        }
    }
}
