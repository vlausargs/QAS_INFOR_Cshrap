using CSI.Data.Cache;
using System;

namespace CSI.DataCollection
{
    public class GetumcfCache : IGetumcf
    {
        readonly IGetumcf getumcf;
        readonly ICache methodCallResultCache;

        public GetumcfCache(IGetumcf getumcf, ICache methodCallResultCache)
        {
            this.getumcf = getumcf;
            this.methodCallResultCache = methodCallResultCache;
        }

        public (int? ReturnCode, decimal? ConvFactor, string Infobar) GetumcfSp(string OtherUM,
            string Item,
            string VendNum,
            string Area,
            decimal? ConvFactor,
            string Infobar,
            string Site = null)
        {
            GetumcfSpCacheValue val;
            string cacheKey = GetKey(OtherUM, Item, VendNum, Area, Infobar, Site);
            if (methodCallResultCache.TryGet(cacheKey, out val))
                return val.Value;

            var getumcfCacheValue = new GetumcfSpCacheValue(getumcf.GetumcfSp(OtherUM, Item, VendNum, Area, ConvFactor, Infobar, Site));
            methodCallResultCache.Insert(cacheKey, getumcfCacheValue);
            return getumcfCacheValue.Value;
        }

        public decimal? GetumcfFn(string OtherUM,
             string Item,
             string VendNum,
             string Area)
        {
            GetumcfFnCacheValue val;
            string cacheKey = GetKey(OtherUM, Item, VendNum, Area);
            if (methodCallResultCache.TryGet(cacheKey, out val))
                return val.Value;

            var getumcfCacheValue = new GetumcfFnCacheValue(getumcf.GetumcfFn(OtherUM, Item, VendNum, Area));
            methodCallResultCache.Insert(cacheKey, getumcfCacheValue);
            return getumcfCacheValue.Value;
        }

        private string GetKey(params object[] parms)
        {
            string cacheKey = "";
            foreach (object p in parms)
            {
                cacheKey += Convert.ToString(p);
                cacheKey += "|";
            }
            return cacheKey;
        }

        internal class GetumcfSpCacheValue : ICachable
        {
            public (int? ReturnCode, decimal? ConvFactor, string Infobar) Value { get; }
            public GetumcfSpCacheValue((int? ReturnCode, decimal? ConvFactor, string Infobar) value)
            {
                this.Value = value;
            }
        }

        internal class GetumcfFnCacheValue : ICachable
        {
            public decimal? Value { get; }
            public GetumcfFnCacheValue(decimal? value)
            {
                this.Value = value;
            }
        }
    }   
}
