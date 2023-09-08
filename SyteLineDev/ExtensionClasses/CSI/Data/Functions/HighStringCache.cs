using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.Cache;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class HighStringCache : IHighString
    {
        readonly IHighString highString;
        readonly ICache methodResultCache;

        public HighStringCache(IHighString highString, IMemoryBasedCache methodResultCache)
        {
            this.highString = highString;
            this.methodResultCache = methodResultCache;
        }

        public string HighStringFn(string DataType)
        {
            string key = $"{this.GetType().FullName}_{DataType}";
            HighStringCacheValue cachedVal;
            if (methodResultCache.TryGet(key, out cachedVal))
                return cachedVal.Value;

            var highStringCacheValue = new HighStringCacheValue(highString.HighStringFn(DataType));
            methodResultCache.Insert(key, highStringCacheValue);
            return highStringCacheValue.Value;
        }

        internal class HighStringCacheValue : ICachable
        {
            public HighStringCacheValue(string value)
            {
                this.Value = value;
            }
            public string Value { get; }
        }
    }
}
