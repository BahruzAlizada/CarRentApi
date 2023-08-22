﻿using CoreLayer.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.RegularExpressions;

namespace CoreLayer.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache memoryCache;
        public MemoryCacheManager()
        {
            memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            memoryCache.Set(key, value, TimeSpan.FromMinutes(duration)); // Nə zaman Keşdən uçacaq
        }

        public T Get<T>(string key)
        {
            return memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return memoryCache.Get(key);  // Gətirəndə unboxing etmək lazmdır
        }

        public bool IsAdd(string key)
        {
            return memoryCache.TryGetValue(key, out _); // Out _ - Bir şeylər döndürməsini istəmiyəndə bu cür yazılır
        }

        public void Remove(string key)
        {
            memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern) // Kodu çalışma anında müdaxilə etmək Reflectiondur.
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                memoryCache.Remove(key);
            }
        }
    }
}