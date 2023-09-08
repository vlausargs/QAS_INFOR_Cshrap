//PROJECT NAME: MG.MGCore
//CLASS NAME: IGetUserPrivileges.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IGetUserPrivileges
    {
        (int? ReturnCode, int? DeletePrivilege,
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
        int? BulkUpdatePrivilege = null);
    }
}

