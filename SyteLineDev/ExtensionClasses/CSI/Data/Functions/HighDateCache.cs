using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class HighDateCache : IHighDate
    {
        readonly IHighDate highDate;
        DateTime? highDateCacheValue;

        public HighDateCache(IHighDate highDate)
        {
            this.highDate = highDate;
        }

        public DateTime? HighDateFn()
        {
            if (highDateCacheValue != null)
                return highDateCacheValue;
            highDateCacheValue = highDate.HighDateFn();
            return highDateCacheValue;
        }
    }
}
