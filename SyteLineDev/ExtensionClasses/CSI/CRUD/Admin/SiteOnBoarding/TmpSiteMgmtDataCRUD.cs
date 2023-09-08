using CSI.Data;
using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class TmpSiteMgmtDataCRUD : ITmpSiteMgmtDataCRUD
    {
        private readonly IApplicationDB _applicationDB;
        private readonly IVariableUtil _variableUtil;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly ICollectionUpdateRequestFactory _collectionUpdateRequestFactory;
        private readonly ICollectionDeleteRequestFactory _collectionDeleteRequestFactory;

        public TmpSiteMgmtDataCRUD(
            IApplicationDB ApplicationDB,
            IVariableUtil variableUtil,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory)
        {
            _applicationDB = ApplicationDB;
            _variableUtil = variableUtil;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            _collectionDeleteRequestFactory = collectionDeleteRequestFactory;
        }

        public ICollectionLoadResponse ReadStateInfo(string site)
        {
            var importHeaderInfoRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "emailAddress", "notification_email_addr" },
                    { "status", "status" },
                },
                maximumRows: 1,
                loadForChange: false,
                lockingType: LockingType.UPDLock,
                tableName: "tmp_site_mgmt_data",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"site = {_variableUtil.GetQuotedValue(site)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));

            return _applicationDB.Load(importHeaderInfoRequest);
        }

        public void UpdateStateInfo(string site, SiteStatus siteStatus)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "status", "status" }
                },
                tableName: "tmp_site_mgmt_data",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"site = {_variableUtil.GetQuotedValue(site)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taskResponse = _applicationDB.Load(loadRequest);

            foreach (var item in taskResponse.Items)
            {
                item.SetValue("status", siteStatus.ToString("G"));
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(
                tableName: "tmp_site_mgmt_data",
                items: taskResponse.Items);

            _applicationDB.Update(requestUpdate);
        }

        public void DeleteStateInfo(string site)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "status", "status" }
                },
                tableName: "tmp_site_mgmt_data",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"site = {_variableUtil.GetQuotedValue(site)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));

            var taskLoadResponse = _applicationDB.Load(loadRequest);

            var taskDeleteRequest = _collectionDeleteRequestFactory.SQLDelete(
                tableName: "tmp_site_mgmt_data",
                items: taskLoadResponse.Items);

            _applicationDB.Delete(taskDeleteRequest);
        }
    }
}