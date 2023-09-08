using CSI.Data.CRUD;

namespace CSI.Data.SQL
{
    public interface ISQLCollectionNonTriggerUpdate
    {
        void UpdateWithoutTrigger(ICollectionNonTriggerUpdateRequest updateRequest);
    }
}