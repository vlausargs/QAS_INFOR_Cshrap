//PROJECT NAME: Logistics
//CLASS NAME: IAptrxVerifyInvNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface IAptrxVerifyInvNum
    {
        (int? ReturnCode,
        string Infobar) AptrxVerifyInvNumSp(
            string PVendNum,
            string PInvNum,
            string Infobar);
    }
}

