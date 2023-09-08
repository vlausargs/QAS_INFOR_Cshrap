using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSI.Data.Cache
{
    public class MGSessionVariableBasedCacheSerializer : ICacheEntrySerializer
    {
        readonly ICacheEntrySerializer cacheEntrySerializer = null;

        public MGSessionVariableBasedCacheSerializer(ICacheEntrySerializer cacheEntrySerializer)
        {
            this.cacheEntrySerializer = cacheEntrySerializer;
        }

        public ICachable Deserialize(string serialization)
        {
            return cacheEntrySerializer.Deserialize(serialization);
        }

        public string Serialize(ICachable value)
        {
            return cacheEntrySerializer.Serialize(value);
        }
    }
}