using CSI.Data;

namespace CSI.Admin.SiteOnBoarding
{
    public class TaskStatusHandler : ITaskStatusHandler
    {
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly IDateTimeUtil _dateTimeUtil;

        public TaskStatusHandler(
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            IDateTimeUtil dateTimeUtil)
        {
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _dateTimeUtil = dateTimeUtil;
        }

        public void UpdateTaskToInProgress(string taskRowPointer)
        {
            _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(
                taskRowPointer,
                TaskStatus.I,
                string.Empty);
            _tmpSiteMgmtTaskCRUD.UpdateTaskStartTime(taskRowPointer, _dateTimeUtil.Now());
        }

        public void UpdateTaskToComplete(string taskRowPointer)
        {
            _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(
                taskRowPointer,
                TaskStatus.C,
                string.Empty);
            _tmpSiteMgmtTaskCRUD.UpdateTaskEndTime(taskRowPointer, _dateTimeUtil.Now());
        }
    }
}