using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Exercises.Heaps
{
    public class Heapify : IRunnable
    {
        public void Run()
        {
            var numbers = new int[] { 5, 3, 8, 4, 1, 2 };
            Console.WriteLine($"Starting w/ array: {string.Join(",", numbers)}");

            this.DoHeapify(numbers);
            Console.WriteLine($"Array after heapifying: {string.Join(",", numbers)}");

        }

        private void DoHeapify(int[] numbers)
        {
            var lastParentIndex = numbers.Length / 2 - 1;
            for (int i = lastParentIndex; i >= 0; i--)
                this.DoHeapify(numbers, i);
        }

        private void DoHeapify(int[] numbers, int currentIndex)
        {
            //Assume root is largest
            var largerIndex = currentIndex;

            //If left is largest
            var leftChildIndex = currentIndex * 2 + 1;
            if (leftChildIndex < numbers.Length && numbers[leftChildIndex] > numbers[currentIndex])
                largerIndex = leftChildIndex;

            //If right is largest
            var rightChildIndex = currentIndex * 2 + 2;
            if (rightChildIndex < numbers.Length && numbers[rightChildIndex] > numbers[currentIndex])
                largerIndex = rightChildIndex;

            if (currentIndex == largerIndex)
                return;

            this.Swap(numbers, currentIndex, largerIndex);
            this.DoHeapify(numbers, largerIndex);
        }

        private void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
