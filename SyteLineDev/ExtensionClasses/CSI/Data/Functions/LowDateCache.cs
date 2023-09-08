using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class LowDateCache : ILowDate
    {
        DateTime? lowDataCachedValue;
        readonly ILowDate lowDate;

        public LowDateCache(ILowDate lowDate)
        {
            this.lowDate = lowDate;
        }

        public DateTime? LowDateFn()
        {
            if (lowDataCachedValue != null)
                return lowDataCachedValue;

            lowDataCachedValue = lowDate.LowDateFn();
            return lowDataCachedValue;
        }
    }
}
