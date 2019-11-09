using System;
using System.Collections.Generic;
using System.Text;

namespace LinearLibrary.HashTable
{
    public class HashTable
    {
        private LinkedList<Entry>[] _entries;

        public HashTable(int initialSize)
        {
            this._entries = new LinkedList<Entry>[initialSize];
        }

        public void Put(int key, string value)
        {
            var entry = this.GetEntry(key);
            if(entry != null)
            {
                entry.Value = value;
                return;
            }

            var bucket = this.GetOrCreateBucket(key);
            bucket.AddLast(new Entry(key, value));
        }

        public string Get(int key)
        {
            var entry = this.GetEntry(key);
            return (entry == null) ? null : entry.Value;
        }
        
        public void Remove(int key)
        {
            var entry = this.GetEntry(key);
            if(entry == null)
                throw new InvalidOperationException("Entry not found for key");

            this.GetBucket(key).Remove(entry);
        }

        private Entry GetEntry(int key)
        {
            var bucket = this.GetBucket(key);
            if (bucket == null)
                return null;

            foreach(var entry in bucket)
            {
                if (entry.Key == key)
                    return entry;
            }

            return null;
        }

        private LinkedList<Entry> GetBucket(int key)
        {
            var index = this.Hash(key);
            var bucket = this._entries[index];
            return bucket;
        }

        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            var index = this.Hash(key);
            var bucket = this._entries[index];
            if (bucket == null)
            {
                this._entries[index] = new LinkedList<Entry>();
                bucket = this._entries[index];
            }

            return bucket;
        }

        private int Hash(int key)
        {
            return key % this._entries.Length;
        }
    }
}
