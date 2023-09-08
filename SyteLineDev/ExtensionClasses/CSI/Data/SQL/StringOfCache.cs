using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.Cache;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class StringOfCache : IStringOf
    {
        readonly ICache methodResultCache;
        readonly IStringOf stringOf;

        public StringOfCache(IStringOf stringOf, ICache methodResultCache)
        {
            this.stringOf = stringOf;
            this.methodResultCache = methodResultCache;
        }

        public string StringOfFn(string Parm)
        {
            StringOfCacheValue val;
            if (methodResultCache.TryGet(Parm, out val))
                return val.StringOfValue;

            string retVal = stringOf.StringOfFn(Parm);
            methodResultCache.Insert(Parm, new StringOfCacheValue(retVal));
            return retVal;
        }

        internal class StringOfCacheValue : ICachable
        {
            public string StringOfValue { get; }
            public StringOfCacheValue(string value)
            {
                StringOfValue = value;
            }
        }
    }
}
