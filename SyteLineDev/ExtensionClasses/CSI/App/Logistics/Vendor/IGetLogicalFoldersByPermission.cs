//PROJECT NAME: Logistics
//CLASS NAME: IGetLogicalFoldersByPermission.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface IGetLogicalFoldersByPermission
    {
        (ICollectionLoadResponse Data, int? ReturnCode) GetLogicalFoldersByPermissionSp(string UserName = null,
        string PermissionGroupName = null,
        int? ShowAllFolders = 0);
    }
}

