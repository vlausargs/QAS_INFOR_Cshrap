using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.Cache;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class GetLabelCacheFactory : IGetLabelFactory
    {
        public IGetLabel Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var methodCallResultCache = new IDOMethodCallBoundedMemoryCache();
            var _GetLabel = new GetLabelFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var getLabelCache = new GetLabelCache(_GetLabel, methodCallResultCache);

            return getLabelCache;
        }
    }
}
