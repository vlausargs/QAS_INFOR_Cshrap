using System;

namespace CSI.Admin.SiteOnBoarding
{
    public class StatusHandler : IStatusHandler
    {
        private readonly ITaskStatusHandler _taskStatusHandler;
        private readonly ITableStatusHandler _tableStatusHandler;
        private readonly ISiteStatusHandler _siteStatusHandler;
        private readonly ISiteTaskListener _siteTaskListener;

        public StatusHandler(
            ITaskStatusHandler taskStatusHandler,
            ITableStatusHandler tableStatusHandler,
            ISiteStatusHandler siteStatusHandler,
            ISiteTaskListener siteTaskListener)
        {
            _taskStatusHandler = taskStatusHandler;
            _tableStatusHandler = tableStatusHandler;
            _siteStatusHandler = siteStatusHandler;
            _siteTaskListener = siteTaskListener;
        }

        public void ChangeStateBeforeImport(string taskRowPointer)
        {
            _taskStatusHandler.UpdateTaskToInProgress(taskRowPointer);
        }

        public void ChangeStateAfterImportLevelZeroTable(
            string site,
            string taskRowPointer,
            string taskFileName,
            int? totalTasks,
            string tableName)
        {
            _taskStatusHandler.UpdateTaskToComplete(taskRowPointer);

            _tableStatusHandler.UpdateTableStatusToComplete(
                site,
                taskFileName,
                totalTasks,
                tableName);
        }

        public void ChangeStateAfterImportLevelNotZeroTable(
            string site,
            string taskRowPointer,
            string taskFileName,
            int? totalTasks,
            string tableName)
        {
            _taskStatusHandler.UpdateTaskToComplete(taskRowPointer);

            _tableStatusHandler.UpdateTableLevelMinusOne(site, tableName);
        }

        public (bool isSuccess, string errorMsg) ChangeStateAfterFinished(string site)
        {
            try
            {
                var (emailAddress, siteStatus) = _siteStatusHandler.GetStateInfo(site);

                if (siteStatus == SiteStatus.I)
                {
                    _siteTaskListener.UpdateStateInfoAfterFinished(site, emailAddress);
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }

            return (true, null);
        }
    }
}