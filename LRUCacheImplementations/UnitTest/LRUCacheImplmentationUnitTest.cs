using System;
using LRUCacheImplemenation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class LRUCacheImplmentationUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCacheEntryMulitpleTimesThorowsArgumentExceptionError()
        {
            LRUCache<int, int> LRUCacheTest = new LRUCache<int, int>();
            LRUCacheTest.AddCacheEntry(10, 100);
            LRUCacheTest.AddCacheEntry(10, 100);
        }
        [TestMethod]
        public void AddingCatchedItemAndGettingthesameCatcheUsingKeys()
        {
            LRUCache<int, int> LRUCacheTest = new LRUCache<int, int>();
            LRUCacheTest.AddCacheEntry(10, 100);
            int cacheValue = LRUCacheTest.GetCacheEntry(10);
            Assert.AreEqual(cacheValue, 100);
        }
        [TestMethod]
        public void LeastRecentlyUsedCache()
        {
            LRUCache<int, int> LRUCacheTest = new LRUCache<int, int>();
            LRUCacheTest.CACHE_SIZE = 5;
            LRUCacheTest.AddCacheEntry(10, 100);
            LRUCacheTest.AddCacheEntry(20, 120);
            LRUCacheTest.AddCacheEntry(30, 130);
            LRUCacheTest.AddCacheEntry(40, 140);
            LRUCacheTest.AddCacheEntry(50, 150);
            LRUCacheTest.AddCacheEntry(60, 160);

            int actualValue = LRUCacheTest.GetCacheEntry(30);
            Assert.AreEqual(actualValue, 130);
        }

    }
}
