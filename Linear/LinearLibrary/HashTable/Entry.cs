using System;
using System.Collections.Generic;
using System.Text;

namespace LinearLibrary.HashTable
{
    internal class Entry
    {
        public int Key { get; set; }

        public string Value { get; set; }

        public Entry(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
