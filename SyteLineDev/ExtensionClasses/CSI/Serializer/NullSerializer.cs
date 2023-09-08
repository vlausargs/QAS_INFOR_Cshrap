using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Serializer
{
    public class NullSerializer : ISerializer
    {
        public T Deserialize<T>(string value)
        {
            return default(T);
        }

        public string Serialize<T>(T obj)
        {
            return "";
        }
    }
}
