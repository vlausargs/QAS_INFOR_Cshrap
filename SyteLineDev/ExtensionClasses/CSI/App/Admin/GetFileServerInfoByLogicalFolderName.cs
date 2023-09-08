//PROJECT NAME: CSIAdmin
//CLASS NAME: GetFileServerInfoByLogicalFolderName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IGetFileServerInfoByLogicalFolderName
    {
        int GetFileServerInfoByLogicalFolderNameSp(AuthorizationObjectNameType LogicalFolderName,
                                                   ref OSMachineNameType ServerName,
                                                   ref FolderTemplateType FolderTemplate,
                                                   ref PopulationDepthType FolderAccessDepth);
    }

    public class GetFileServerInfoByLogicalFolderName : IGetFileServerInfoByLogicalFolderName
    {
        IApplicationDB appDB;

        public GetFileServerInfoByLogicalFolderName(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetFileServerInfoByLogicalFolderNameSp(AuthorizationObjectNameType LogicalFolderName,
                                                          ref OSMachineNameType ServerName,
                                                          ref FolderTemplateType FolderTemplate,
                                                          ref PopulationDepthType FolderAccessDepth)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetFileServerInfoByLogicalFolderNameSp";

                appDB.AddCommandParameter(cmd, "LogicalFolderName", LogicalFolderName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ServerName", ServerName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FolderTemplate", FolderTemplate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FolderAccessDepth", FolderAccessDepth, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

