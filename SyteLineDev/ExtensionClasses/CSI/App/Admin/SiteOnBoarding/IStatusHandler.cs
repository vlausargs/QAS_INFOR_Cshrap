namespace CSI.Admin.SiteOnBoarding
{
    public interface IStatusHandler
    {
        void ChangeStateBeforeImport(string taskRowPointer);

        void ChangeStateAfterImportLevelZeroTable(
            string site,
            string taskRowPointer,
            string taskFileName,
            int? totalTasks,
            string tableName);

        void ChangeStateAfterImportLevelNotZeroTable(
            string site,
            string taskRowPointer,
            string taskFileName,
            int? totalTasks,
            string tableName);

        (bool isSuccess, string errorMsg) ChangeStateAfterFinished(string site);
    }
}