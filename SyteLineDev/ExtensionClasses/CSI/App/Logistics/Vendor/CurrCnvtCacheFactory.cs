using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.Cache;

namespace CSI.Logistics.Vendor
{
    public class CurrCnvtCacheFactory
    {
        public ICurrCnvt Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var methodCallResultCache = new IDOMethodCallBoundedMemoryCache();
            var _CurrCnvt = new CurrCnvtFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var currCnvtCache = new CurrCnvtCache(_CurrCnvt, methodCallResultCache);
            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCurrCnvtExt = timerfactory.Create<Logistics.Vendor.ICurrCnvt>(currCnvtCache);

            return iCurrCnvtExt;
        }

        public ICurrCnvt Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var methodCallResultCache = new IDOMethodCallBoundedMemoryCache();
            var _CurrCnvt = new CurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var currCnvtCache = new CurrCnvtCache(_CurrCnvt, methodCallResultCache);
            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCurrCnvtExt = timerfactory.Create<ICurrCnvt>(currCnvtCache);

            return iCurrCnvtExt;
        }
    }
}
