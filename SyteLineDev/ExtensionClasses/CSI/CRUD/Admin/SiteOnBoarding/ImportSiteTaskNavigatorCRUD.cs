using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class ImportSiteTaskNavigatorCRUD : IImportSiteTaskNavigatorCRUD
    {
        private readonly IApplicationDB _appDB;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly IVariableUtil _variableUtil;

        public ImportSiteTaskNavigatorCRUD(
            IApplicationDB appDB,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IVariableUtil variableUtil)
        {
            _appDB = appDB;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _variableUtil = variableUtil;
        }

        public ICollectionLoadResponse ReadAvailableTask(string site)
        {
            RowPointerType rowPointer = DBNull.Value;
            TaskNumType taskNum = DBNull.Value;
            BookmarkType bookMark = DBNull.Value;
            TableNameType tableName = DBNull.Value;
            SiteManagementTaskTypeType taskType = DBNull.Value;
            SiteManagementStatusType taskStatus = DBNull.Value;
            SiteManagementStatusType tableStatus = DBNull.Value;
            TaskNumType tableTotalTasks = DBNull.Value;
            TaskNumType refCount = DBNull.Value;


            var taskLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {rowPointer, "t.RowPointer"},
                    {taskNum, "t.task_num"},
                    {bookMark, "t.book_mark"},
                    {tableName, "t.table_name"},
                    {taskType, "t.task_type"},
                    {taskStatus, "t.task_status"},
                    {tableStatus, "ISNULL(d.status,'I')"},
                    {tableTotalTasks, "ISNULL(d.total_tasks,0)"},
                    {
                        refCount,
                        "SUM(LEN(ISNULL(Reference, '')) - LEN(REPLACE(ISNULL(Reference, ''), ',', '')))"
                    }
                },
                maximumRows: 1,
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                tableName: "tmp_site_mgmt_task t",
                fromClause: _collectionLoadRequestFactory.Clause(
                    @"LEFT JOIN tmp_site_mgmt_table_data d ON t.site = d.site AND t.table_name = d.table_name"),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $@"(d.status = 'I' OR d.status = 'P' OR d.status IS NULL) AND (d.Level = 0 OR d.Level IS NULL) AND t.task_status = 'P' AND t.site = {_variableUtil.GetQuotedValue(site)} GROUP BY t.table_name, t.task_type, t.error_msg, t.RowPointer, d.status, t.book_mark, d.total_tasks, t.task_num, t.task_status"),
                orderByClause: _collectionLoadRequestFactory.Clause(
                    "SUM(LEN(ISNULL(Reference, '')) - LEN(REPLACE(ISNULL(Reference, ''), ',', ''))) DESC, task_type, task_num"));

            return _appDB.Load(taskLoadRequest);
        }
    }
}