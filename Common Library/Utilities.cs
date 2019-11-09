using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{
    public static class Utilities
    {
        public static int[] GetRandomArrayOfSize(int size)
        {
            int min = int.MinValue;
            int max = int.MaxValue;
            int[] randomArray = new int[size];
            Random randNum = new Random();
            for (int i = 0; i < size; i++)
            {
                randomArray[i] = randNum.Next(min, max);
            }

            return randomArray;
        }

    }
}
