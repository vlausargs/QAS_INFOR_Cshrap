using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG.MGCore;
using CSI.MG;


namespace CSI.Data.SQL
{
    public class LowCharacterCache: ILowCharacter
    {
        readonly ILowCharacter lowCharacter;
        string lowCharacterCacheValue;

        public LowCharacterCache(ILowCharacter lowCharacter)
        {
            this.lowCharacter = lowCharacter;
        }

        public string LowCharacterFn()
        {
            if (lowCharacterCacheValue != null)
                return lowCharacterCacheValue;
            lowCharacterCacheValue = lowCharacter.LowCharacterFn();
            return lowCharacterCacheValue;
        }
    }
}
