using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingConcerns.Cashing.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //adapter pattern (adaptasyon deseni ) var olan bir sistemi kendi sistemime uyarlama 
        IMemoryCache _memoryCache; //interface 

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();  // CoreModule deki eklediğimiz Cache bellekteki karsılıgını buraya ekliyoruz 
        }
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key,value,TimeSpan.FromMinutes(duration)); //ne kadar süre verirsek o kadar süre cache de kalır 
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);  //geriye data döndürmek istemiyoruz c# kural bu
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        //intance var elimizde ve çalışma anında ona müdahele etmek istiyoruz bunu reflection(koda calısma anında mudahele olusturma ..) ile yaparız
        //bellekte cache leri entriescollection içine atar sistem
        public void RemoveByPattern(string pattern)  //bellekten silme yarayan  //verilen bir patterne göre silme işlemi yapıcak
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase); //pattern olusturma 
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
