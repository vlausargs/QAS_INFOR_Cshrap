using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Cache;
using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class IsAddonAvailableCacheFactory
    {
        public IIsAddonAvailable Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var methodCallResultCache = new IDOMethodCallBoundedMemoryCache();
            var _IsAddonAvailable = new IsAddonAvailableFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var isAddonAvailableCache = new IsAddonAvailableCache(_IsAddonAvailable, methodCallResultCache);

            return isAddonAvailableCache;
        }

        public IIsAddonAvailable Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var methodCallResultCache = cSIExtensionClassBase.MemoryCache;
            var _IsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
            var isAddonAvailableCache = new IsAddonAvailableCache(_IsAddonAvailable, methodCallResultCache);

            return isAddonAvailableCache;
        }
    }
}
