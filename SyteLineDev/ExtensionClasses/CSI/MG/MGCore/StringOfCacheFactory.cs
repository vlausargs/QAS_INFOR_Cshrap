using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;
using CSI.Data.Cache;

namespace CSI.MG.MGCore
{
    public class StringOfCacheFactory : IStringOfFactory
    {
        public IStringOf Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var methodResultCache = new IDOMethodCallBoundedMemoryCache();
            var _StringOf = new StringOfFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var stringOfCache = new StringOfCache(_StringOf, methodResultCache);

            return stringOfCache;
        }
    }
}
