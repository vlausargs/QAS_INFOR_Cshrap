using CSI.Data.CRUD;

namespace CSI.Data.Utilities
{
    public interface IUnionUtil
    {
        ICollectionLoadResponse Process();
        ICollectionLoadResponse Process(UnionType unionType, string orderBy);
        void Add(ICollectionLoadResponse collectionLoadResponse);
        void Clear();
    }
}
