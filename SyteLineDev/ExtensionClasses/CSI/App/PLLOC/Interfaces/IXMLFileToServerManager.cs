using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IXMLFileToServerManager
    {
        int SaveXMLToServer(ref string Infobar, string logicalFolderName, string fileName, Object XMLObject);
        (byte[] fileContent, string Infobar, string parsedFileSpec) GetXMLFromServer(string logicalFolderName, string fileName);
    }
}
