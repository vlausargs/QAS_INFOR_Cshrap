
using CSI.Data.CRUD;

namespace CSI.Admin.SiteOnBoarding
{
    public class ExportHeaderInfo : IExportHeaderInfo
    {
        private readonly IExportHeaderInfoCRUD _exportHeaderInfoCRUD;

        public ExportHeaderInfo(IExportHeaderInfoCRUD exportHeaderInfoCRUD)
        {
            this._exportHeaderInfoCRUD = exportHeaderInfoCRUD;
        }

        public (string export_logical_folder, string email, string file_type) GetExportHeaderInfo(string site)
        {
            string export_logical_folder;
            string email;
            string file_type;

            ICollectionLoadResponse exportHeaderInfoCollection = _exportHeaderInfoCRUD.GetExportHeaderInfo(site);
            if (exportHeaderInfoCollection.Items.Count == 0)
            {
                export_logical_folder = string.Empty;
                email = string.Empty;
                file_type = "X";
            }
            else
            {
                export_logical_folder = exportHeaderInfoCollection.Items[0].GetValue<string>("export_logical_folder");
                email = exportHeaderInfoCollection.Items[0].GetValue<string>("notification_email_addr");
                file_type = exportHeaderInfoCollection.Items[0].GetValue<string>("file_type"); ;
            }

            return (export_logical_folder, email, file_type);
        }
    }
}
