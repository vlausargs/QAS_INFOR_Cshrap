namespace CSI.Data.Cache
{
    /// <summary>
    /// Any class needs to be cached. Need to implement this interface.
    /// Serialization make instance can be serialized and deserialized.
    /// </summary>
    public interface ICachable
    {
    }
    
    public interface ICache
    {
        bool TryGet<T>(string key, out T val);

        T Get<T>(string key) where T : ICachable;        
        
        void Insert(string key, ICachable value);
        
        void Remove(string key);
    }
}
