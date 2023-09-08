namespace CSI.Admin.SiteOnBoarding
{
    public class TableDataImporter : ITableDataImporter
    {
        private readonly IFileHandler _fileHandler;
        private readonly ILogicalFolderCRUD _logicalFolderCRUD;
        private readonly IImportProcessor _importProcessor;

        public TableDataImporter(
            IFileHandler fileHandler,
            ILogicalFolderCRUD logicalFolderCRUD,
            IImportProcessor importProcessor)
        {
            _fileHandler = fileHandler;
            _logicalFolderCRUD = logicalFolderCRUD;
            _importProcessor = importProcessor;
        }

        public (bool IsSuccess, string ErrorMsg) Process(
            string site,
            string logicFolderName,
            string taskRowPointer)
        {
            var (serverName, fileSpec) =
                _logicalFolderCRUD.ReadLogicalFolderInfo(logicFolderName);

            var (isCheckSuccess, taskNumber, tableName, taskType, taskFileName, totalTasks,
                    tableLevel) =
                _fileHandler.CheckFileExistsAndReadTaskInfo(
                    serverName,
                    fileSpec,
                    logicFolderName,
                    taskRowPointer);

            if (isCheckSuccess)
            {
                _importProcessor.ReadFileContentAndImport(
                    site,
                    logicFolderName,
                    taskRowPointer,
                    serverName,
                    fileSpec,
                    taskFileName,
                    tableName,
                    tableLevel,
                    taskType,
                    taskNumber,
                    totalTasks);
            }

            return (true, string.Empty);
        }
    }
}