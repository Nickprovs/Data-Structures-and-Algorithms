using System;
using System.Collections.Generic;

namespace LinearLibrary
{
    public class ArrayList
    {
        #region Fields

        /// <summary>
        /// The backing array
        /// </summary>
        private int[] _items;

        #endregion

        #region Properties

        /// <summary>
        /// The number of items ACTUALLY in the array
        /// </summary>
        public int Count { get; private set; }

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes an ArrayList
        /// </summary>
        /// <param name="length"></param>
        public ArrayList(int length)
        {
            this._items = new int[length];
        }

        #endregion

        /// <summary>
        /// Adds an item to the end of the array
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(int item)
        {
            if(this._items.Length == this.Count)
            {
                int[] newItems = new int[this.Count * 2];

                for (int i = 0; i < this.Count; i++)
                    newItems[i] = this._items[i];

                this._items = newItems;
            }

            this._items[this.Count] = item;
            this.Count++;
        }
        
        /// <summary>
        /// Inserts an item at the specified index
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void Insert(int item, int index)
        {
            if (index < 0 || index >= this.Count + 1)
                throw new IndexOutOfRangeException("Index was invalid.");

            //Inserts at the end (past all numbers) are just an add
            if(index == this.Count)
            {
                this.Add(item);
                return;
            }

            if (this._items.Length == this.Count)
            {
                int[] newItems = new int[this.Count * 2];

                for (int i = 0; i < this.Count; i++)
                    newItems[i] = this._items[i];

                this._items = newItems;
            }

            //Shift items at insertion area
            for (int i = index; i < this.Count; i++)
            {
                if (this._items.Length > i + 1)
                    this._items[i] = this._items[i + 1];
            }

            this._items[index] = item;
            this.Count++;
        }

        /// <summary>
        /// Runtime Complex: O(N)
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns the index of the first occurence of item, or -1 if not found</returns>
        public int IndexOf(int item)
        {
            for(int i = 0; i < Count; i++)
            {
                if (this._items[i] == item)
                    return i;
            }

            return -1;
        }
        
        /// <summary>
        /// Removes an item at the end of the array if it is valid
        /// </summary>
        /// <param name="index">The index of the item we want to remove</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
                throw new IndexOutOfRangeException("Index was invalid.");

            //Shift items at removal area
            for (int i = index; i < this.Count; i++)
            {
                if (this._items.Length > i + 1)
                    this._items[i] = this._items[i + 1];
            }


            this.Count--;
        }

        /// <summary>
        /// Reverses the order of the elements in the array
        /// </summary>
        public void Reverse()
        {
            int[] reversed = new int[this.Count];
            for(int i = 0; i < this.Count; i++)
            {
                reversed[i] = this._items[(this.Count - 1) - i];
            }

            this._items = reversed;
        }

        /// <summary>
        /// Returns the common items between this and a secondary array
        /// </summary>
        /// <param name="secondaryCollection"></param>
        public IEnumerable<int> Intersect(IEnumerable<int> secondaryCollection)
        {
            List<int> intersection = new List<int>();
            foreach (int number in secondaryCollection)
            {
                if (this.IndexOf(number) != -1 && !intersection.Contains(number))
                    intersection.Add(number);
            }

            return intersection;
        }

        /// <summary>
        /// Prints the array on the console... for demo purposes
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < this.Count; i++)
                Console.WriteLine(this._items[i]);
        }
    }
}
