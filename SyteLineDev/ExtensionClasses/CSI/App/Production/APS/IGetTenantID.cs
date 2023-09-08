//PROJECT NAME: Production
//CLASS NAME: IGetTenantID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface IGetTenantID
    {
        (int? ReturnCode, string TenantID) GetTenantIDSp(
            string TenantID);
    }
}

