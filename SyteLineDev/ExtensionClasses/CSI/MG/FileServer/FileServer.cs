using Mongoose.MGCore;
using System.Data;

namespace CSI.MG
{
    public class FileServer : IFileServer
    {
        private readonly FileServerExtension _fileServerExtension;

        public FileServer()
        {
            _fileServerExtension = new FileServerExtension();
        }

        public (int? Severity, string Infobar, int? Exists) FileExists(
            string fileSpec,
            string serverName,
            string logicalFolderName)
        {
            var exists = 0;
            var infobar = string.Empty;

            var severity = _fileServerExtension.FileExists(
                fileSpec,
                serverName,
                logicalFolderName,
                ref exists,
                ref infobar);

            return (severity, infobar, exists);
        }

        public (DataTable FileList, string Infobar) GetFileList(
            string fileSpec,
            string serverName,
            string logicalFolderName,
            string getFileAction)
        {
            var infobar = string.Empty;

            var fileList = _fileServerExtension.GetFileList(
                fileSpec,
                serverName,
                logicalFolderName,
                getFileAction,
                ref infobar);

            return (fileList, infobar);
        }

        public (int? Severity, string Infobar, int Deleted) DeleteFromFileServer(
            string serverName,
            string fileSpec,
            string logicalFolder)
        {
            var deleted = 0;
            var infobar = string.Empty;

            var severity = _fileServerExtension.DeleteFromFileServer(
                serverName,
                fileSpec,
                logicalFolder,
                ref deleted,
                ref infobar);

            return (severity, infobar, deleted);
        }

        public (int? Severity, string Infobar, int Created) CreateDirectory(
            string fileSpec,
            string serverName,
            string logicalFolderName)
        {
            var created = 0;
            var infobar = string.Empty;

            var severity = _fileServerExtension.CreateDirectory(
                fileSpec,
                serverName,
                logicalFolderName,
                ref created,
                ref infobar);

            return (severity, infobar, created);
        }

        public (int? Severity, string Infobar, byte[] fileContent, string parsedFileSpec)
            GetFileContent(
                string fileSpec,
                string serverName,
                string logicalFolderName)
        {
            byte[] fileContent = null;
            var parsedFileSpec = string.Empty;
            var infobar = string.Empty;

            var severity = _fileServerExtension.GetFileContent(
                fileSpec,
                serverName,
                logicalFolderName,
                ref fileContent,
                ref parsedFileSpec,
                ref infobar);

            return (severity, infobar, fileContent, parsedFileSpec);
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
            return _fileServerExtension.SaveFileContent(
                ref infobar,
                ref saved,
                fileContent,
                fileSpec,
                serverName,
                logicalFolderName,
                overwrite,
                fileNameWhenFileSpecIsAPath);
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
            var moved = 0;
            var infobar = string.Empty;

            var severity = _fileServerExtension.MoveFileServerToServer(
                ref infobar,
                ref moved,
                serverFrom,
                fileSpecFrom,
                logicalFolderNameFrom,
                serverTo,
                fileSpecTo,
                logicalFolderNameTo,
                overwrite,
                deleteFromSource);

            return (severity, infobar, moved);
        }
    }
}
