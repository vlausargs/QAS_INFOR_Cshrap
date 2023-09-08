using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;
using PLLOC.Interfaces;

namespace CSI.PLLOC
{
    public class XMLFileToServerManager : IXMLFileToServerManager
    {
        IXMLFileToServerManagerCRUD xMLFileToServerManagerCRUD;
        IFileServer fileServer;
        IFileNameUtil fileNameUtil;
        string logicalFolderName;
        string fileName;
        byte[] fileContentInBytes;
        string fileSpec;
        string fileServerName;

        public XMLFileToServerManager(IXMLFileToServerManagerCRUD xMLFileToServerManagerCRUD, IFileServer fileServer, IFileNameUtil fileNameUtil)
        {
            this.xMLFileToServerManagerCRUD = xMLFileToServerManagerCRUD;
            this.fileServer = fileServer;
            this.fileNameUtil = fileNameUtil;
        }

        public int SaveXMLToServer(ref string Infobar, string logicalFolderName, string fileName, object XMLObject)
        {
            string fileServerName = string.Empty;
            string folderTemplate = string.Empty;
            string accessDepth = string.Empty;
            int saved = 0;            

            this.fileName = GetValidFileName(fileName);
            this.logicalFolderName = logicalFolderName;

            if (XMLObject != null)
            {
                this.fileContentInBytes = Encoding.UTF8.GetBytes(XMLObject.ToString());
            }

            byte[] fileContentBytes = new byte[] { };

            GetFileServerInfoByLogicalFolderName(ref fileServerName, ref folderTemplate, ref accessDepth);
            this.fileSpec = GetFileSpec(folderTemplate, accessDepth);

            this.fileServerName = fileServerName;

            this.fileServer.SaveFileContent(ref Infobar, ref saved, this.fileContentInBytes, this.fileSpec, this.fileServerName, this.logicalFolderName, 1, this.fileName);

            return saved;
        }

        public (byte[] fileContent, string Infobar, string parsedFileSpec) GetXMLFromServer(string logicalFolderName, string fileName)
        {
            string fileServerName = string.Empty;
            string folderTemplate = string.Empty;
            string accessDepth = string.Empty;
            byte[] fileContent = null;
            string parsedFileSpec = string.Empty;
            string Infobar = string.Empty;

            this.fileName = GetValidFileName(fileName);
            this.logicalFolderName = logicalFolderName;

            byte[] fileContentBytes = new byte[] { };

            GetFileServerInfoByLogicalFolderName(ref fileServerName, ref folderTemplate, ref accessDepth);
            this.fileSpec = GetFileSpec(folderTemplate, accessDepth);

            this.fileServerName = fileServerName;

            var getFileContent = this.fileServer.GetFileContent(fileSpec, fileServerName, logicalFolderName);

            fileContent = getFileContent.fileContent;
            Infobar = getFileContent.Infobar;
            parsedFileSpec = getFileContent.parsedFileSpec;

            return (fileContent, Infobar, parsedFileSpec);
        }

        private string GetValidFileName(string fileName)
        {
            fileName = this.fileNameUtil.RemoveInvalidCharFromFileName(fileName);
            //if filename only contains invalid characters, it will be empty
            fileName = !string.IsNullOrEmpty(fileName) ? fileName : string.Format("PolandVATFile{0}", DateTime.Now.ToString("ddMMyyyy"));
            
            if (!fileName.EndsWith(".xml"))
            {
                fileName += ".xml";
            }

            return fileName;
        }

        private void GetFileServerInfoByLogicalFolderName(ref string fileServerName, ref string folderTemplate, ref string accessDepth)
        {
            xMLFileToServerManagerCRUD.GetFileServerInfoByLogicalFolderName(ref fileServerName, ref folderTemplate, ref accessDepth, logicalFolderName);
        }

        private string GetFileSpec(string folderTemplate, string accessDepth, bool useServerCheck = true)
        {
            string useServerCheckStr;
            string fileSpec = string.Empty;

            if (useServerCheck) useServerCheckStr = "1";
            else useServerCheckStr = "0";

            if (this.fileName.LastIndexOf(@"\") >= 0) this.fileName = this.fileName.Substring(this.fileName.LastIndexOf(@"\")).TrimStart('\\');

            if (!string.IsNullOrEmpty(folderTemplate))
            {
                fileSpec = folderTemplate.TrimEnd('/') + @"\" + this.fileName + "||" + accessDepth + "|" + useServerCheckStr;
            }
            return fileSpec;
        }
    }
}
