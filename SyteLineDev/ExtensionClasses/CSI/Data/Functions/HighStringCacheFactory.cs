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
    public class HighStringCacheFactory : IHighStringFactory
    {
        public IHighString Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var methodResultCache = new IDOMethodCallBoundedMemoryCache();
            var _HighString = new HighStringFactory().Create(cSIExtensionClassBase);
            var _HighStringCache = new HighStringCache(_HighString, methodResultCache);

            return _HighStringCache;
        }
    }
}
