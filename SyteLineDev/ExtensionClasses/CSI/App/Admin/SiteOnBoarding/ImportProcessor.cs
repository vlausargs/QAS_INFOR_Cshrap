namespace CSI.Admin.SiteOnBoarding
{
    public class ImportProcessor : IImportProcessor
    {
        private readonly IFileHandler _fileHandler;
        private readonly IImportTaskHandler _importTaskHandler;
        private readonly IImportSiteTaskListener _importSiteTaskListener;

        public ImportProcessor(
            IFileHandler fileHandler,
            IImportTaskHandler importTaskHandler,
            IImportSiteTaskListener importSiteTaskListener)
        {
            _fileHandler = fileHandler;
            _importTaskHandler = importTaskHandler;
            _importSiteTaskListener = importSiteTaskListener;
        }

        public void ReadFileContentAndImport(
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
            int? totalTasks)
        {
            var (isReadSuccess, fileContent) = _fileHandler.ReadFileContent(
                serverName,
                fileSpec,
                logicFolderName,
                taskFileName,
                taskRowPointer);

            if (isReadSuccess)
            {
                _importSiteTaskListener.ProcessTasksBeforeImport(taskRowPointer);

                _importTaskHandler.ProcessTask(
                    fileContent,
                    site,
                    tableName,
                    tableLevel,
                    taskRowPointer,
                    taskType);
                _importSiteTaskListener.ProcessTasksAfterImport(
                    site,
                    taskRowPointer,
                    taskNumber,
                    taskFileName,
                    totalTasks,
                    tableLevel,
                    tableName);
            }
        }
    }
}