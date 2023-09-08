using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Cache;
using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Adapters
{
    public class GetCodeCacheFactory : IGetCodeFactory
    {
        public IGetCode Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var methodCallResultCache = new IDOMethodCallBoundedMemoryCache();
            var _GetCode = new GetCodeFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var getCodeCache = new GetCodeCache(_GetCode, methodCallResultCache);
            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCodeExt = timerfactory.Create<Adapters.IGetCode>(getCodeCache);

            return iGetCodeExt;
        }

        public IGetCode Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var methodCallResultCache = cSIExtensionClassBase.MemoryCache;
            var _GetCode = new GetCodeFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var getCodeCache = new GetCodeCache(_GetCode, methodCallResultCache);
            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCodeExt = timerfactory.Create<Adapters.IGetCode>(getCodeCache);

            return iGetCodeExt;
        }
    }
}
