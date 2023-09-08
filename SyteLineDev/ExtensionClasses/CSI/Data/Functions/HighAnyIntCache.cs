using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.Functions
{
    public class HighAnyIntCache : IHighAnyInt
    {
        readonly IHighAnyInt highAnyInt;
        readonly ICache methodResultCache;

        public HighAnyIntCache(IHighAnyInt highAnyInt, IMemoryBasedCache methodResultCache)
        {
            this.highAnyInt = highAnyInt;
            this.methodResultCache = methodResultCache;
        }

        public int? HighAnyIntFn(string DataType)
        {
            string key = $"{this.GetType().FullName}_{DataType}";
            if (methodResultCache.TryGet(key, out HighAnyIntCacheValue cachedVal))
                return cachedVal.Value;

            var highAnyIntCacheValue = new HighAnyIntCacheValue(highAnyInt.HighAnyIntFn(DataType));
            methodResultCache.Insert(key, highAnyIntCacheValue);
            return highAnyIntCacheValue.Value;
        }

        internal class HighAnyIntCacheValue : ICachable
        {
            public HighAnyIntCacheValue(int? value)
            {
                this.Value = value;
            }
            public int? Value { get; }
        }

    }
}
