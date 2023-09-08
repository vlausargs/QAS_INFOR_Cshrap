//PROJECT NAME: Logistics
//CLASS NAME: GetLogicalFoldersByPermission.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
namespace CSI.Logistics.Vendor
{
    public class GetLogicalFoldersByPermission : IGetLogicalFoldersByPermission
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public GetLogicalFoldersByPermission(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) GetLogicalFoldersByPermissionSp(string UserName = null,
        string PermissionGroupName = null,
        int? ShowAllFolders = 0)
        {
            UsernameType _UserName = UserName;
            GroupnameType _PermissionGroupName = PermissionGroupName;
            ListYesNoType _ShowAllFolders = ShowAllFolders;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetLogicalFoldersByPermissionSp";

                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PermissionGroupName", _PermissionGroupName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowAllFolders", _ShowAllFolders, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}
