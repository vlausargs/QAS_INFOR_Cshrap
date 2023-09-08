using System.Data;

namespace CSI.MG
{
    public interface IFileServer
    {
        (int? Severity, string Infobar, int? Exists) FileExists(
            string fileSpec,
            string serverName,
            string logicalFolderName);

        (DataTable FileList, string Infobar) GetFileList(
            string fileSpec,
            string serverName,
            string logicalFolderName,
            string getFileAction);

        (int? Severity, string Infobar, int Deleted) DeleteFromFileServer(
            string serverName,
            string fileSpec,
            string logicalFolder);

        (int? Severity, string Infobar, int Created) CreateDirectory(
            string fileSpec,
            string serverName,
            string logicalFolderName);

        (int? Severity, string Infobar, byte[] fileContent, string parsedFileSpec) GetFileContent(
            string fileSpec,
            string serverName,
            string logicalFolderName);

        int SaveFileContent(
            ref string infobar,
            ref int saved,
            byte[] fileContent,
            string fileSpec,
            string serverName,
            string logicalFolderName,
            int overwrite = 1,
            string fileNameWhenFileSpecIsAPath = "");

        (int? Severity, string Infobar, int Moved) MoveFileServerToServer(
            string serverFrom,
            string fileSpecFrom,
            string logicalFolderNameFrom,
            string serverTo,
            string fileSpecTo,
            string logicalFolderNameTo,
            int overwrite = 1,
            int deleteFromSource = 0);
    }
}