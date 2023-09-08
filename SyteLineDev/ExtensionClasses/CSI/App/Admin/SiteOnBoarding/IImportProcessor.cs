namespace CSI.Admin.SiteOnBoarding
{
    public interface IImportProcessor
    {
        void ReadFileContentAndImport(
            string site,
            string logicFolderName,
            string taskRowPointer,
            string serverName,
            string fileSpec,
            string taskFileName,
            string tableName,
            int? tableLevel,
            TaskType taskType,
            int taskNumber,
            int? totalTasks);
    }
}