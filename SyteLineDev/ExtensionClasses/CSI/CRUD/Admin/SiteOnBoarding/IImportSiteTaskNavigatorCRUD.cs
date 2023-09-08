using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IImportSiteTaskNavigatorCRUD
    {
        ICollectionLoadResponse ReadAvailableTask(string site);
    }
}
