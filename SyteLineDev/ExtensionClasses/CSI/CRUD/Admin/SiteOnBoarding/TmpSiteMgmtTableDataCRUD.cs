using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class TmpSiteMgmtTableDataCRUD : ITmpSiteMgmtTableDataCRUD
    {
        private readonly IApplicationDB _applicationDB;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly ICollectionUpdateRequestFactory _collectionUpdateRequestFactory;

        private readonly ICollectionNonTriggerUpdateRequestFactory
            _collectionNonTriggerUpdateRequestFactory;

        private readonly IVariableUtil _variableUtil;

        private readonly ICollectionLoadStatementRequestFactory
            _collectionLoadStatementRequestFactory;

        private readonly ICollectionDeleteRequestFactory _collectionDeleteRequestFactory;
        private readonly ICollectionInsertRequestFactory _collectionInsertRequestFactory;
        private readonly ICollectionLoadBuilderRequestFactory _collectionLoadBuilderRequestFactory;
        private readonly IExistsChecker _existsChecker;

        public TmpSiteMgmtTableDataCRUD(
            IApplicationDB applicationDB,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory,
            IVariableUtil variableUtil,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            IExistsChecker existsChecker)
        {
            _applicationDB = applicationDB;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            _collectionNonTriggerUpdateRequestFactory = collectionNonTriggerUpdateRequestFactory;
            _variableUtil = variableUtil;
            _collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            _collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            _collectionInsertRequestFactory = collectionInsertRequestFactory;
            _collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            _existsChecker = existsChecker;
        }

        public ICollectionLoadResponse ReadTableData(string site)
        {
            TableNameType tableName = DBNull.Value;

            var taskLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    { tableName, "table_name" }
                },
                tableName: "tmp_site_mgmt_table_data",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"tmp_site_mgmt_table_data.site = {_variableUtil.GetQuotedValue(site)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));

            return _applicationDB.Load(taskLoadRequest);
        }

        public ICollectionLoadResponse ReadTableDataCount(string tableName)
        {
            LongType tableDataCount = DBNull.Value;

            var tableDataCountLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    { tableDataCount, "COUNT(1)" },
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: tableName,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(""),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            return _applicationDB.Load(tableDataCountLoadRequest);
        }

        public void UpdateTableStatus(string site, string tableName, TableStatus tableStatus)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "status", "status" }
                },
                tableName: "tmp_site_mgmt_table_data",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"tmp_site_mgmt_table_data.site={_variableUtil.GetQuotedValue(site)} AND tmp_site_mgmt_table_data.table_name={_variableUtil.GetQuotedValue(tableName)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var tableResponse = _applicationDB.Load(loadRequest);

            foreach (var item in tableResponse.Items)
            {
                item.SetValue("status", tableStatus.ToString("G"));
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(
                tableName: "tmp_site_mgmt_table_data",
                items: tableResponse.Items);

            _applicationDB.Update(requestUpdate);
        }

        public ICollectionLoadResponse ReadPendingTableInfo(string site)
        {
            TableNameType tableName = DBNull.Value;
            TableNameType appViewName = DBNull.Value;

            var taskLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    { tableName, "AT.TableName" },
                    { appViewName, "d.table_name" }
                },
                tableName: "tmp_site_mgmt_table_data d",
                maximumRows: 1,
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: _collectionLoadRequestFactory.Clause(
                    @"LEFT JOIN AppTable AT ON d.table_name = AT.AppViewName"),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $@"d.status = 'P' AND d.site = {_variableUtil.GetQuotedValue(site)} GROUP BY d.table_name, d.Level, AT.TableName"),
                orderByClause: _collectionLoadRequestFactory.Clause(
                    @"d.Level,SUM(LEN(ISNULL(Reference, '')) - LEN(REPLACE(ISNULL(Reference, ''), ',', ''))) DESC"));
            return _applicationDB.Load(taskLoadRequest);
        }

        public void UpdateTableTotalTasksPlusOne(string site, string tableName)
        {
            var updateRequest = _collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "tmp_site_mgmt_table_data",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>
                {
                    {
                        "total_tasks",
                        _collectionNonTriggerUpdateRequestFactory.Clause("total_tasks + 1")
                    },
                },
                fromClause: _collectionNonTriggerUpdateRequestFactory.Clause(""),
                whereClause: _collectionNonTriggerUpdateRequestFactory.Clause(
                    $"tmp_site_mgmt_table_data.table_name = {_variableUtil.GetQuotedValue(tableName)} AND tmp_site_mgmt_table_data.site = {_variableUtil.GetQuotedValue(site)}"));

            _applicationDB.UpdateWithoutTrigger(updateRequest);
        }

        public void UpdateTableLevelMinusOne(string site, string tableName)
        {
            var updateRequest = _collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                tableName: "tmp_site_mgmt_table_data",
                expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>
                {
                    {
                        "Level",
                        _collectionNonTriggerUpdateRequestFactory.Clause("Level - 1")
                    },
                },
                fromClause: _collectionNonTriggerUpdateRequestFactory.Clause(""),
                whereClause: _collectionNonTriggerUpdateRequestFactory.Clause(
                    $@"table_name IN (SELECT DISTINCT T.AppViewName AS Referenced
                   FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                            INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK
                                       ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                            INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK
                                       ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                            LEFT JOIN AppTable T ON FK.TABLE_NAME = T.TableName
                   WHERE PK.TABLE_NAME = {_variableUtil.GetQuotedValue(tableName)}) AND status = 'P' AND tmp_site_mgmt_table_data.site = {_variableUtil.GetQuotedValue(site)}"));

            _applicationDB.UpdateWithoutTrigger(updateRequest);
        }

        public ICollectionLoadResponse ReadTablePrimaryKeys(string tableName)
        {
            var request = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"COLUMN_NAME", "QUOTENAME(ISC.COLUMN_NAME)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "sys.indexes AS IX",
                fromClause: _collectionLoadRequestFactory.Clause(
                    "INNER JOIN sys.index_columns AS SC ON IX.object_id = SC.object_id AND IX.index_id = SC.index_id INNER JOIN sys.sysindexkeys AS SSK ON IX.object_id = SSK.id AND SC.index_id = SSK.indid AND SC.column_id = SSK.colid INNER JOIN INFORMATION_SCHEMA.COLUMNS ISC on IX.object_id = OBJECT_ID(ISC.TABLE_NAME) AND SSK.colid = ISC.ORDINAL_POSITION"),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"IX.object_id = OBJECT_ID({_variableUtil.GetQuotedValue(tableName)}) AND IX.index_id = 1 AND ISC.COLUMN_NAME not in (SELECT SiteColumnName FROM AppTable WHERE TableName = { _variableUtil.GetQuotedValue(tableName)} AND SiteColumnName IS NOT NULL)"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            return _applicationDB.Load(request);
        }

        public ICollectionLoadResponse SiteTableDataLoad(string site)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "RowPointer", "RowPointer" }
                },
                tableName: "tmp_site_mgmt_table_data",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause("site = {0}", site),
                orderByClause: _collectionLoadRequestFactory.Clause(""));

            return _applicationDB.Load(loadRequest);
        }

        public void DeleteSiteTableData(ICollectionLoadResponse taskLoadResponse)
        {
            var taskDeleteRequest = _collectionDeleteRequestFactory.SQLDelete(
                tableName: "tmp_site_mgmt_table_data",
                items: taskLoadResponse.Items);

            _applicationDB.Delete(taskDeleteRequest);
        }

        public ICollectionLoadResponse ReadAppTableAndTableReferenceInfo()
        {
            TableNameType tableName = DBNull.Value;
            TableNameType appViewName = DBNull.Value;
            RefSeqType level = DBNull.Value;
            LongListType referenced = DBNull.Value;

            var taskLoadRequest = _collectionLoadStatementRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    { tableName, "AT.TableName" },
                    { appViewName, "AT.AppViewName" },
                    { level, "COUNT(DISTINCT KCU.TABLE_NAME)" },
                    { referenced, "R.Referenced" }
                },
                selectStatement: _collectionLoadStatementRequestFactory.Clause(
                    @";WITH tmpRef
               AS (SELECT   PK.TABLE_NAME AS TableName,
                  QUOTENAME(T.AppViewName, '''''') AS AppViewName
                  FROM     INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS C
                  INNER JOIN
                  INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS FK
                  ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                  INNER JOIN
                  INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS PK
                  ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                  LEFT OUTER JOIN
                  AppTable AS T
                  ON FK.TABLE_NAME = T.TableName
                  WHERE    T.AppViewName IS NOT NULL
                  GROUP BY PK.TABLE_NAME, T.AppViewName)
               SELECT @selectList
               FROM AppTable AS AT
               LEFT OUTER JOIN
               INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
               ON TC.TABLE_NAME = AT.TableName
               AND TC.CONSTRAINT_TYPE = 'FOREIGN KEY'
               LEFT OUTER JOIN
               (SELECT   a.TableName AS TableName,
                  (STUFF((SELECT   ',' + AppViewName
                           FROM     tmpRef
                           WHERE    TableName = a.TableName
                           ORDER BY AppViewName
                           FOR      XML PATH ('')), 1, 1, '')) AS Referenced
                  FROM     tmpRef AS a
                  GROUP BY TableName) AS R
               ON R.TableName = AT.TableName
               LEFT OUTER JOIN
               INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC
               ON TC.CONSTRAINT_NAME = RC.CONSTRAINT_NAME
               LEFT OUTER JOIN
               INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KCU
               ON KCU.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME
               AND KCU.TABLE_NAME IN (SELECT TableName
                  FROM   AppTable
                  WHERE  SiteColumnName IS NOT NULL)
               WHERE AT.SiteColumnName IS NOT NULL
               AND AT.TableName NOT LIKE 'tmp_site_mgmt%'
               AND AT.TableName NOT LIKE '%_all'
               GROUP BY AT.TableName, AT.AppViewName, R.Referenced"));

            return _applicationDB.Load(taskLoadRequest);
        }

        public ICollectionLoadResponse LoadTableData(
            string tableName,
            string site,
            string errorMsg,
            TableStatus status,
            int level,
            string referenced,
            string nullableColumn)
        {
            var nonTableLoadRequest = _collectionLoadBuilderRequestFactory.Create(
                columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    { "site", site },
                    { "table_name", tableName },
                    { "error_msg", errorMsg },
                    { "status", status.ToString("G") },
                    { "Level", level },
                    { "Reference", referenced },
                    { "isnullable_fk_reference_col", nullableColumn }
                });

            return _applicationDB.Load(nonTableLoadRequest);
        }

        public void CreateTableData(ICollectionLoadResponse nonTableLoadResponse)
        {
            var nonTableInsertRequest = _collectionInsertRequestFactory.SQLInsert(
                tableName: "tmp_site_mgmt_table_data",
                items: nonTableLoadResponse.Items);

            _applicationDB.Insert(nonTableInsertRequest);
        }

        public ICollectionLoadResponse ReadNullableForeignKeyColumn(string tableName)
        {
            var request = _collectionLoadStatementRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "NullableForeignKey", "tmptable.COLUMN_NAME" },
                },
                selectStatement: _collectionLoadStatementRequestFactory.Clause(
                    $@";WITH tmptable
                    AS (SELECT (STUFF((SELECT   ',' + tmptable.COLUMN_NAME
                                    FROM     (SELECT DISTINCT CCU.COLUMN_NAME AS COLUMN_NAME
                                        FROM   INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC
                                        INNER JOIN
                                        INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS CCU
                                        ON CCU.CONSTRAINT_NAME = TC.CONSTRAINT_NAME
                                        AND CCU.TABLE_NAME = TC.TABLE_NAME
                                        INNER JOIN
                                        INFORMATION_SCHEMA.COLUMNS AS C
                                        ON C.TABLE_NAME = CCU.TABLE_NAME
                                        AND C.COLUMN_NAME = CCU.COLUMN_NAME
                                        WHERE  TC.CONSTRAINT_TYPE = 'FOREIGN KEY'
                                        AND C.IS_NULLABLE = 'YES'
                                        AND TC.TABLE_NAME = {_variableUtil.GetQuotedValue(tableName)}) AS tmptable
                                    ORDER BY tmptable.COLUMN_NAME
                                    FOR XML PATH ('')), 1, 1, '')) AS COLUMN_NAME)
                    SELECT @selectList
                    FROM tmptable"));

            return _applicationDB.Load(request);
        }

        public string ReadTableNullableForeignKey(string site, string tableName)
        {
            // FIXME:NullableForeignKey
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "NullableForeignKey", "isnullable_fk_reference_col" }
                },
                tableName: "tmp_site_mgmt_table_data",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"tmp_site_mgmt_table_data.site={_variableUtil.GetQuotedValue(site)} AND tmp_site_mgmt_table_data.table_name={_variableUtil.GetQuotedValue(tableName)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));

            return _applicationDB.Load(loadRequest).Items[0].GetValue<string>("NullableForeignKey");
        }

        public void UpdateTotalTasksOfTableData(string site, string tableName, int totalTasks)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "total_tasks", "total_tasks" }
                },
                tableName: "tmp_site_mgmt_table_data",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"tmp_site_mgmt_table_data.table_name = {_variableUtil.GetQuotedValue(tableName)} AND tmp_site_mgmt_table_data.site = {_variableUtil.GetQuotedValue(site)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taskResponse = _applicationDB.Load(loadRequest);

            foreach (var item in taskResponse.Items)
            {
                item.SetValue("total_tasks", totalTasks);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(
                tableName: "tmp_site_mgmt_table_data",
                items: taskResponse.Items);

            _applicationDB.Update(requestUpdate);
        }

        public ICollectionLoadResponse ReadTableStateInfo(string site)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {
                        "pendingCount",
                        "SUM(CASE WHEN status = 'P' THEN 1 ELSE 0 END) AS pendingCount,"
                    },
                    {
                        "inProgressCount",
                        "SUM(CASE WHEN status = 'I' THEN 1 ELSE 0 END) AS inProgressCount"
                    },
                    {
                        "failedCount",
                        "SUM(CASE WHEN status = 'F' THEN 1 ELSE 0 END) AS failedCount"
                    }
                },
                tableName:
                "tmp_site_mgmt_table_data WITH (READUNCOMMITTED)",
                loadForChange:
                false,
                lockingType:
                LockingType.None,
                fromClause:
                _collectionLoadRequestFactory.Clause(""),
                whereClause:
                _collectionLoadRequestFactory.Clause(
                    $"tmp_site_mgmt_table_data.site={_variableUtil.GetQuotedValue(site)}"),
                orderByClause:
                _collectionLoadRequestFactory.Clause(""));

            return _applicationDB.Load(loadRequest);
        }

        public bool ReadExistInProgressTable(string site)
        {
            return _existsChecker.Exists(
                tableName: "tmp_site_mgmt_table_data WITH (READUNCOMMITTED)",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"status = {_variableUtil.GetQuotedValue(TableStatus.I.ToString("G"))} AND site = {_variableUtil.GetQuotedValue(site)}"));
        }
    }
}