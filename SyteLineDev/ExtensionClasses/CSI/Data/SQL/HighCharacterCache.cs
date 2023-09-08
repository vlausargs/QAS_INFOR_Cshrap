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
    public class HighCharacterCache: IHighCharacter
    {
        readonly IHighCharacter highCharacter;
        string highCharacterCacheValue;

        public HighCharacterCache(IHighCharacter highCharacter)
        {
            this.highCharacter = highCharacter;
        }

        public string HighCharacterFn()
        {
            if (highCharacterCacheValue != null)
                return highCharacterCacheValue;
            highCharacterCacheValue = highCharacter.HighCharacterFn();
            return highCharacterCacheValue;
        }
    }
}
