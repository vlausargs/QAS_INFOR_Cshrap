using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IDocumentObjectReferenceCreateTaskWithWhereClause
    {
        void CreateDocumentObjectReferenceTasks(string appViewName, string site, int taskSize, long tableRowsCount);
    }

    public class DocumentObjectReferenceCreateTaskWithWhereClause : IDocumentObjectReferenceCreateTaskWithWhereClause
    {
        private readonly IDocumentObjectReferenceWhereClause _documentObjectReferenceWhereClause;
        private readonly IDocumentObjectReferenceBookmarkRowData _documentObjectReferenceBookmarkRowData;
        private readonly IDocumentObjectReferenceTask _documentObjectReferenceTask;
        private readonly IWhereClauseForTask _whereClauseForTask;
        private readonly ITmpSiteMgmtTask _tmpSiteMgmtTask;

        public DocumentObjectReferenceCreateTaskWithWhereClause(IDocumentObjectReferenceWhereClause documentObjectReferenceWhereClause,
            IDocumentObjectReferenceBookmarkRowData documentObjectReferenceBookmarkRowData,
            IDocumentObjectReferenceTask documentObjectReferenceTask,
            IWhereClauseForTask whereClauseForTask,
            ITmpSiteMgmtTask tmpSiteMgmtTask)
        {
            _documentObjectReferenceWhereClause = documentObjectReferenceWhereClause;
            _documentObjectReferenceBookmarkRowData = documentObjectReferenceBookmarkRowData;
            _documentObjectReferenceTask = documentObjectReferenceTask;
            _whereClauseForTask = whereClauseForTask;
            _tmpSiteMgmtTask = tmpSiteMgmtTask;
        }

        public void CreateDocumentObjectReferenceTasks(
            string appViewName,
            string site,
            int taskSize,
            long tableRowsCount)
        {
            (int docTasksCount, List<string> docPrimaryKeys) = _documentObjectReferenceWhereClause.GetWhereClauseCondition(tableRowsCount, taskSize);

            // Create Bookmark and generate WhereClause by bookmark
            var docTaskBookmark = string.Empty;
            for (var i = 0; i < docTasksCount; i++)
            {
                var taskNum = i + 1;

                try
                {
                    if (i == 0)
                        docTaskBookmark = "1=1 ";
                    else
                    {
                        var origin = taskSize - 1;
                        // use last bookmark to query next one
                        var bookmarkRow = _documentObjectReferenceBookmarkRowData.GetRelevantDocObjectReferenceBookmarkRowData(origin, appViewName, docTaskBookmark);
                        var bookmark = _whereClauseForTask.GetBookmark(bookmarkRow, docPrimaryKeys);

                        docTaskBookmark = _whereClauseForTask.WhereClauseFromBookmark(bookmark);
                    }

                    _documentObjectReferenceTask.CreateTaskForDoc(appViewName, site, taskNum, docTaskBookmark);
                }
                catch (Exception e)
                {
                    _tmpSiteMgmtTask.CreateTask($"{nameof(MGTableName.DocumentObject)}-{appViewName}", site, taskNum, e.Message,
                        TaskStatus.F, TaskType.R);
                }
            }
        }
    }
}

