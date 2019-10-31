using LinearExperimentation.Exercises.Stacks;
using LinearLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;


namespace LinearExperimentation.Demos
{
    public class ArrayBasedStackDemo : IRunnable
    {
        public void Run()
        {
            ArrayBasedStack stack = new ArrayBasedStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Console.WriteLine(stack);
            Console.WriteLine("Popping");
            Console.WriteLine($"Popped {stack.Pop()}");
            Console.WriteLine(stack);

        }
    }
}
