namespace CSI.Admin.SiteOnBoarding
{
    public class TaskNavigator : ITaskNavigator
    {
        private readonly ITaskInfo _taskInfo;
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly IIsFeatureActive _isFeatureActive;

        public TaskNavigator(
            ITaskInfo taskInfo,
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            IIsFeatureActive isFeatureActive)
        {
            _taskInfo = taskInfo;
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _isFeatureActive = isFeatureActive;
        }

        public string GetAvailableTask(string site)
        {
            var (returnCode, featureActive, infobar) =
                _isFeatureActive.IsFeatureActiveSp(
                    ProductName: "CSI",
                    FeatureID: "RS9146",
                    FeatureActive: 0,
                    InfoBar: null);

            if ((returnCode ?? 0) != 0)
                throw new System.Exception(infobar);
            else if ((featureActive ?? 0) == 0)
                return string.Empty;

            var taskRowPointer = _taskInfo.GetAvailableTask(site);
            if (!string.IsNullOrWhiteSpace(taskRowPointer))
                _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(taskRowPointer, TaskStatus.I, string.Empty);

            return taskRowPointer;
        }
    }
}