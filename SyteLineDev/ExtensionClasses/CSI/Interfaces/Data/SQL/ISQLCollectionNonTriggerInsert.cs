using CSI.Data.CRUD;

namespace CSI.Data.SQL
{
    public interface ISQLCollectionNonTriggerInsert
    {
        void InsertWithoutTrigger(ICollectionNonTriggerInsertRequest insertRequest);
    }
}