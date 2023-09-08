//PROJECT NAME: MG.MGCore
//CLASS NAME: GetUserPrivileges.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class GetUserPrivileges : IGetUserPrivileges
    {
        IApplicationDB appDB;


        public GetUserPrivileges(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, int? DeletePrivilege,
        int? EditPrivilege,
        int? ExecutePrivilege,
        int? InsertPrivilege,
        int? ReadPrivilege,
        int? UpdatePrivilege,
        int? BulkUpdatePrivilege) GetUserPrivilegesSp(int? ObjectType,
        string ObjectName1,
        string ObjectName2,
        string Username,
        int? DeletePrivilege = null,
        int? EditPrivilege = null,
        int? ExecutePrivilege = null,
        int? InsertPrivilege = null,
        int? ReadPrivilege = null,
        int? UpdatePrivilege = null,
        int? BulkUpdatePrivilege = null)
        {
            AuthorizationObjectTypeType _ObjectType = ObjectType;
            AuthorizationObjectNameType _ObjectName1 = ObjectName1;
            AuthorizationObjectNameType _ObjectName2 = ObjectName2;
            UsernameType _Username = Username;
            PrivilegeType _DeletePrivilege = DeletePrivilege;
            PrivilegeType _EditPrivilege = EditPrivilege;
            PrivilegeType _ExecutePrivilege = ExecutePrivilege;
            PrivilegeType _InsertPrivilege = InsertPrivilege;
            PrivilegeType _ReadPrivilege = ReadPrivilege;
            PrivilegeType _UpdatePrivilege = UpdatePrivilege;
            PrivilegeType _BulkUpdatePrivilege = BulkUpdatePrivilege;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUserPrivilegesSp";

                appDB.AddCommandParameter(cmd, "ObjectType", _ObjectType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ObjectName1", _ObjectName1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ObjectName2", _ObjectName2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DeletePrivilege", _DeletePrivilege, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EditPrivilege", _EditPrivilege, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExecutePrivilege", _ExecutePrivilege, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InsertPrivilege", _InsertPrivilege, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ReadPrivilege", _ReadPrivilege, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UpdatePrivilege", _UpdatePrivilege, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BulkUpdatePrivilege", _BulkUpdatePrivilege, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                DeletePrivilege = _DeletePrivilege;
                EditPrivilege = _EditPrivilege;
                ExecutePrivilege = _ExecutePrivilege;
                InsertPrivilege = _InsertPrivilege;
                ReadPrivilege = _ReadPrivilege;
                UpdatePrivilege = _UpdatePrivilege;
                BulkUpdatePrivilege = _BulkUpdatePrivilege;

                return (Severity, DeletePrivilege, EditPrivilege, ExecutePrivilege, InsertPrivilege, ReadPrivilege, UpdatePrivilege, BulkUpdatePrivilege);
            }
        }
    }
}
