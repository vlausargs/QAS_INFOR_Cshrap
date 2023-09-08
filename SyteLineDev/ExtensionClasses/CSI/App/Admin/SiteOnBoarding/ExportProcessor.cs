using CSI.MG;
using System;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IExportProcessor
    {
        (bool finalTask, string appViewName, string tableName) ReadFileContentAndExport(int taskSize, string logicalFolder, string targetFileType, string taskRowPointer, string site);

    }

    public class ExportProcessor : IExportProcessor
    {
        private readonly IFileContent _fileContent;
        private readonly ITaskInfo _taskInfo;
        private readonly IFileServer _fileServer;
        private readonly ITargetFileName _targetFileName;
        private readonly IFileServerLogicalFolder _fileServerLogicalFolder;
        private readonly ITableNameCRUD _tableNameCRUD;


        public ExportProcessor(IFileContent fileContent, ITaskInfo taskInfo, IFileServer fileServer, IFileServerLogicalFolder fileServerLogicalFolder, ITableNameCRUD tableNameCRUD, ITargetFileName targetFileName)
        {
            _fileServer = fileServer;
            _taskInfo = taskInfo;
            _fileContent = fileContent;
            _fileServerLogicalFolder = fileServerLogicalFolder;
            _tableNameCRUD = tableNameCRUD;
            _targetFileName = targetFileName;
        }

        public (bool finalTask, string appViewName, string tableName) ReadFileContentAndExport(int taskSize, string logicalFolder, string targetFileType, string taskRowPointer, string site)
        {
            var (appViewName, taskNumber, bookMark, taskType, _, tableTotalTasks, _) = _taskInfo.ReadTask(taskRowPointer);
            var finalTask = tableTotalTasks == taskNumber;
            var fileName = _targetFileName.GetTargetFileName(appViewName, site, tableTotalTasks, taskNumber, targetFileType).ToLower();
            var tableName = taskType == TaskType.R ? appViewName.Substring(0, appViewName.LastIndexOf("-", StringComparison.Ordinal)) : _tableNameCRUD.ReadTableName(appViewName);
            appViewName = appViewName.Contains("-")
                ? appViewName.Substring(appViewName.IndexOf("-", StringComparison.Ordinal) + 1)
                : appViewName;
            var fileContent = _fileContent.GetFileContentAndDoPreprocessing(tableName, appViewName, taskSize, bookMark, targetFileType);

            (string serverName, string fileSpec) = _fileServerLogicalFolder.GetLogicalFolderInfo(logicalFolder);

            var errorMsg = string.Empty;
            var saved = 0;
            _fileServer.SaveFileContent(
                ref errorMsg,
                ref saved,
                fileContent,
                $@"{fileSpec}{fileName}",
                serverName,
                logicalFolder);
            if (saved != 1)
            {
                throw new Exception($@"Move {fileSpec}{fileName} Error. FileContent length: {fileContent.Length}. Error Message: {errorMsg}");
            }
            return (finalTask, appViewName, tableName);
        }
    }
}
