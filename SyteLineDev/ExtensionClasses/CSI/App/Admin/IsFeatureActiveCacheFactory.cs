using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Cache;
using CSI.MG;

namespace CSI.Admin
{
    public class IsFeatureActiveCacheFactory
    {
        public IIsFeatureActive Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var methodResultCache = new IDOMethodCallBoundedMemoryCache();
            var _IsFeatureActive = new IsFeatureActiveFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var isFeatureActiveCache = new IsFeatureActiveCache(_IsFeatureActive, methodResultCache);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iIsFeatureActiveExt = timerfactory.Create<Admin.IIsFeatureActive>(isFeatureActiveCache);

            return iIsFeatureActiveExt;
        }
    }
}
