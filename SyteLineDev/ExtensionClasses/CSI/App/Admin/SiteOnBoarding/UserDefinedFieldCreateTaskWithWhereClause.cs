using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IUserDefinedFieldCreateTaskWithWhereClause
    {
        void CreateUserDefinedFieldTasks(string appViewName, string site, int taskSize, long tableRowsCount);
    }

    public class UserDefinedFieldCreateTaskWithWhereClause : IUserDefinedFieldCreateTaskWithWhereClause
    {
        private readonly IUserDefinedFieldWhereClause _userDefinedFieldWhereClause;
        private readonly IUserDefinedFieldBookmarkRowData _userDefinedFieldBookmarkRowData;
        private readonly IWhereClauseForTask _whereClauseForTask;
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly ITmpSiteMgmtTask _tmpSiteMgmtTask;

        public UserDefinedFieldCreateTaskWithWhereClause(IUserDefinedFieldWhereClause userDefinedFieldWhereClause,
            IUserDefinedFieldBookmarkRowData userDefinedFieldBookmarkRowData,
            IWhereClauseForTask whereClauseForTask,
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            ITmpSiteMgmtTask tmpSiteMgmtTask)
        {
            _userDefinedFieldWhereClause = userDefinedFieldWhereClause;
            _userDefinedFieldBookmarkRowData = userDefinedFieldBookmarkRowData;
            _whereClauseForTask = whereClauseForTask;
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _tmpSiteMgmtTask = tmpSiteMgmtTask;
        }

        public void CreateUserDefinedFieldTasks(
            string appViewName,
            string site,
            int taskSize,
            long tableRowsCount)
        {
            (int udfTasksCount, List<string> udfPrimaryKeys) = _userDefinedFieldWhereClause.GetWhereClauseCondition(tableRowsCount, taskSize);

            // Create BookMark and generate WhereClause by bookmark
            var udfTaskBookmark = string.Empty;
            for (var i = 0; i < udfTasksCount; i++)
            {
                var taskNum = i + 1;

                try
                {
                    if (i == 0)
                    {
                        udfTaskBookmark = "1=1 ";
                    }
                    else
                    {
                        var origin = taskSize - 1;
                        // use last bookmark to query next one
                        var bookmarkRow = _userDefinedFieldBookmarkRowData.GetRelevantUDFBookmarkRowData(origin, appViewName, udfTaskBookmark);
                        var bookmark = _whereClauseForTask.GetBookmark(bookmarkRow, udfPrimaryKeys);

                        udfTaskBookmark = _whereClauseForTask.WhereClauseFromBookmark(bookmark);
                    }

                    _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark($"{nameof(MGTableName.UserDefinedFields)}-{appViewName}", site, taskNum,
                        udfTaskBookmark, TaskStatus.P, TaskType.R);
                }
                catch (Exception e)
                {
                    _tmpSiteMgmtTask.CreateTask($"{nameof(MGTableName.UserDefinedFields)}-{appViewName}", site, taskNum, e.Message,
                        TaskStatus.F, TaskType.R);
                }
            }
        }
    }
}

