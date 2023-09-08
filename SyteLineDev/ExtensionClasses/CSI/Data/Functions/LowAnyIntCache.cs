using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.Functions
{
    public class LowAnyIntCache : ILowAnyInt
    {
        readonly ILowAnyInt lowAnyInt;
        readonly ICache methodResultCache;

        public LowAnyIntCache(ILowAnyInt lowAnyInt, IMemoryBasedCache methodResultCache)
        {
            this.lowAnyInt = lowAnyInt;
            this.methodResultCache = methodResultCache;
        }

        public int? LowAnyIntFn(string DataType)
        {
            string key = $"{this.GetType().FullName}_{DataType}";
            if (methodResultCache.TryGet(key, out LowAnyIntCacheValue cachedVal))
                return cachedVal.Value;

            var lowAnyIntCacheValue = new LowAnyIntCacheValue(lowAnyInt.LowAnyIntFn(DataType));
            methodResultCache.Insert(key, lowAnyIntCacheValue);
            return lowAnyIntCacheValue.Value;
        }

        internal class LowAnyIntCacheValue : ICachable
        {
            public LowAnyIntCacheValue(int? value)
            {
                this.Value = value;
            }
            public int? Value { get; }
        }
    }
}
