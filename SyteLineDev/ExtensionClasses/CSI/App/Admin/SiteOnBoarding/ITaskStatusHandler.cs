namespace CSI.Admin.SiteOnBoarding
{
    public interface ITaskStatusHandler
    {
        void UpdateTaskToInProgress(string taskRowPointer);

        void UpdateTaskToComplete(string taskRowPointer);
    }
}