using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class HighIntCache : IHighInt
    {

        readonly IHighInt highInt;
        int? highIntCacheValue;

        public HighIntCache(IHighInt highInt)
        {
            this.highInt = highInt;
        }

        public int? HighIntFn()
        {
            if (highIntCacheValue != null)
                return highIntCacheValue;
            highIntCacheValue = highInt.HighIntFn();
            return highIntCacheValue;            
        }

    }
}
