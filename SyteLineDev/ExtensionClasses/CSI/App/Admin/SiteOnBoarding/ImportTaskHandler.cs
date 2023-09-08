using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class ImportTaskHandler : IImportTaskHandler
    {
        private readonly IFileHandler _fileHandler;
        private readonly IImportTaskCreator _importTaskCreator;
        private readonly IImportDataHandler _importDataHandler;
        private readonly IImportSiteTaskNavigatorCRUD _importSiteTaskNavigatorCRUD;

        public ImportTaskHandler(
            IFileHandler fileHandler,
            IImportTaskCreator importTaskCreator,
            IImportDataHandler importDataHandler,
            IImportSiteTaskNavigatorCRUD importSiteTaskNavigatorCRUD)
        {
            _fileHandler = fileHandler;
            _importTaskCreator = importTaskCreator;
            _importDataHandler = importDataHandler;
            _importSiteTaskNavigatorCRUD = importSiteTaskNavigatorCRUD;
        }

        public (bool isSuccess, string errorMsg) DistributeTask(
            string site,
            string logicalFolder,
            string fileSpec,
            string serverName,
            List<Dictionary<string, string>> fileInfoList)
        {
            _fileHandler.CreateImportingDirectory(fileSpec, serverName, logicalFolder);

            foreach (var fileInfo in fileInfoList)
            {
                var taskRowPointer =
                    _importTaskCreator.CreateTask(site, fileInfo);

                if (string.IsNullOrWhiteSpace(taskRowPointer)) continue;

                _fileHandler.MoveFileServerToServer(
                    logicalFolder,
                    serverName,
                    fileSpec,
                    fileInfo,
                    taskRowPointer);

                return (true, null);
            }

            return (false, null);
        }

        public void ProcessTask(
            byte[] fileContent,
            string site,
            string tableName,
            int? tableLevel,
            string taskRowPointer,
            TaskType taskType)
        {
            if (taskType == TaskType.I)
            {
                _importDataHandler.InsertData(
                    fileContent,
                    site,
                    tableName,
                    tableLevel,
                    taskRowPointer);
            }
            else if (taskType == TaskType.U)
            {
                _importDataHandler.UpdateData(
                    fileContent,
                    site,
                    tableName,
                    tableLevel,
                    taskRowPointer);
            }
        }
    }
}