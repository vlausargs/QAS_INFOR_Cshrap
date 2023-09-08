using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITableNameCRUD
    {
        string ReadTableName(string appViewName);
    }

    public class TableNameCRUD : ITableNameCRUD
    {
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IVariableUtil _variableUtil;
        private readonly IApplicationDB _applicationDB;

        public TableNameCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IVariableUtil variableUtil,
            IApplicationDB applicationDB)
        {
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _variableUtil = variableUtil;
            _applicationDB = applicationDB;
        }

        public string ReadTableName(string appViewName)
        {
            TableNameType tableName = DBNull.Value;

            var taskLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {tableName, "TableName"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "AppTable",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"AppTable.AppViewName = {_variableUtil.GetQuotedValue(appViewName)}"),
                orderByClause: _collectionLoadRequestFactory.Clause("")); // task_num is not PK
            var taskLoadResponse = _applicationDB.Load(taskLoadRequest);
            if (taskLoadResponse.Items.Count > 0)
                return tableName;
            return string.Empty;
        }
    }
}