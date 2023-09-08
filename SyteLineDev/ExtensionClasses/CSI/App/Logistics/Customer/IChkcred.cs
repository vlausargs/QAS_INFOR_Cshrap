//PROJECT NAME: Logistics.Customer
//CLASS NAME: IChkcred.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IChkcred
    {
        (int? ReturnCode,
            string CredHold) ChkcredSp(
            string CustNum,
            string CredHold);
    }
}