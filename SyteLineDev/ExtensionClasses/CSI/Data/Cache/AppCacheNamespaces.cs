using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Cache
{
    public class CacheKeyGenerator
    {
        public string IdoMethodCallBoundedMemoryCacheKey(IdoMethodCallBoundedMemoryCacheNamespace space, string entry)
            => Enum.GetName(typeof(IdoMethodCallBoundedMemoryCacheNamespace), space) + entry;
        public string MGSessionVariableBasedCacheKey(MGSessionVariableBasedCacheNamespace space, string entry)
            => Enum.GetName(typeof(MGSessionVariableBasedCacheNamespace), space) + entry;
    }
}