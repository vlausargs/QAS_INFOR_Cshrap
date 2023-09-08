using CSI.Data.SQL.UDDT;
using System;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITaskInfo
    {
        (string tableName, int taskNumber, string bookMark, TaskType taskType, TableStatus
            tableStatus, int? tableTotalTasks, int? tableLevel) ReadTask(string rowPointer);

        string GetAvailableTask(string site);
    }

    public class TaskInfo : ITaskInfo
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly IImportSiteTaskNavigatorCRUD _importSiteTaskNavigatorCRUD;

        public TaskInfo(
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            IImportSiteTaskNavigatorCRUD importSiteTaskNavigatorCRUD)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _importSiteTaskNavigatorCRUD = importSiteTaskNavigatorCRUD;
        }

        public (string tableName, int taskNumber, string bookMark, TaskType taskType, TableStatus
            tableStatus, int? tableTotalTasks, int? tableLevel) ReadTask(string rowPointer)
        {
            var result = _tmpSiteMgmtTaskCRUD.ReadTask(rowPointer);


            if (result.Items.Count == 1)
            {

                var tableName = result.Items[0].GetValue<TableNameType>(0);
                int taskNumber = result.Items[0].GetValue<TaskNumType>(1);
                string bookMark = result.Items[0].GetValue<BookmarkType>(2);
                TaskType? taskType = (TaskType)Enum.Parse(
                    typeof(TaskType),
                    result.Items[0].GetValue<SiteManagementTaskTypeType>(3));
                TableStatus tableStatus = (TableStatus)Enum.Parse(
                    typeof(TableStatus),
                    result.Items[0].GetValue<SiteManagementStatusType>(4));
                int? tableTotalTasks = result.Items[0].GetValue<TaskNumType>(5);
                int? tableLevel = result.Items[0].GetValue<RefSeqType>(6);

                return (tableName, taskNumber, bookMark, taskType.Value, tableStatus,
                    tableTotalTasks.Value, tableLevel);
            }

            return (string.Empty, 0, string.Empty, TaskType.None, TableStatus.None, 0, 0);
        }

        public string GetAvailableTask(string site)
        {
            var availableTaskResponse = _importSiteTaskNavigatorCRUD.ReadAvailableTask(site);

            return availableTaskResponse.Items.Count != 1
                ? string.Empty
                : availableTaskResponse.Items[0].GetValue<Guid>(0).ToString("D").ToUpper();
        }
    }
}