using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.Cache;
using CSI.Data.CRUD;

namespace CSI.Logistics.Vendor
{
    public class CurrCnvtCache : ICurrCnvt
    {
        readonly ICurrCnvt currCnvt;
        readonly ICache methodCallResultCache;
        
        public CurrCnvtCache(ICurrCnvt currCnvt, IMemoryBasedCache methodCallResultCache)
        {
            this.currCnvt = currCnvt;
            this.methodCallResultCache = methodCallResultCache;
        }

        private string GetKey(params object[] parms)
        {
            string cacheKey = this.GetType().FullName + "_";
            foreach (object p in parms)
            {
                cacheKey += Convert.ToString(p);
                cacheKey += "|";
            }
            return cacheKey;
        }

        public (int? ReturnCode, decimal? TRate, string Infobar, decimal? Result1, decimal? Result2, decimal? Result3, decimal? Result4, decimal? Result5, decimal? Result6, decimal? Result7, decimal? Result8, decimal? Result9, decimal? Result10, decimal? Result11, decimal? Result12, decimal? Result13, decimal? Result14, decimal? Result15, int? TRateD)
            CurrCnvtSp(string CurrCode, int? FromDomestic, int? UseBuyRate, int? RoundResult, DateTime? Date = null, int? RoundPlaces = null, int? UseCustomsAndExciseRates = 0, int? ForceRate = null, int? FindTTFixed = null, decimal? TRate = null, string Infobar = null, decimal? Amount1 = null, decimal? Result1 = null, decimal? Amount2 = null, decimal? Result2 = null, decimal? Amount3 = null, decimal? Result3 = null, decimal? Amount4 = null, decimal? Result4 = null, decimal? Amount5 = null, decimal? Result5 = null, decimal? Amount6 = null, decimal? Result6 = null, decimal? Amount7 = null, decimal? Result7 = null, decimal? Amount8 = null, decimal? Result8 = null, decimal? Amount9 = null, decimal? Result9 = null, decimal? Amount10 = null, decimal? Result10 = null, decimal? Amount11 = null, decimal? Result11 = null, decimal? Amount12 = null, decimal? Result12 = null, decimal? Amount13 = null, decimal? Result13 = null, decimal? Amount14 = null, decimal? Result14 = null, decimal? Amount15 = null, decimal? Result15 = null, string Site = null, string DomCurrCode = null, int? TRateD = null)
        {
            string cacheKey = GetKey(CurrCode, FromDomestic, UseBuyRate, RoundResult, Date, RoundPlaces, UseCustomsAndExciseRates,
                                   ForceRate, FindTTFixed, TRate, Amount1, Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8,
                                   Amount9, Amount10, Amount11, Amount12, Amount13, Amount14, Amount15, Site, DomCurrCode);

            CurrCnvtCacheValue val;
            if (methodCallResultCache.TryGet(cacheKey, out val))
                return val.Value;

            var currCnvtCacheValue = new CurrCnvtCacheValue(currCnvt.CurrCnvtSp(CurrCode, FromDomestic, UseBuyRate, RoundResult, Date, RoundPlaces, UseCustomsAndExciseRates,
                                   ForceRate, FindTTFixed, TRate, Infobar, Amount1, Result1, Amount2, Result2, Amount3, Result3, Amount4, Result4, Amount5,
                                   Result5, Amount6, Result6, Amount7, Result7, Amount8, Result8, Amount9, Result9, Amount10, Result10, Amount11, Result11,
                                   Amount12, Result12, Amount13, Result13, Amount14, Result14, Amount15, Result15, Site, DomCurrCode, TRateD));
            methodCallResultCache.Insert(cacheKey, currCnvtCacheValue);

            return currCnvtCacheValue.Value;
        }

        // bounce code
        public ICollectionLoadResponse CurrCnvtFn(string CurrCode, int? FromDomestic, 
            int? UseBuyRate, int? RoundResult, DateTime? Date = null, int? RoundPlaces = null, 
            int? UseCustomsAndExciseRates = 0, int? ForceRate = null, decimal? TRate = null, 
            string Site = null, string DomCurrCode = null, int? TRateD = null, 
            decimal? Amount1 = null, decimal? Amount2 = null, decimal? Amount3 = null, 
            decimal? Amount4 = null, decimal? Amount5 = null, decimal? Amount6 = null, 
            decimal? Amount7 = null, decimal? Amount8 = null, decimal? Amount9 = null, 
            decimal? Amount10 = null, decimal? Amount11 = null, decimal? Amount12 = null, 
            decimal? Amount13 = null, decimal? Amount14 = null, decimal? Amount15 = null)
        {
            string cacheKey = GetKey(CurrCode, FromDomestic, UseBuyRate, RoundResult, Date, RoundPlaces, 
                UseCustomsAndExciseRates, ForceRate, TRate, Site, DomCurrCode, TRateD, Amount1, Amount2, 
                Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, Amount11, Amount12, 
                Amount13, Amount14, Amount15);

            CurrCnvtFnCacheValue val;
            if (methodCallResultCache.TryGet(cacheKey, out val))
                return val.Value;
            var currCnvtFnCacheValue = new CurrCnvtFnCacheValue(currCnvt.CurrCnvtFn(CurrCode, FromDomestic, UseBuyRate, RoundResult, Date, RoundPlaces,
                UseCustomsAndExciseRates, ForceRate, TRate, Site, DomCurrCode, TRateD, Amount1, 
                Amount2, Amount3, Amount4, Amount5, Amount6, Amount7, Amount8, Amount9, Amount10, 
                Amount11, Amount12, Amount13, Amount14, Amount15));
            methodCallResultCache.Insert(cacheKey, currCnvtFnCacheValue);
            return currCnvtFnCacheValue.Value;
        }

        internal class CurrCnvtCacheValue : ICachable
        {
            public (int? ReturnCode, decimal? TRate, string Infobar, decimal? Result1, decimal? Result2, decimal? Result3, decimal? Result4, decimal? Result5,
            decimal? Result6, decimal? Result7, decimal? Result8, decimal? Result9, decimal? Result10, decimal? Result11, decimal? Result12, decimal? Result13,
            decimal? Result14, decimal? Result15, int? TRateD)
            Value
            { get; }

            public CurrCnvtCacheValue(
            (int? ReturnCode, decimal? TRate,
            string Infobar,
            decimal? Result1,
            decimal? Result2,
            decimal? Result3,
            decimal? Result4,
            decimal? Result5,
            decimal? Result6,
            decimal? Result7,
            decimal? Result8,
            decimal? Result9,
            decimal? Result10,
            decimal? Result11,
            decimal? Result12,
            decimal? Result13,
            decimal? Result14,
            decimal? Result15,
            int? TRateD) value)
            {
                this.Value = value;
            }
        }

        internal class CurrCnvtFnCacheValue : ICachable
        {
            public ICollectionLoadResponse Value { get; }

            public CurrCnvtFnCacheValue(ICollectionLoadResponse value)
            {
                this.Value = Value;
            }
        }
    }
}
