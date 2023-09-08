using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Functions
{
    public class IsAddonAvailableCache : IIsAddonAvailable
    {
        readonly IIsAddonAvailable isAddonAvailable;
        readonly ICache methodCallResultCache;
        
        public IsAddonAvailableCache(IIsAddonAvailable isAddonAvailable, ICache methodCallResultCache)
        {
            this.isAddonAvailable = isAddonAvailable;
            this.methodCallResultCache = methodCallResultCache;
        }

        public int? IsAddonAvailableFn(string ModuleName)
        {
            IsAddonAvailableCacheValue val;
            if (methodCallResultCache.TryGet(ModuleName, out val))
                return val.IsAddonAvailableValue;

            int? isAddonAvil = isAddonAvailable.IsAddonAvailableFn(ModuleName);
            var isAddonAvailableCacheValue = new IsAddonAvailableCacheValue(isAddonAvil);
            methodCallResultCache.Insert(ModuleName, isAddonAvailableCacheValue);
            return isAddonAvil;
        }

        internal class IsAddonAvailableCacheValue : ICachable
        {
            public int? IsAddonAvailableValue { get; private set; }
            public IsAddonAvailableCacheValue(int? isAddonAvaliable)
            {
                IsAddonAvailableValue = isAddonAvaliable;
            }
        }
    }
}
