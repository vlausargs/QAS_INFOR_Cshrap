using CSI.Data.CRUD;

namespace CSI.CRUD.Reporting
{
    public interface IRpt_JobBOMCRUD
    {
        ICollectionLoadResponse LoadCollection(int? MOAddonAvailable);
    }
}
