using LinearLibrary.HashTable;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLibrary;

namespace LinearExperimentation.Demos
{
    public class HashTableDemo : IRunnable
    {
        public void Run()
        {
            HashTable myHashTable = new HashTable(5);
            myHashTable.Put(6, "A");
            myHashTable.Put(8, "B");
            myHashTable.Put(11, "C");
            myHashTable.Put(6, "A+");
            Console.WriteLine(myHashTable.Get(8));
            myHashTable.Remove(6);
            
        }
    }
}
