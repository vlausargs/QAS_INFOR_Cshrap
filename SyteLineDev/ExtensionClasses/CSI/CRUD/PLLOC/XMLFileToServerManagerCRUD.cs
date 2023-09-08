using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.PLLOC
{
    public class XMLFileToServerManagerCRUD : IXMLFileToServerManagerCRUD
    {
        IApplicationDB appDB;
        ICollectionLoadRequestFactory collectionLoadRequestFactory;

        public XMLFileToServerManagerCRUD(IApplicationDB appDB, ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            this.appDB = appDB;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public void GetFileServerInfoByLogicalFolderName(ref string fileServerName, ref string folderTemplate, ref string accessDepth, string logicalFolderName)
        {
            StringType _ServerName = DBNull.Value;
            StringType _FolderTemplate = DBNull.Value;
            StringType _FolderAccessDepth = DBNull.Value;

            #region CRUD LoadToVariable
            var FileServerLogicalFolderLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
            {
            {_ServerName,$"ServerName"},
            {_FolderTemplate,$"FolderTemplate"},
            {_FolderAccessDepth,$"FolderAccessDepth"},
            },
            loadForChange: false,
            lockingType: LockingType.None,
            tableName: "FileServerLogicalFolder",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("logicalFolderName = {0}", logicalFolderName),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            this.appDB.Load(FileServerLogicalFolderLoadRequest);
            #endregion  LoadToVariable

            fileServerName = _ServerName.Value;
            folderTemplate = _FolderTemplate.Value;
            accessDepth = _FolderAccessDepth.Value;
        }
    }
}
