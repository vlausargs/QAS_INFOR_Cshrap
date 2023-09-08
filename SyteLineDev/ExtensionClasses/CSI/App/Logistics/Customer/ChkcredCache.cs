using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Cache;

namespace CSI.Logistics.Customer
{
    public class ChkcredCache : IChkcred
    {
        readonly IChkcred chkcred;
        readonly ICache methodCallResultCache;

        public ChkcredCache(IChkcred chkcred, ICache methodCallResultCache)
        {
            this.chkcred = chkcred;
            this.methodCallResultCache = methodCallResultCache;
        }

        public (int? ReturnCode, string CredHold) ChkcredSp(string CustNum, string CredHold)
        {
            ChkcredCacheValue val;
            if (methodCallResultCache.TryGet(CustNum, out val))
                return val.Value;
            
            var chkcredCacheValue = new ChkcredCacheValue(chkcred.ChkcredSp(CustNum, CredHold));
            methodCallResultCache.Insert(CustNum, chkcredCacheValue);
            return chkcredCacheValue.Value;
        }

        internal class ChkcredCacheValue : ICachable
        {
            public (int? ReturnCode, string CredHold) Value { get; }
            public ChkcredCacheValue((int? returnCode, string credHold) value)
            {
                this.Value = value;
            }
        }
    }
}
