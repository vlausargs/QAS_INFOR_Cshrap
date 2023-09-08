using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Cache
{
    public class IDOMethodCallBoundedMemoryCache : ICache, IMemoryBasedCache
    {
        readonly Dictionary<string, ICachable> dicMemoryCache;
        public IDOMethodCallBoundedMemoryCache()
        {
            dicMemoryCache = new Dictionary<string, ICachable>();
        }

        public T Get<T>(string key) where T : ICachable
        {
            ICachable val;
            dicMemoryCache.TryGetValue(key, out val);
            return (T)val;
        }

        public void Insert(string key, ICachable value)
        {
            if(dicMemoryCache.ContainsKey(key))
                dicMemoryCache[key] = value;
            else
                dicMemoryCache.Add(key, value);
        }

        public void Remove(string key)
        {
            if(dicMemoryCache.ContainsKey(key))
                dicMemoryCache.Remove(key);
        }

        public bool TryGet<T>(string key, out T val)
        {
            ICachable cacheVal;
            bool found = dicMemoryCache.TryGetValue(key, out cacheVal);
            val = (T)cacheVal;
            return found;
        }
    }
}
