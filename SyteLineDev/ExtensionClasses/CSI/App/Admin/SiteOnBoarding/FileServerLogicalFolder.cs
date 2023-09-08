using CSI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IFileServerLogicalFolder
    {
        (string serverName, string folderTemplate) GetLogicalFolderInfo(string logicalFolderName);
    }
    public class FileServerLogicalFolder : IFileServerLogicalFolder
    {
        private readonly IFileServerLogicalFolderCRUD _fileServerLogicalFolderCRUD;
        private readonly IMsgApp _msgApp;

        public FileServerLogicalFolder(IFileServerLogicalFolderCRUD fileServerLogicalFolderCRUD, IMsgApp msgApp)
        {
            _fileServerLogicalFolderCRUD = fileServerLogicalFolderCRUD;
            _msgApp = msgApp;
        }

        public (string serverName, string folderTemplate) GetLogicalFolderInfo(string logicalFolderName)
        {
            (string serverNameReturn, string folderTemplateReturn, int countReturn) = _fileServerLogicalFolderCRUD.GetLogicalFolderInfo(logicalFolderName);

            if (countReturn <= 0)
            {
                (int severity, string infoBar) = _msgApp.MsgAppSp(
                    Infobar: "",
                    BaseMsg: "E=Invalid",
                    Parm1: logicalFolderName
                    );
                if (severity != 0)
                    throw new System.Exception(infoBar);
            }
            return (serverNameReturn, folderTemplateReturn);
        }
    }
}
