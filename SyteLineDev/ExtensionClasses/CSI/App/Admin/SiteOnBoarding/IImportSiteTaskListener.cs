namespace CSI.Admin.SiteOnBoarding
{
    public interface IImportSiteTaskListener
    {
        void LogErrorMsg(string taskRowPointer, string errorMsg);

        void ProcessTasksBeforeImport(string taskRowPointer);

        void ProcessTasksAfterImport(
            string site,
            string taskRowPointer,
            int taskNumber,
            string taskFileName,
            int? totalTasks,
            int? tableLevel,
            string tableName);

        void ProcessAfterFinish(string site);
    }
}