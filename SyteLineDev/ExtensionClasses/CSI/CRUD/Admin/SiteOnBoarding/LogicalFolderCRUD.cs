using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class LogicalFolderCRUD : ILogicalFolderCRUD
    {
        private readonly IApplicationDB _applicationDB;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IVariableUtil _variableUtil;

        public LogicalFolderCRUD(
            IApplicationDB applicationDB,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IVariableUtil variableUtil)
        {
            _applicationDB = applicationDB;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _variableUtil = variableUtil;
        }

        public (string ServerName, string FolderTemplate) ReadLogicalFolderInfo(
            string logicalFolderName)
        {
            OSMachineNameType serverName = DBNull.Value;
            FolderTemplateType folderTemplate = DBNull.Value;

            var logicFolderLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {serverName, "ServerName"},
                    {folderTemplate, "FolderTemplate"},
                },
                maximumRows: 1,
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "FileServerLogicalFolder",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"FileServerLogicalFolder.LogicalFolderName = {_variableUtil.GetQuotedValue(logicalFolderName)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));

            var logicFolderResponse = _applicationDB.Load(logicFolderLoadRequest);

            if (logicFolderResponse.Items.Count > 0)
                return (serverName, folderTemplate);
            return (string.Empty, string.Empty);
        }
    }
}