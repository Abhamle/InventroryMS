using Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LRUCacheImplemenation
{

    public class CacheEntry<K, T>
    {
        public CacheEntry(K _key, T _value)
        {
            Key = _key;
            Value = _value; ;
            Next = null;
            Prev = null;
        }

        public K Key { get; set; }
        public T Value { get; set; }
        public CacheEntry<K, T> Next { get; set; }
        public CacheEntry<K, T> Prev { get; set; }

    }
    public class LRUCache<K, T>
    {
        public int CACHE_SIZE = 5;

        Dictionary<K, CacheEntry<K, T>> CashDictionary;
        public CacheEntry<K, T> Head { get; set; }
        public CacheEntry<K, T> Tail { get; set; }
        public int Count { get; set; }

        public LRUCache()
        {
            CashDictionary = new Dictionary<K, CacheEntry<K, T>>();

        }
        /// <summary>
        /// To access entry from cache, 1st lookup in the cache/dlinked using the key, if found remove from the current location, 
        /// and move it to the top of the cache/dlinked. If not found return -1;
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetCacheEntry(K key)
        {
            if (CashDictionary.ContainsKey(key))
            {
                CacheEntry<K, T> cachEntry = CashDictionary[key];
                //if the element is the only element in the cache OR If it at the top of the cacheList then return the element
                if (Count == 1 || Head == cachEntry)
                {
                    return cachEntry.Value;
                }
                RemoveNode(cachEntry);
                AddTopNode(cachEntry);
                return cachEntry.Value;
            }
            else
            {
                //get it directly from db or any remote storage/ actual data. 
                RemoteAccess<T> ActualData = new RemoteAccess<T>();
                return ActualData.GetActualData();
            }
        }
        private void AddTopNode(CacheEntry<K, T> entry)
        {
            //Save of the head node, so we don't lose it. 
            CacheEntry<K, T> temp = Head;
            //Point Head to the new node. 
            Head = entry;
            //Insert the rest of the list behind the Head. 
            Head.Next = temp;
            Count++;
            if (Count == 1)
            {
                //if the list is empty both Tail and Head should point to the new node; other the tail will be intacted. 
                Tail = Head;
            }
            else
            {
                //here always link the previous node of the old head to the new HEAD, if the count is more than 2
                temp.Prev = Head;
            }
        }

        /// <summary>
        /// This will Remove Node from any location in the list when it is accessed so that we can take it to the top of the list. 
        /// </summary>
        /// <param name="entry"></param>
        private void RemoveNode(CacheEntry<K, T> entry)
        {
            if (entry == Tail)
            {
                RemoveLastNode();
            }
            var temp = entry.Prev;
            temp.Next = entry.Next;
            Count--;

        }
        //This will always add new Entry to the top of the node 
        public void AddCacheEntry(K key, T value)
        {

            CacheEntry<K, T> newCacheItem = new CacheEntry<K, T>(key, value);
            CashDictionary.Add(key, newCacheItem);
            //Here check the capacity of the cache before adding and if it reaches the limit remove from the last cacheList
            if (Count == CACHE_SIZE)
            {
                RemoveLastNode();
            }
            AddTopNode(newCacheItem);
        }
        //This will remove the last Node 
        private void RemoveLastNode()
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }

            Count--;
        }
        public void ClearCache()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
    }

}
