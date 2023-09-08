using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.Cache;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class GetLabelCache : IGetLabel
    {
        readonly IGetLabel getLabel;
        readonly ICache methodCallResultCache;

        public GetLabelCache(IGetLabel getLabel, ICache methodCallResultCache)
        {
            this.getLabel = getLabel;
            this.methodCallResultCache = methodCallResultCache;
        }

        public string GetLabelFn(string PObjectName)
        {
            string key = $"{this.GetType().FullName}_{PObjectName}";
            GetLabelCacheValue val;
            if (methodCallResultCache.TryGet(key, out val))
                return val.GetLabelValue;

            var getLabelCacheValue = new GetLabelCacheValue(getLabel.GetLabelFn(PObjectName));
            methodCallResultCache.Insert(key, getLabelCacheValue);
            return getLabelCacheValue.GetLabelValue;
        }

        internal class GetLabelCacheValue : ICachable
        {
            public string GetLabelValue { get; }
            public GetLabelCacheValue(string getLabelValue)
            {
                this.GetLabelValue = getLabelValue;
            }
        }
    }
}
