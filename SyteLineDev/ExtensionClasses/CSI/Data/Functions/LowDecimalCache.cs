using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.Functions
{
    public class LowDecimalCache : ILowDecimal
    {
        readonly ILowDecimal lowDecimal;
        readonly ICache methodResultCache;

        public LowDecimalCache(ILowDecimal lowDecimal, IMemoryBasedCache methodResultCache)
        {
            this.lowDecimal = lowDecimal;
            this.methodResultCache = methodResultCache;
        }

        public decimal? LowDecimalFn(string DataType)
        {
            string key = $"{this.GetType().FullName}_{DataType}";
            if (methodResultCache.TryGet(key, out LowDecimalCacheValue cachedVal))
                return cachedVal.Value;

            var lowDecimalCacheValue = new LowDecimalCacheValue(lowDecimal.LowDecimalFn(DataType));
            methodResultCache.Insert(key, lowDecimalCacheValue);
            return lowDecimalCacheValue.Value;
        }

        internal class LowDecimalCacheValue : ICachable
        {
            public LowDecimalCacheValue(decimal? value)
            {
                this.Value = value;
            }
            public decimal? Value { get; }
        }
    }
}
