using CSI.MG;
using System.Data;

namespace CSI.Data.SQL
{
    public class SQLFileServer: IFileServer
    {
        public (int? Severity, string Infobar, int? Exists) FileExists(
            string fileSpec,
            string serverName,
            string logicalFolderName)
        {
            throw new System.NotImplementedException();
        }

        public (DataTable FileList, string Infobar) GetFileList(
            string fileSpec,
            string serverName,
            string logicalFolderName,
            string getFileAction)
        {
            throw new System.NotImplementedException();
        }

        public (int? Severity, string Infobar, int Deleted) DeleteFromFileServer(
            string serverName,
            string fileSpec,
            string logicalFolder)
        {
            throw new System.NotImplementedException();
        }

        public (int? Severity, string Infobar, int Created) CreateDirectory(
            string fileSpec,
            string serverName,
            string logicalFolderName)
        {
            throw new System.NotImplementedException();
        }

        public (int? Severity, string Infobar, byte[] fileContent, string parsedFileSpec) GetFileContent(
            string fileSpec,
            string serverName,
            string logicalFolderName)
        {
            throw new System.NotImplementedException();
        }

        public int SaveFileContent(
            ref string infobar,
            ref int saved,
            byte[] fileContent,
            string fileSpec,
            string serverName,
            string logicalFolderName,
            int overwrite = 1,
            string fileNameWhenFileSpecIsAPath = "")
        {
            throw new System.NotImplementedException();
        }

        public (int? Severity, string Infobar, int Moved) MoveFileServerToServer(
            string serverFrom,
            string fileSpecFrom,
            string logicalFolderNameFrom,
            string serverTo,
            string fileSpecTo,
            string logicalFolderNameTo,
            int overwrite = 1,
            int deleteFromSource = 0)
        {
            throw new System.NotImplementedException();
        }
    }
}