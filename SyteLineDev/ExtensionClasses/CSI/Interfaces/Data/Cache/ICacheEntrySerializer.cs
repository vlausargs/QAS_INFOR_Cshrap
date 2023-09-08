using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Cache
{
    public interface ICacheEntrySerializer
    {
        ICachable Deserialize(string serialization);
        string Serialize(ICachable value);
    }
}