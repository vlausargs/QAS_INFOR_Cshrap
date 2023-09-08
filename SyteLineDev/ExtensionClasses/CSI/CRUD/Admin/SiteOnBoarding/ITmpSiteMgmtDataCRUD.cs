using CSI.Data.CRUD;
using CSI.MG;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITmpSiteMgmtDataCRUD
    {
        ICollectionLoadResponse ReadStateInfo(string site);

        void UpdateStateInfo(string site, SiteStatus siteStatus);

        void DeleteStateInfo(string site);

    }
}