using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class LowIntCache: ILowInt
    {
        readonly ILowInt lowInt;
        int? lowIntCacheValue;

        public LowIntCache(ILowInt lowInt)
        {
            this.lowInt = lowInt;
        }

        public int? LowIntFn()
        {
            if (lowIntCacheValue != null)
                return lowIntCacheValue;
            lowIntCacheValue = lowInt.LowIntFn();
            return lowIntCacheValue;
        }
    }
}
