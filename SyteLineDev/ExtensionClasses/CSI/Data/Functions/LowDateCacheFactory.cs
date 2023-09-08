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
    public class LowDateCacheFactory : ILowDateFactory
    {
        public ILowDate Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _LowDate = new LowDateFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var lowDateCache = new LowDateCache(_LowDate);

            return lowDateCache;
        }
    }
}
