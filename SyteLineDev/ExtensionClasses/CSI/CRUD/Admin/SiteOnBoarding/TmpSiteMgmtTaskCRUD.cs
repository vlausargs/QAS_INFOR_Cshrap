using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class TmpSiteMgmtTaskCRUD : ITmpSiteMgmtTaskCRUD
    {
        private readonly ITmpSiteMgmtTaskLoadColumnsCRUD _tmpSiteMgmtTaskLoadColumnsCRUD;
        private readonly ICollectionInsertRequestFactory _collectionInsertRequestFactory;
        private readonly IApplicationDB _applicationDB;
        private readonly IVariableUtil _variableUtil;
        private readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;
        private readonly ICollectionUpdateRequestFactory _collectionUpdateRequestFactory;
        private readonly IExistsChecker _existsChecker;
        private readonly ICollectionDeleteRequestFactory _collectionDeleteRequestFactory;
        private readonly ICollectionLoadBuilderRequestFactory _collectionLoadBuilderRequestFactory;

        public TmpSiteMgmtTaskCRUD(ITmpSiteMgmtTaskLoadColumnsCRUD tmpSiteMgmtTaskLoadColumnsCRUD,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            IApplicationDB applicationDB,
            IVariableUtil variableUtil,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            IExistsChecker existsChecker,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory)
        {
            _tmpSiteMgmtTaskLoadColumnsCRUD = tmpSiteMgmtTaskLoadColumnsCRUD;
            _collectionInsertRequestFactory = collectionInsertRequestFactory;
            _applicationDB = applicationDB;
            _variableUtil = variableUtil;
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
            _collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            _existsChecker = existsChecker;
            _collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            _collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
        }

        public ICollectionLoadResponse LoadTaskToDelete(string site)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"RowPointer", "RowPointer"}
                },
                tableName: "tmp_site_mgmt_task",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"site = {_variableUtil.GetQuotedValue(site)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            return _applicationDB.Load(loadRequest);
        }

        public void DeleteTask(ICollectionLoadResponse taskLoadResponse)
        {
            var taskDeleteRequest = _collectionDeleteRequestFactory.SQLDelete(
                tableName: "tmp_site_mgmt_task",
                items: taskLoadResponse.Items);

            _applicationDB.Delete(taskDeleteRequest);
        }

        public ICollectionLoadResponse ReadAvailableTask(string site)
        {
            RowPointerType rowPointer = DBNull.Value;
            TableNameType tableName = DBNull.Value;
            SiteManagementStatusType tableStatus = DBNull.Value;
            SiteManagementTaskTypeType taskType = DBNull.Value;

            var taskLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {rowPointer, "t.RowPointer"},
                    {tableName, "t.table_name"},
                    {tableStatus, "ISNULL(d.status,'I')"},
                    {taskType, "t.task_type"}
                },
                tableName: "tmp_site_mgmt_task t",
                maximumRows: 1,
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: _collectionLoadRequestFactory.Clause(
                    @"LEFT JOIN tmp_site_mgmt_table_data d ON t.site = d.site AND t.table_name = d.table_name"),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $@"(d.status = 'I' OR d.status = 'P' OR d.status IS NULL) AND (d.Level = 0 OR d.Level IS NULL) AND t.task_status = 'P' AND t.site = {_variableUtil.GetQuotedValue(site)} GROUP BY t.table_name, t.task_type, t.error_msg, t.RowPointer, d.status, t.book_mark, d.total_tasks, t.task_num, t.task_status"),
                orderByClause: _collectionLoadRequestFactory.Clause(
                    "SUM(LEN(ISNULL(Reference, '')) - LEN(REPLACE(ISNULL(Reference, ''), ',', ''))) DESC, task_type, task_num"));
            return _applicationDB.Load(taskLoadRequest);
        }


        //to do in future begin
        public bool IsExistTask(
            string site,
            string tableName,
            int taskNum,
            string bookmark,
            TaskType taskType)
        {
            return _existsChecker.Exists(
                tableName: "tmp_site_mgmt_task",
                fromClause:
                _collectionLoadRequestFactory.Clause("WITH (READUNCOMMITTED)"), // todo uncommitted
                whereClause: _collectionLoadRequestFactory.Clause(
                    $@"tmp_site_mgmt_task.task_type = {_variableUtil.GetQuotedValue(taskType.ToString("G"))} 
                    AND tmp_site_mgmt_task.site = {_variableUtil.GetQuotedValue(site)}
                    AND tmp_site_mgmt_task.table_name = {_variableUtil.GetQuotedValue(tableName)}
                    AND tmp_site_mgmt_task.book_mark = {_variableUtil.GetQuotedValue(bookmark)}
                    AND tmp_site_mgmt_task.task_num = {_variableUtil.GetQuotedValue(taskNum)}"));
        }

        public ICollectionLoadResponse LoadTaskToCreate(
            string tableName,
            string site,
            int taskNum,
            string errorMsg,
            TaskStatus taskStatus,
            TaskType taskType)
        {
            var nonTableLoadRequest = _collectionLoadBuilderRequestFactory.Create(
                columnExpressionByColumnName: new Dictionary<string, object>()
                {
                    {"site", site},
                    {"table_name", tableName},
                    {"task_num", taskNum},
                    {"status", taskStatus.ToString("G")},
                    {"error_msg", errorMsg},
                    {"task_type", (int) taskType}
                });

            return _applicationDB.Load(nonTableLoadRequest);
        }

        public void CreateTask(ICollectionLoadResponse nonTableLoadResponse)
        {
            var nonTableInsertRequest = _collectionInsertRequestFactory.SQLInsert(
                tableName: "tmp_site_mgmt_task",
                items: nonTableLoadResponse.Items);

            _applicationDB.Insert(nonTableInsertRequest);
        }

        public string ReadTaskRowPointer(
            string site,
            string tableName,
            int taskNum,
            string bookmark,
            TaskStatus taskStatus,
            TaskType taskType)
        {
            RowPointerType rowPointer = DBNull.Value;

            var taskLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {rowPointer, "RowPointer"},
                },
                maximumRows: 1,
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "tmp_site_mgmt_task",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $@"tmp_site_mgmt_task.task_status = {_variableUtil.GetQuotedValue(taskStatus.ToString("G"))} 
                    AND tmp_site_mgmt_task.task_type = {_variableUtil.GetQuotedValue(taskType.ToString("G"))} 
                    AND tmp_site_mgmt_task.site = {_variableUtil.GetQuotedValue(site)}
                    AND tmp_site_mgmt_task.table_name = {_variableUtil.GetQuotedValue(tableName)}
                    AND tmp_site_mgmt_task.book_mark = {_variableUtil.GetQuotedValue(bookmark)}
                    AND tmp_site_mgmt_task.task_num = {_variableUtil.GetQuotedValue(taskNum)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taskLoadResponse = _applicationDB.Load(taskLoadRequest);
            if (taskLoadResponse.Items.Count > 0)
                return rowPointer;
            return string.Empty;
        }

        public void UpdateTaskStatus(
            string rowPointer,
            TaskStatus taskStatus,
            string errorMsg)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"task_status", "task_status"},
                    {"error_msg", "error_msg"}
                },
                tableName: "tmp_site_mgmt_task",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"tmp_site_mgmt_task.RowPointer = {_variableUtil.GetQuotedValue(rowPointer)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taskLoadResponse = _applicationDB.Load(loadRequest);

            foreach (var item in taskLoadResponse.Items)
            {
                item.SetValue("task_status", taskStatus.ToString("G"));
                item.SetValue("error_msg", errorMsg);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(
                tableName: "tmp_site_mgmt_task",
                items: taskLoadResponse.Items);

            _applicationDB.Update(requestUpdate);
        }

        public void UpdateTaskStartTime(string rowPointer, DateTime startTime)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"start_time", "start_time"}
                },
                tableName: "tmp_site_mgmt_task",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"tmp_site_mgmt_task.RowPointer = {_variableUtil.GetQuotedValue(rowPointer)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taskResponse = _applicationDB.Load(loadRequest);

            foreach (var item in taskResponse.Items)
            {
                item.SetValue("start_time", startTime);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(
                tableName: "tmp_site_mgmt_task",
                items: taskResponse.Items);

            _applicationDB.Update(requestUpdate);
        }

        public void UpdateTaskEndTime(string rowPointer, DateTime endTime)
        {
            var loadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"end_time", "end_time"}
                },
                tableName: "tmp_site_mgmt_task",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $"tmp_site_mgmt_task.RowPointer = {_variableUtil.GetQuotedValue(rowPointer)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(""));
            var taskResponse = _applicationDB.Load(loadRequest);

            foreach (var item in taskResponse.Items)
            {
                item.SetValue("end_time", endTime);
            }

            var requestUpdate = _collectionUpdateRequestFactory.SQLUpdate(
                tableName: "tmp_site_mgmt_task",
                items: taskResponse.Items);

            _applicationDB.Update(requestUpdate);
        }

        public ICollectionLoadResponse ReadTask(string rowPointer)
        {
            TaskNumType taskNum = DBNull.Value;
            BookmarkType bookMark = DBNull.Value;
            TableNameType tableName = DBNull.Value;
            SiteManagementTaskTypeType taskType = DBNull.Value;
            SiteManagementStatusType tableStatus = DBNull.Value;
            TaskNumType tableTotalTasks = DBNull.Value;
            RefSeqType tableLevel = DBNull.Value;

            var taskLoadRequest = _collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {tableName, "t.table_name"},
                    {taskNum, "t.task_num"},
                    {bookMark, "t.book_mark"},
                    {taskType, "t.task_type"},
                    {tableStatus, "ISNULL(d.status,'I')"},
                    {tableTotalTasks, "ISNULL(d.total_tasks,0)"},
                    {tableLevel,"ISNULL(d.level,0)"}
                },
                maximumRows: 1,
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "tmp_site_mgmt_task t",
                fromClause: _collectionLoadRequestFactory.Clause(
                    @"LEFT JOIN tmp_site_mgmt_table_data d ON t.site = d.site AND t.table_name = d.table_name"),
                whereClause: _collectionLoadRequestFactory.Clause(
                    $@"t.RowPointer = {_variableUtil.GetQuotedValue(rowPointer)}"),
                orderByClause: _collectionLoadRequestFactory.Clause(
                    ""));
            return _applicationDB.Load(taskLoadRequest);
        }

        public void CreateTaskWithBookmark(
            string tableName,
            string site,
            int taskNum,
            string bookMark,
            TaskStatus taskStatus,
            TaskType taskType)
        {
            var nonTableLoadResponse = _tmpSiteMgmtTaskLoadColumnsCRUD.LoadColumnsWithBookmark(tableName, site, taskNum, bookMark, taskStatus, taskType);

            var nonTableInsertRequest = _collectionInsertRequestFactory.SQLInsert(
                tableName: "tmp_site_mgmt_task",
                items: nonTableLoadResponse.Items);

            _applicationDB.Insert(nonTableInsertRequest);
        }

        public void DeleteCompletedTask(string rowPointer)
        {
            var taskLoadResponse = _tmpSiteMgmtTaskLoadColumnsCRUD.LoadCompletedTasks(rowPointer);

            var taskDeleteRequest = _collectionDeleteRequestFactory.SQLDelete(
                tableName: "tmp_site_mgmt_task",
                items: taskLoadResponse.Items);

            _applicationDB.Delete(taskDeleteRequest);
        }

        public bool ReadExistTask(string site)
        {
            return _existsChecker.Exists(
                tableName: "tmp_site_mgmt_task WITH (READUNCOMMITTED)",
                fromClause: _collectionLoadRequestFactory.Clause(""),
                whereClause: _collectionLoadRequestFactory.Clause($"site = {_variableUtil.GetQuotedValue(site)}"));
        }
    }
}
