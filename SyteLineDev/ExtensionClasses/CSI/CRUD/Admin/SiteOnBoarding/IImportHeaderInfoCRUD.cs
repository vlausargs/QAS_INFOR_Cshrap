using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IImportHeaderInfoCRUD
    {
        ICollectionLoadResponse GetImportHeaderInfo(string site);
        void InsertImportHeaderInfo(string site,
           string import_logical_folder,
           string archive_logical_folder,
           int use_files_to_import,
           int display_row_data,
           string remote_server,
           string configuration,
           string user_name,
           string import_action,
           string email,
           string password);
    }
}
