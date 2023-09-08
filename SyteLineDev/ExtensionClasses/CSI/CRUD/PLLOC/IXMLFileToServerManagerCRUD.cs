using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.PLLOC
{
    public interface IXMLFileToServerManagerCRUD
    {
        void GetFileServerInfoByLogicalFolderName(ref string fileServerName, ref string folderTemplate, ref string accessDepth, string logicalFolderName);
    }
}
