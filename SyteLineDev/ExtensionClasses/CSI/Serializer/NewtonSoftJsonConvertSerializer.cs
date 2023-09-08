using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Serializer
{
    public class NewtonSoftJsonConvertSerializer : ISerializer
    {
        private Newtonsoft.Json.JsonSerializerSettings settings { get; }

        public NewtonSoftJsonConvertSerializer(Newtonsoft.Json.JsonSerializerSettings Settings)
        {
            settings = Settings;
        }


        public T Deserialize<T>(string value)
        {
            if (value == null)
                return default(T);
            else
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value,settings);
        }

        public string Serialize<T>(T obj)
        {
            if (obj == null)
                return "";
            else
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj, settings);
        }
    }
}
