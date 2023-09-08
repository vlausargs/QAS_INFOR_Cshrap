using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class LowIntCacheFactory : ILowIntFactory
    {
        public ILowInt Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _LowInt = new LowIntFactory().Create(appDB,mgInvoker,parameterProvider,calledFromIDO);
            var _LowIntCache = new LowIntCache(_LowInt);

            return _LowIntCache;
        }
    }
}
