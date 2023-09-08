using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class ImportHeaderInfoCRUD:IImportHeaderInfoCRUD
    {
        private readonly IApplicationDB _appDB;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly ICollectionLoadBuilderRequestFactory _collectionLoadBuilderRequestFactory;
        private readonly ICollectionInsertRequestFactory _collectionInsertRequestFactory;

        public ImportHeaderInfoCRUD(
          IApplicationDB appDB,
          ICollectionLoadRequestFactory collectionLoadRequestFactory,
          ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
          ICollectionInsertRequestFactory collectionInsertRequestFactory)
        {
            _appDB = appDB;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            this._collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this._collectionInsertRequestFactory = collectionInsertRequestFactory;
        }
        public ICollectionLoadResponse GetImportHeaderInfo(string site)
        {
            var importHeaderInfoRequest = _collectionLoadRequestFactory.SQLLoad(
            columnExpressionByColumnName: new Dictionary<string, string>()
            {
                    {"import_logical_folder", "import_logical_folder"},
                    {"archive_logical_folder", "archive_logical_folder"},
                    {"use_files_to_import", "use_files_to_import"},
                    {"display_row_data", "display_row_data"},
                    {"remote_server", "remote_server"},
                    {"configuration", "configuration"},
                    {"user_name", "user_name"},
                    {"import_action", "import_action"},
                    {"notification_email_addr", "notification_email_addr"},
            },
            maximumRows: 1,
            loadForChange: false,
            lockingType: LockingType.None,
            tableName: "tmp_site_mgmt_data",
            fromClause: _collectionLoadRequestFactory.Clause(""),
            whereClause: _collectionLoadRequestFactory.Clause("site = {0}", site),
            orderByClause: _collectionLoadRequestFactory.Clause(""));

            return _appDB.Load(importHeaderInfoRequest);
        }

        public void InsertImportHeaderInfo(string site,
           string import_logical_folder,
           string archive_logical_folder,
           int use_files_to_import,
           int display_row_data,
           string remote_server,
           string configuration,
           string user_name,
           string import_action,
           string email,
           string password)
        {
            var tmpSiteTableLoadRequest = _collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    {"site", site},
                    {"import_logical_folder", import_logical_folder},
                    {"archive_logical_folder", archive_logical_folder},
                    {"notification_email_addr", email},
                    {"use_files_to_import", use_files_to_import},
                    {"display_row_data", display_row_data },
                    {"remote_server", remote_server},
                    {"configuration", configuration},
                    {"user_name", user_name},
                    {"import_action", import_action},
                    {"password", password},
                    {"action", "I" },
                    {"status","I" },
                    {"file_type","X" }
                });
            var tmpSiteTableLoadResponse = _appDB.Load(tmpSiteTableLoadRequest);

            var nonTableInsertRequest = _collectionInsertRequestFactory.SQLInsert(
                tableName: "tmp_site_mgmt_data",
                items: tmpSiteTableLoadResponse.Items);

            _appDB.Insert(nonTableInsertRequest);
        }
    }
}
