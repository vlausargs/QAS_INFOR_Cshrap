using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class ExportHeaderInfoCRUD : IExportHeaderInfoCRUD
    {
        private readonly IApplicationDB _appDB;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly ICollectionLoadBuilderRequestFactory _collectionLoadBuilderRequestFactory;
        private readonly ICollectionInsertRequestFactory _collectionInsertRequestFactory;

        public ExportHeaderInfoCRUD(
          IApplicationDB appDB,
          ICollectionLoadRequestFactory collectionLoadRequestFactory,
          ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
          ICollectionInsertRequestFactory collectionInsertRequestFactory)
        {
            this._appDB = appDB;
            this._collectionLoadRequestFactory = collectionLoadRequestFactory;
            this._collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this._collectionInsertRequestFactory = collectionInsertRequestFactory;
        }
        public ICollectionLoadResponse GetExportHeaderInfo(string site)
        {
            var exportHeaderInfoRequest = _collectionLoadRequestFactory.SQLLoad(
            columnExpressionByColumnName: new Dictionary<string, string>()
            {
                    {"export_logical_folder", "export_logical_folder"},
                    {"notification_email_addr", "notification_email_addr"},
                    {"file_type", "file_type"}
            },
            maximumRows: 1,
            loadForChange: false,
            lockingType: LockingType.None,
            tableName: "tmp_site_mgmt_data",
            fromClause: _collectionLoadRequestFactory.Clause( ""),
            whereClause: _collectionLoadRequestFactory.Clause("site = {0}", site),
            orderByClause: _collectionLoadRequestFactory.Clause(""));
           
            return _appDB.Load(exportHeaderInfoRequest);
        } 

        public void InsertExportHeaderInfo(string site,
            string export_logical_folder,
            string email,
            string file_type)
        {
            var tmpSiteTableLoadRequest = _collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    {"site", site},
                    {"export_logical_folder", export_logical_folder},
                    {"notification_email_addr", email},
                    {"file_type", file_type},
                    {"action", "E" },
                    {"status","I" }  
                });
            var tmpSiteTableLoadResponse = _appDB.Load(tmpSiteTableLoadRequest);

            var nonTableInsertRequest = _collectionInsertRequestFactory.SQLInsert(
                tableName: "tmp_site_mgmt_data",
                items: tmpSiteTableLoadResponse.Items);

            _appDB.Insert(nonTableInsertRequest);
        }

    }
}
