//PROJECT NAME: Logistics
//CLASS NAME: IAPBalanceByPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface IAPBalanceByPeriod
    {
        (ICollectionLoadResponse Data, int? ReturnCode,
            string Infobar) APBalanceByPeriodSp(
            int? FiscalYear,
            int? Period,
            string SiteGroup = null,
            string Infobar = null);
    }
}
