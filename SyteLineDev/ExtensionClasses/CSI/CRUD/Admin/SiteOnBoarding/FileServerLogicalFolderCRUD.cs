using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IFileServerLogicalFolderCRUD
    {
        (string ServerName, string FolderTemplate, int count) GetLogicalFolderInfo(string logicalFolderName);
    }

    public class FileServerLogicalFolderCRUD : IFileServerLogicalFolderCRUD
    {
        private readonly IApplicationDB _applicationDB;
        private readonly IVariableUtil _variableUtil;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;

        public FileServerLogicalFolderCRUD(IApplicationDB applicationDB, IVariableUtil variableUtil, ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            _applicationDB = applicationDB;
            _variableUtil = variableUtil;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public (string ServerName, string FolderTemplate, int count) GetLogicalFolderInfo(string logicalFolderName)
        {
            OSMachineNameType serverName = DBNull.Value;
            FolderTemplateType folderTemplate = DBNull.Value;

            var taskLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {serverName, "ServerName"},
                    {folderTemplate, "FolderTemplate"}
                },
                maximumRows: 1,
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "FileServerLogicalFolder",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"FileServerLogicalFolder.LogicalFolderName = {_variableUtil.GetQuotedValue(logicalFolderName)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taskLoadResponse = _applicationDB.Load(taskLoadRequest);
            int rowCount = taskLoadResponse.Items.Count;
            return (serverName, folderTemplate, rowCount);
        }
    }
}
