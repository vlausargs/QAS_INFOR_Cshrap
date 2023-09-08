using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ITaskDistributionCreateTaskWithWhereClause
    {
        void CreateTasksOfTable(string appViewName, string site, int taskSizex, int tasksCount, List<string> primaryKeys);
    }

    public class TaskDistributionCreateTaskWithWhereClause : ITaskDistributionCreateTaskWithWhereClause
    {
        private readonly ITaskDistributionBookmarkRowData _taskDistributionBookmarkRowData;
        private readonly IWhereClauseForTask _whereClauseForTask;
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly ITmpSiteMgmtTask _tmpSiteMgmtTask;

        public TaskDistributionCreateTaskWithWhereClause(ITaskDistributionBookmarkRowData taskDistributionBookmarkRowData,
            IWhereClauseForTask whereClauseForTask,
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            ITmpSiteMgmtTask tmpSiteMgmtTask)
        {
            _taskDistributionBookmarkRowData = taskDistributionBookmarkRowData;
            _whereClauseForTask = whereClauseForTask;
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _tmpSiteMgmtTask = tmpSiteMgmtTask;
        }

        public void CreateTasksOfTable(
            string appViewName,
            string site,
            int taskSize,
            int tasksCount,
            List<string> primaryKeys)
        {
            var taskBookmark = string.Empty;
            for (var i = 0; i < tasksCount; i++)
            {
                var taskNum = i + 1;

                try
                {
                    if (i == 0)
                    {
                        taskBookmark = "1=1 ";
                    }
                    else
                    {
                        var origin = taskSize - 1;
                        // use last bookmark to query next one
                        var bookmarkRow = _taskDistributionBookmarkRowData.GetBookmarkRowData(origin, appViewName, taskBookmark, primaryKeys);
                        var bookmark = _whereClauseForTask.GetBookmark(bookmarkRow, primaryKeys);

                        taskBookmark = _whereClauseForTask.WhereClauseFromBookmark(bookmark);
                    }

                    _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark(appViewName, site, taskNum, taskBookmark, TaskStatus.P, TaskType.E);
                }
                catch (Exception e)
                {
                    _tmpSiteMgmtTask.CreateTask(appViewName, site, taskNum, e.Message, TaskStatus.F, TaskType.E);
                }
            }
        }
    }
}
