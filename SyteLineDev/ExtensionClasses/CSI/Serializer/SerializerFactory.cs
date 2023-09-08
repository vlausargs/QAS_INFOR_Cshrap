using System;
using CSI.Serializer;
namespace CSI.Serializer
{
    public class SerializerFactory : ISerializerFactory
    {
        public ISerializer Create(SerializerType serializerType)
        {
            if (serializerType == SerializerType.NewtonConvert)
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings() { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
                return new NewtonSoftJsonConvertSerializer(settings);
            }
            else return new NullSerializer();
        }

    }
}
