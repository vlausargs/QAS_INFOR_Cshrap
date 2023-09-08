using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IObjectNoteCreateTaskWithWhereClause
    {
        void CreateObjectNoteTasks(string appViewName, string site, int taskSize, long tableRowsCount);
    }

    public class ObjectNoteCreateTaskWithWhereClause : IObjectNoteCreateTaskWithWhereClause
    {
        private readonly IObjectNoteWhereClause _objectNoteWhereClause;
        private readonly IObjectNoteBookmarkRowData _objectNoteBookmarkRowData;
        private readonly IObjectNoteTask _objectNoteTask;
        private readonly IWhereClauseForTask _whereClauseForTask;
        private readonly ITmpSiteMgmtTask _tmpSiteMgmtTask;

        public ObjectNoteCreateTaskWithWhereClause(IObjectNoteWhereClause objectNoteWhereClause,
            IObjectNoteBookmarkRowData objectNoteBookmarkRowData,
            IObjectNoteTask objectNoteTask,
            IWhereClauseForTask whereClauseForTask,
            ITmpSiteMgmtTask tmpSiteMgmtTask)
        {
            _objectNoteWhereClause = objectNoteWhereClause;
            _objectNoteBookmarkRowData = objectNoteBookmarkRowData;
            _objectNoteTask = objectNoteTask;
            _whereClauseForTask = whereClauseForTask;
            _tmpSiteMgmtTask = tmpSiteMgmtTask;
        }

        public void CreateObjectNoteTasks(
            string appViewName,
            string site,
            int taskSize,
            long tableRowsCount)
        {
            (int objectNoteTasksCount, List<string> objectNotePrimaryKeys) = _objectNoteWhereClause.GetWhereClauseCondition(tableRowsCount, taskSize);

            // Create BookMark and generate WhereClause by bookmark
            var objectNoteTaskBookmark = string.Empty;
            for (var i = 0; i < objectNoteTasksCount; i++)
            {
                var taskNum = i + 1;

                try
                {
                    if (i == 0)
                    {
                        objectNoteTaskBookmark = "1=1 ";
                    }
                    else
                    {
                        var origin = taskSize - 1;
                        // use last bookmark to query next one
                        var bookmarkRow = _objectNoteBookmarkRowData.GetRelevantObjectNotesBookmarkRowData(origin, appViewName, objectNoteTaskBookmark);
                        var bookmark = _whereClauseForTask.GetBookmark(bookmarkRow, objectNotePrimaryKeys);

                        objectNoteTaskBookmark = _whereClauseForTask.WhereClauseFromBookmark(bookmark);
                    }

                    _objectNoteTask.CreateTaskForObjectNote(appViewName, site, taskNum, taskSize, objectNoteTaskBookmark);
                }
                catch (Exception e)
                {
                    _tmpSiteMgmtTask.CreateTask($"{nameof(MGTableName.ObjectNotes)}-{appViewName}", site, taskNum, e.Message,
                        TaskStatus.F, TaskType.R);
                }
            }
        }
    }
}

