using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Cache;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ChkcredCacheFactory
    {
        public IChkcred Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var methodCallResultCache = cSIExtensionClassBase.MemoryCache;
            var _Chkcred = new ChkcredFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var chkcredCache = new ChkcredCache(_Chkcred, methodCallResultCache);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iChkcredExt = timerfactory.Create<Logistics.Customer.IChkcred>(chkcredCache);

            return iChkcredExt;
        }
    }
}
