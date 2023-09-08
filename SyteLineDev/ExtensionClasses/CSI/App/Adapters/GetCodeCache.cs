using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Cache;

namespace CSI.Adapters
{
    public class GetCodeCache : IGetCode
    {
        readonly IGetCode getCode;
        readonly ICache methodCallResultCache;

        public GetCodeCache(IGetCode getCode, ICache methodCallResultCache)
        {
            this.getCode = getCode;
            this.methodCallResultCache = methodCallResultCache;
        }

        public (int? ReturnCode, string PDesc, string PAltDesc, string PLocCode, string PBaseCode) GetCodeSp(string PClass, string PCode, string PDesc = null, string PAltDesc = null, string PLocCode = null, string PBaseCode = null)
        {
            string cacheKey = GetKey(PClass, PCode);
            GetCodeCacheValue val;
            if (methodCallResultCache.TryGet(cacheKey, out val))
                return val.Value;
            
            var getCodeCacheValue = new GetCodeCacheValue(getCode.GetCodeSp(PClass, PCode, PDesc, PAltDesc, PLocCode, PBaseCode));
            methodCallResultCache.Insert(cacheKey, getCodeCacheValue);
            return getCodeCacheValue.Value;
        }

        private string GetKey(string PClass, string PCode)
        {
            return PClass + "|" + PCode;
        }

        internal class GetCodeCacheValue : ICachable
        {
            public (int? ReturnCode, string PDesc, string PAltDesc, string PLocCode, string PBaseCode) Value { get; }
            public GetCodeCacheValue((int? returnCode, string pDesc, string pAltDesc, string pLocCode, string pBaseCode) value)
            {
                this.Value = value;
            }
        }
    }
}
