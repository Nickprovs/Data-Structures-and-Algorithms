using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonLinearExperimentation.Exercises.Heaps
{
    public class IsMaxHeap : IRunnable
    {
        public void Run()
        {
            var numbers = new int[] { 8, 4, 5, 3, 1, 2};
            Console.WriteLine($"Array to Check: {string.Join(",", numbers)}");

            var isMaxHeap = GetIsMaxHeap(numbers);
            Console.WriteLine($"Is Max Heap: {isMaxHeap}");

        }

        private bool GetIsMaxHeap(int[] numbers)
        {
            return this.GetIsMaxHeap(numbers, 0);
        }

        private bool GetIsMaxHeap(int[] numbers, int currentIndex)
        {
            var lastParentIndex = (numbers.Length - 2) / 2;
            if (currentIndex > lastParentIndex)
                return true;

            var leftChildIndex = currentIndex * 2 + 1;
            var rightChildIndex = currentIndex * 2 + 2;

            //If the child index is greater than or equal to the length... 
            //...there is no child to check.
            var isValidParent =
                (leftChildIndex >= numbers.Length || numbers[currentIndex] >= numbers[leftChildIndex]) &&
                (rightChildIndex >= numbers.Length || numbers[currentIndex] >= numbers[rightChildIndex]);

            return isValidParent &&
                    this.GetIsMaxHeap(numbers, leftChildIndex) &&
                    this.GetIsMaxHeap(numbers, rightChildIndex);
        }
    }
}
