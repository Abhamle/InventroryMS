using LRUCacheImplemenation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            LRUCache<int, int> lRUCacheImplemenation = new LRUCache<int, int>();
            lRUCacheImplemenation.AddCacheEntry(10, 100);
            lRUCacheImplemenation.AddCacheEntry(20, 200);
            Console.WriteLine(lRUCacheImplemenation.GetCacheEntry(10));
            Console.WriteLine(lRUCacheImplemenation.GetCacheEntry(40));
            lRUCacheImplemenation.AddCacheEntry(30, 300);
            lRUCacheImplemenation.AddCacheEntry(40, 400);
            lRUCacheImplemenation.AddCacheEntry(50, 500);
            lRUCacheImplemenation.AddCacheEntry(60, 600);
            lRUCacheImplemenation.AddCacheEntry(70, 700);

            lRUCacheImplemenation.ClearCache();
            lRUCacheImplemenation.CACHE_SIZE = 10;
            Console.WriteLine(lRUCacheImplemenation.GetCacheEntry(30));

        }
    }
}
