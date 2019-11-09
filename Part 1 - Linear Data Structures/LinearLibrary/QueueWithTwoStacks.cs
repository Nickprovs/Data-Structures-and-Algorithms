using System;
using System.Collections.Generic;
using System.Text;

namespace LinearLibrary
{
    public class QueueWithTwoStacks
    {
        private Stack<int> stack1;
        private Stack<int> stack2;

        public QueueWithTwoStacks()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void Enqueue(int item)
        {
            stack1.Push(item);
        }

        public int Dequeue()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException();

            this.MoveStackOneToStackTwoIfNecessary();

            return stack2.Pop();
        }

        public int Peek()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException();

            this.MoveStackOneToStackTwoIfNecessary();

            return stack2.Peek();
        }

        private void MoveStackOneToStackTwoIfNecessary()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count != 0)
                    stack2.Push(stack1.Pop());
            }
        }

        public bool IsEmpty()
        {
            return stack1.Count == 0 && stack2.Count == 0;
        }
    }
}
