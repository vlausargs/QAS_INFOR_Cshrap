
namespace CSI.Serializer
{
    public interface ISerializerFactory
    {
        ISerializer Create(SerializerType serializerType);
    }
}