﻿
using System;

namespace LinearLibrary.LinkedListSingle
{
    public class LinkedListSingle
    {
        #region Fields

        private NodeSingle _first;

        private NodeSingle _last;

        private int _size;

        #endregion

        #region Non Public Methods

        /// <summary>
        /// Adds to the end of the Singularly Linked List
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(int item)
        {
            var node = new NodeSingle(item);

            if (this.IsEmpty())
                this._first = this._last = node;
            else
            {
                this._last.Next = node;
                this._last = node;
            }

            this._size++;
        }

        /// <summary>
        /// Adds to the beginning of the Singularly Linked List
        /// </summary>
        /// <param name="item"></param>
        public void AddFirst(int item)
        {
            var node = new NodeSingle(item);

            if (this.IsEmpty())
                this._first = this._last = node;
            else
            {
                node.Next = this._first;
                this._first = node;
            }

            this._size++;
        }

        /// <summary>
        /// Removes the first element in the list
        /// </summary>
        /// <param name="item"></param>
        public int RemoveFirst()
        {
            if(this.IsEmpty())
                throw new InvalidOperationException("The list is empty");

            var firstSaved = this._first.Value;

            if(this._first == this._last)
            {
                this._first = this._last = null;
                this._size--;
                return firstSaved;
            }

            var second = this._first.Next;
            this._first = null;
            this._first = second;
            this._size--;
            return firstSaved;
        }

        /// <summary>
        /// Returns the last element in the list
        /// </summary>
        public int RemoveLast()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException("The list is empty");

            var lastSaved = this._last.Value;

            if (this._first == this._last)
            {
                this._first = this._last = null;
                this._size--;
                return lastSaved;
            }

            var secondToLast = this.GetPreviousNode(this._last);
            this._last = secondToLast;
            this._last.Next = null;
            this._size--;
            return lastSaved;
        }

        /// <summary>
        /// Gets the size of this list
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this._size;
        }

        /// <summary>
        /// Converts the linkedlist to an array
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            int[] array = new int[this._size];
            var current = this._first;
            var index = 0;
            while (current != null)
            {
                array[index] = current.Value;
                current = current.Next;
                index++;
            }

            return array;
        }

        /// <summary>
        /// Returns the index of the found item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(int item)
        {
            int index = 0;
            var current = this._first;
            while (current != null)
            {
                if (current.Value == item)
                    return index;
                current = current.Next;
                index++;
            }

            return -1;
        }

        /// <summary>
        /// Returns whether or not our list contains a given item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(int item)
        {
            return this.IndexOf(item) != -1;
        }

        /// <summary>
        /// Reverses the LinkedList in place
        /// </summary>
        public void Reverse()
        {
            if (this.IsEmpty())
                return;

            var previous = this._first;
            var current = this._first.Next;

            while(current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            this._last = this._first;
            this._last.Next = null;
            this._first = previous;
        }

        /// <summary>
        /// Gets the kth node from the end
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetKthFromTheEnd(int k)
        {
            if (this.IsEmpty())
                throw new InvalidOperationException("Can't get Kth from the end if there's no elements in the LinkedList");

            var a = this._first;
            var b = this._first;

            //Give b a head start of k in list traversal
            for(int i = 0; i < k - 1; i++)
            {
                b = b.Next;
                if (b == null)
                    throw new ArgumentOutOfRangeException(nameof(k), "k must be less than or equal to the length of the LinkedList");
            }

            //Now crawl along the list setting a and b until b reaches the end
            //It's key that we compare against the last and not null
            while(b != this._last)
            {
                a = a.Next;
                b = b.Next;
            }

            //Once b reaches the end... a will contain the kth value from the end.
            return a.Value;
        }

        /// <summary>
        /// Prints the middle of the list assuming we don't know the size
        /// Note: If the length of the list is even... prints both at middle
        /// </summary>
        public void PrintMiddle()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException("Can't get middle if there's no elements in the LinkedList");

            var a = this._first;
            var b = this._first;

            while (b != this._last && b.Next != this._last)
            {
                b = b.Next.Next;            
                a = a.Next;
            }

            if(b == this._last)    
                Console.WriteLine($"Middle: {a.Value}");        
            else
                Console.WriteLine($"Even List w/ Middle 1: {a.Value}, 2: {a.Next.Value}");
        }

        /// <summary>
        /// Creates a singly linkedlist where the last element's next references another element prior
        /// </summary>
        public static LinkedListSingle CreateWithLoop()
        {
            LinkedListSingle myList = new LinkedListSingle();
            myList.AddLast(1);
            myList.AddLast(2);
            myList.AddLast(3);
            var thirdElement = myList._last;
            myList.AddLast(4);
            myList.AddLast(5);
            myList._last.Next = thirdElement;

            return myList;
        }

        /// <summary>
        /// Detects if a node in the linkedlist references a previous node
        /// </summary>
        /// <returns></returns>
        public bool HasLoop()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException("An empty linked list can't loop.");

            var a = this._first;
            var b = this._first;

            while (b != null)
            {
                b = b.Next.Next;
                a = a.Next;

                if (b == a)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Merge sort
        /// </summary>
        private void MergeSort()
        {
            this._first = this.MergeSort(this._first);
            this._last = this.GetLastNode(this._first);
        }

        //The main function
        private NodeSingle MergeSort(NodeSingle head)
        {
            if (head == null || head.Next == null)
                return head;

            //Get the middle of the list
            var middle = this.GetMiddleNode(head);

            //Split the list into two halfs
            var leftHead = head;
            var rightHead = middle.Next;
            middle.Next = null;             

            return this.Merge(this.MergeSort(leftHead), this.MergeSort(rightHead));
        }

        //Merge subroutine to merge two sorted lists
        private NodeSingle Merge(NodeSingle a, NodeSingle b)
        {
            NodeSingle dummyHead = new NodeSingle(-1);

            NodeSingle current;
            for (current = dummyHead; a != null && b != null; current = current.Next)
            {
                if (a.Value <= b.Value)
                {
                    current.Next = a;
                    a = a.Next;
                }
                else
                {
                    current.Next = b;
                    b = b.Next;
                }

            }
            current.Next = (a == null) ? b : a;
            return dummyHead.Next;
        }

        //Finding the middle element of the list for splitting
        private NodeSingle GetMiddleNode(NodeSingle head)
        {
            if (head == null)
                return head;

            NodeSingle slow = head, fast = head;

            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        private NodeSingle GetLastNode(NodeSingle head)
        {
            if (head == null)
                throw new InvalidOperationException("No last available in an empty list");

            var current = head;
            while (current.Next != null)
                current = current.Next;

            return current;
        }



        #endregion

        #region Public Methods

        public void Sort()
        {
            this.MergeSort();
        }

        /// <summary>
        /// Determines if the list is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this._first == null;
        }

        /// <summary>
        /// Gets the previous node for a given node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private NodeSingle GetPreviousNode(NodeSingle node)
        {
            var current = this._first;
            while (current != null)
            {
                if (current.Next == node)
                    return current;

                current = current.Next;
            }
            return null;
        }

        #endregion
    }
}
