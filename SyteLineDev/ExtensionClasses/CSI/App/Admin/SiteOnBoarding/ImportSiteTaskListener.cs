namespace CSI.Admin.SiteOnBoarding
{
    public class ImportSiteTaskListener : IImportSiteTaskListener
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly IStatusHandler _statusHandler;

        public ImportSiteTaskListener(
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            IStatusHandler statusHandler)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _statusHandler = statusHandler;
        }

        public void LogErrorMsg(string taskRowPointer, string errorMsg)
        {
            _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(taskRowPointer, TaskStatus.F, errorMsg);
        }

        public void ProcessTasksBeforeImport(string taskRowPointer)
        {
            _statusHandler.ChangeStateBeforeImport(taskRowPointer);
        }

        public void ProcessTasksAfterImport(
            string site,
            string taskRowPointer,
            int taskNumber,
            string taskFileName,
            int? totalTasks,
            int? tableLevel,
            string tableName)
        {
            if (tableLevel == 0)
            {
                _statusHandler.ChangeStateAfterImportLevelZeroTable(
                    site,
                    taskRowPointer,
                    taskFileName,
                    totalTasks,
                    tableName);
            }
            else
            {
                _tmpSiteMgmtTaskCRUD.CreateTaskWithBookmark(
                    tableName,
                    site,
                    taskNumber,
                    taskFileName,
                    TaskStatus.P,
                    TaskType.U);

                _statusHandler.ChangeStateAfterImportLevelNotZeroTable(
                    site,
                    taskRowPointer,
                    taskFileName,
                    totalTasks,
                    tableName);
            }
        }

        public void ProcessAfterFinish(string site)
        {
            _statusHandler.ChangeStateAfterFinished(site);
        }
    }
}