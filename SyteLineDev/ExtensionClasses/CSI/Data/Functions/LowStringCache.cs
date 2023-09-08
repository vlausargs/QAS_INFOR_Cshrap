using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class LowStringCache: ILowString
    {
        readonly ILowString lowString;
        readonly ICache methodResultCache;

        public LowStringCache(ILowString lowString, IMemoryBasedCache methodResultCache)
        {
            this.lowString = lowString;
            this.methodResultCache = methodResultCache;
        }

        public string LowStringFn(string DataType)
        {
            string key = $"{this.GetType().FullName}_{DataType}";
            LowStringCacheValue cachedVal;
            if (methodResultCache.TryGet(key, out cachedVal))
                return cachedVal.Value;

            var lowStringCacheValue = new LowStringCacheValue(lowString.LowStringFn(DataType));
            methodResultCache.Insert(key, lowStringCacheValue);
            return lowStringCacheValue.Value;
        }


        internal class LowStringCacheValue : ICachable
        {
            public LowStringCacheValue(string value)
            {
                this.Value = value;
            }
            public string Value { get; }
        }

    }
}
