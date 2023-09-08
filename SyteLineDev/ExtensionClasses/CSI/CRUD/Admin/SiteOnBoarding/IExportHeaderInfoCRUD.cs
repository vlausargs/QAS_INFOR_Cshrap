using CSI.Data.CRUD;
namespace CSI.Admin.SiteOnBoarding
{
    public interface IExportHeaderInfoCRUD
    {
        ICollectionLoadResponse GetExportHeaderInfo(string site);
        void InsertExportHeaderInfo(string site,
            string export_logical_folder,
            string email,
            string file_type);
    }
}
