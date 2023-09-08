using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Serializer
{
    public interface ISerializer
    {
        T Deserialize<T>(string value);
        string Serialize<T>(T obj);
    }
}
