using System;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IImportTaskCreator
    {
        string CreateTask(
            string site,
            Dictionary<string, string> fileInfo);
    }

    public class ImportTaskCreator : IImportTaskCreator
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;

        public ImportTaskCreator(ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
        }

        public string CreateTask(
            string site,
            Dictionary<string, string> fileInfo)
        {
            if (_tmpSiteMgmtTaskCRUD.IsExistTask(
                    site,
                    fileInfo["TableName"],
                    Convert.ToInt16(fileInfo["TaskNum"]),
                    fileInfo["FileName"],
                    TaskType.I))
                // TODO: We can move the failed task to error dictionary
                return string.Empty;

            try
            {
                // Create task by primary keys, need to catch duplicate primary key error.
                _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark(
                    fileInfo["TableName"],
                    site,
                    Convert.ToInt16(fileInfo["TaskNum"]),
                    fileInfo["FileName"],
                    TaskStatus.M,
                    TaskType.I);
            }
            catch
            {
                return string.Empty;
            }

            var taskRowPointer = _tmpSiteMgmtTaskCRUD.ReadTaskRowPointer(
                site,
                fileInfo["TableName"],
                Convert.ToInt16(fileInfo["TaskNum"]),
                fileInfo["FileName"],
                TaskStatus.M,
                TaskType.I);

            return taskRowPointer;
        }
    }
}