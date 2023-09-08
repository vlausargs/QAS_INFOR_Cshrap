using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.Cache;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class LowStringCacheFactory : ILowStringFactory
    {
        public ILowString Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var methodResultCache = new IDOMethodCallBoundedMemoryCache();
            var _LowString = new LowStringFactory().Create(cSIExtensionClassBase);
            var _HighStringCache = new LowStringCache(_LowString, methodResultCache);

            return _HighStringCache;
        }

    }
}
