using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public class FileHandler : IFileHandler
    {
        private readonly IFileServer _fileServer;
        private readonly IFileInfoHandler _fileInfoHandler;
        private readonly ITmpSiteMgmtTaskCRUD _tmpSiteMgmtTaskCRUD;
        private readonly ITaskInfo _taskInfo;

        public FileHandler(
            IFileServer fileServer,
            IFileInfoHandler fileInfoHandler,
            ITmpSiteMgmtTaskCRUD tmpSiteMgmtTaskCRUD,
            ITaskInfo taskInfo)
        {
            _fileServer = fileServer;
            _fileInfoHandler = fileInfoHandler;
            _tmpSiteMgmtTaskCRUD = tmpSiteMgmtTaskCRUD;
            _taskInfo = taskInfo;
        }

        public (bool IsSuccess, int TaskNumber, string TableName, TaskType TaskType,
            string TaskFileName, int? TotalTasks, int? TableLevel)
            CheckFileExistsAndReadTaskInfo(
                string serverName,
                string fileSpec,
                string logicFolderName,
                string taskRowPointer)
        {
            var (tableName, taskNumber, taskFileName, taskType, _, totalTasks, tableLevel) =
                _taskInfo.ReadTask(taskRowPointer);

            var (_, _, exists) = _fileServer.FileExists(
                $@"importing/{taskFileName}",
                serverName,
                logicFolderName);

            if (exists != 1)
            {
                _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(
                    taskRowPointer,
                    TaskStatus.F,
                    $@"{taskFileName} doesn't be found in {fileSpec}.");

                return (false, taskNumber, tableName, taskType, taskFileName, totalTasks,
                    tableLevel);
            }

            return (true, taskNumber, tableName, taskType, taskFileName, totalTasks, tableLevel);
        }

        public (bool IsSuccess, byte[] FileContent) ReadFileContent(
            string serverName,
            string fileSpec,
            string logicFolderName,
            string taskFileName,
            string taskRowPointer)
        {
            var (readSeverity, readInfobar, fileContent, _) =
                _fileServer.GetFileContent(
                    $@"importing/{taskFileName}",
                    serverName,
                    logicFolderName);

            if (readSeverity != 0)
            {
                _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(
                    taskRowPointer,
                    TaskStatus.F,
                    $"Read file content failed: {readInfobar}.");
                return (false, null);
            }

            return (true, fileContent);
        }

        public (bool IsSuccess, string ErrorMsg, List<Dictionary<string, string>> FileInfoList)
            GetFileInfoList(
                string fileSpec,
                string serverName,
                string logicalFolder)
        {
            var (fileDataTable, fileInfobar) = _fileServer.GetFileList(
                fileSpec,
                serverName,
                logicalFolder,
                "File");

            var fileInfoList = fileDataTable.AsEnumerable()
                .Select(
                    dataRow => _fileInfoHandler.SettleFileName(dataRow["DerFileName"].ToString()))
                .Where(fileInfo => fileInfo.Count > 0).ToList();

            if (fileInfoList.Count <= 0)
            {
                return (false, fileInfobar, null);
            }

            return (true, string.Empty, fileInfoList);
        }

        public void CreateImportingDirectory(
            string fileSpec,
            string serverName,
            string logicalFolder)
        {
            // If the directory already exists, this method does not create a new directory,
            // but it returns a DirectoryInfo object for the existing directory,
            // createInfobar is null
            var (_, createInfobar, _) =
                _fileServer.CreateDirectory(
                    @"importing",
                    serverName,
                    logicalFolder);

            if (!string.IsNullOrWhiteSpace(createInfobar))
                throw new Exception(createInfobar);
        }

        public void MoveFileServerToServer(
            string logicalFolder,
            string serverName,
            string fileSpec,
            Dictionary<string, string> fileInfo,
            string taskRowPointer)
        {
            var (moveSeverity, moveInfobar, moved) =
                _fileServer.MoveFileServerToServer(
                    serverName,
                    $@"{fileSpec}{fileInfo["FileName"]}",
                    logicalFolder,
                    serverName,
                    @"importing",
                    logicalFolder,
                    1,
                    1);

            if (moveSeverity != 0)
            {
                _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(
                    taskRowPointer,
                    TaskStatus.F,
                    moveInfobar);
            }
            else
            {
                _tmpSiteMgmtTaskCRUD.UpdateTaskStatus(
                    taskRowPointer,
                    TaskStatus.P,
                    string.Empty);
            }
        }
    }
}