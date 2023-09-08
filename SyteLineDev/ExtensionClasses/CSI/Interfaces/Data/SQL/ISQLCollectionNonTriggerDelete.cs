using CSI.Data.CRUD;

namespace CSI.Data.SQL
{
    public interface ISQLCollectionNonTriggerDelete
    {
        void DeleteWithoutTrigger(ICollectionNonTriggerDeleteRequest deleteRequest);
    }
}