using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public class ImportHeaderInfo : IImportHeaderInfo
    {
        private readonly IImportHeaderInfoCRUD _importHeaderInfoCRUD;

        public ImportHeaderInfo(IImportHeaderInfoCRUD importHeaderInfoCRUD)
        {
            this._importHeaderInfoCRUD = importHeaderInfoCRUD;
        }
        public (string import_logical_folder, 
            string archive_logical_folder, 
            int use_files_to_import,
            int display_row_data, 
            string remote_server, 
            string configuration, 
            string user_name, 
            string import_action,
            string email) 
            GetImportHeaderInfo(string site)
        {
            string import_logical_folder;
            string archive_logical_folder;
            int use_files_to_import;
            int display_row_data;
            string remote_server;
            string configuration;
            string user_name;
            string import_action;
            string email;

            ICollectionLoadResponse importHeaderInfoCollection = _importHeaderInfoCRUD.GetImportHeaderInfo(site);
            if (importHeaderInfoCollection.Items.Count == 0)
            {
                import_logical_folder = string.Empty;
                archive_logical_folder = string.Empty;
                use_files_to_import = 1;
                display_row_data = 0;
                remote_server = string.Empty;
                configuration = string.Empty;
                user_name = string.Empty;
                import_action = "I";
                email = string.Empty;
            }
            else
            {
                import_logical_folder = importHeaderInfoCollection.Items[0].GetValue<string>("import_logical_folder");
                archive_logical_folder = importHeaderInfoCollection.Items[0].GetValue<string>("archive_logical_folder");
                use_files_to_import = importHeaderInfoCollection.Items[0].GetValue<int>("use_files_to_import");
                display_row_data = importHeaderInfoCollection.Items[0].GetValue<int>("display_row_data");
                remote_server = importHeaderInfoCollection.Items[0].GetValue<string>("remote_server");
                configuration = importHeaderInfoCollection.Items[0].GetValue<string>("configuration");
                user_name = importHeaderInfoCollection.Items[0].GetValue<string>("user_name");
                import_action = importHeaderInfoCollection.Items[0].GetValue<string>("import_action");
                email = importHeaderInfoCollection.Items[0].GetValue<string>("notification_email_addr");
            }

            return (import_logical_folder, 
                archive_logical_folder,
                use_files_to_import,
                display_row_data,
                remote_server,
                configuration,
                user_name,
                import_action,
                email);
        }
    }
}
