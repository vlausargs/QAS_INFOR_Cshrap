using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Cache;

namespace CSI.Admin
{
    public class IsFeatureActiveCache : IIsFeatureActive
    {
        readonly IIsFeatureActive isFeatureActive;
        readonly ICache methodResultCache;

        public IsFeatureActiveCache(IIsFeatureActive isFeatureActive, IMemoryBasedCache methodResultCache)
        {
            this.isFeatureActive = isFeatureActive;
            this.methodResultCache = methodResultCache;
        }

        // for bounce
        public int? IsFeatureActiveFn(string ProductName, string FeatureID)
        {
            string cacheKey = GetKey(ProductName, FeatureID);
            IsFeatureActiveCacheValue val;
            int? ReturnCode;
            int? FeatureActive;
            string InfoBar;
            if (methodResultCache.TryGet(cacheKey, out val))
            {
                (ReturnCode, FeatureActive, InfoBar) = val.Value;
                return FeatureActive;
            }

            var isFeaturedActiveFnCacheValue = new IsFeatureActiveCacheValue((0, isFeatureActive.IsFeatureActiveFn(ProductName, FeatureID), string.Empty));
            (ReturnCode, FeatureActive, InfoBar) = val.Value;
            return FeatureActive;
        }

        public (int? ReturnCode, int? FeatureActive, string InfoBar) IsFeatureActiveSp(string ProductName = "CSI", string FeatureID = null, int? FeatureActive = 0, string InfoBar = null)
        {
            string cacheKey = GetKey(ProductName, FeatureID);
            IsFeatureActiveCacheValue cachedVal;

            if (methodResultCache.TryGet(cacheKey, out cachedVal))
                return cachedVal.Value;

            var isFeatureActiveCacheValue = new IsFeatureActiveCacheValue(isFeatureActive.IsFeatureActiveSp(ProductName, FeatureID, FeatureActive, InfoBar));
            methodResultCache.Insert(cacheKey, isFeatureActiveCacheValue);
            return isFeatureActiveCacheValue.Value;
        }

        private string GetKey(string ProductName, string FeatureID)
        {
            return ProductName + "|" + FeatureID;
        }

        internal class IsFeatureActiveCacheValue : ICachable
        {
            public IsFeatureActiveCacheValue((int? returnCode, int? featureActive, string infobar) value)
            {
                this.Value = value;
            }
            public (int? ReturnCode, int? FeatureActive, string InfoBar) Value { get; }
        }
    }
}
