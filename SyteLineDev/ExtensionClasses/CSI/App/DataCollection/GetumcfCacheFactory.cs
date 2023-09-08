using CSI.Data.Cache;
using CSI.Data.SQL;
using CSI.MG;

namespace CSI.DataCollection
{
    public class GetumcfCacheFactory
    {
        public IGetumcf Create(IApplicationDB appDB,
         IMGInvoker mgInvoker,
         IParameterProvider parameterProvider,
         bool calledFromIDO)
        {
            var methodCallResultCache = new IDOMethodCallBoundedMemoryCache();
            var _Getumcf = new Getumcf(appDB);
            var _getumcfCache = new GetumcfCache(_Getumcf, methodCallResultCache);
            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetumcfExt = timerfactory.Create<DataCollection.IGetumcf>(_getumcfCache);

            return iGetumcfExt;
        }

        public IGetumcf Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var methodCallResultCache = cSIExtensionClassBase.MemoryCache;
            var _Getumcf = new Getumcf(appDB);
            var _getumcfCache = new GetumcfCache(_Getumcf, methodCallResultCache);
            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetumcfExt = timerfactory.Create<DataCollection.IGetumcf>(_getumcfCache);

            return iGetumcfExt;
        }

        public IGetumcf Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var methodCallResultCache = cSIExtensionClassBase.MemoryCache;
            var _Getumcf = new Getumcf(appDB);
            var _getumcfCache = new GetumcfCache(_Getumcf, methodCallResultCache);
            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetumcfExt = timerfactory.Create<DataCollection.IGetumcf>(_getumcfCache);

            return iGetumcfExt;
        }
    }
}
