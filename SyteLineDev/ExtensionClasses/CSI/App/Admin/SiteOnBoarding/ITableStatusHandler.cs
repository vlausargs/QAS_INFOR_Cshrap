namespace CSI.Admin.SiteOnBoarding
{
    public interface ITableStatusHandler
    {
        void UpdateTableStatusToComplete(
            string site,
            string taskFileName,
            int? totalTasks,
            string tableName);

        void UpdateTableLevelMinusOne(string site, string tableName);

        (int PendingCount, int InProgressCount, int FailedCount) GetTableStateInfo(string site);
    }
}