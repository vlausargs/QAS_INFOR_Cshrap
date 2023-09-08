using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IFileHandler
    {
        (bool IsSuccess, int TaskNumber, string TableName, TaskType TaskType, string TaskFileName,
            int? TotalTasks, int? TableLevel)
            CheckFileExistsAndReadTaskInfo(
                string serverName,
                string fileSpec,
                string logicFolderName,
                string taskRowPointer);

        (bool IsSuccess, byte[] FileContent) ReadFileContent(
            string serverName,
            string fileSpec,
            string logicFolderName,
            string taskFileName,
            string taskRowPointer);

        (bool IsSuccess, string ErrorMsg, List<Dictionary<string, string>> FileInfoList)
            GetFileInfoList(
                string fileSpec,
                string serverName,
                string logicalFolder);

        void CreateImportingDirectory(
            string fileSpec,
            string serverName,
            string logicalFolder);

        void MoveFileServerToServer(
            string logicalFolder,
            string serverName,
            string fileSpec,
            Dictionary<string, string> fileInfo,
            string taskRowPointer);
    }
}