using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ISchemaLevelCRUD
    {
        ICollectionLoadResponse GetTargetSchemaLevel();
    }
}
