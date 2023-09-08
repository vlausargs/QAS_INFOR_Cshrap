using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.Functions
{
    public class HighDecimalCache : IHighDecimal
    {
        readonly IHighDecimal highDecimal;
        readonly ICache methodResultCache;

        public HighDecimalCache(IHighDecimal highDecimal, IMemoryBasedCache methodResultCache)
        {
            this.highDecimal = highDecimal;
            this.methodResultCache = methodResultCache;
        }

        public decimal? HighDecimalFn(string DataType)
        {
            string key = $"{this.GetType().FullName}_{DataType}";
            if (methodResultCache.TryGet(key, out HighDecimalCacheValue cachedVal))
                return cachedVal.Value;

            var highDecimalCacheValue = new HighDecimalCacheValue(highDecimal.HighDecimalFn(DataType));
            methodResultCache.Insert(key, highDecimalCacheValue);
            return highDecimalCacheValue.Value;
        }

        internal class HighDecimalCacheValue : ICachable
        {
            public HighDecimalCacheValue(decimal? value)
            {
                this.Value = value;
            }
            public decimal? Value { get; }
        }
    }
}
