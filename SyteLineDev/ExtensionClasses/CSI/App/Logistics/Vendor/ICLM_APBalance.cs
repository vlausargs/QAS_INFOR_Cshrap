//PROJECT NAME: Logistics
//CLASS NAME: ICLM_APBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
    public interface ICLM_APBalance
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode,
        string Infobar) CLM_APBalanceSp(
            int? FiscalYear,
            int? Period,
            string SiteGroup,
            string FilterString = null,
            string Infobar = null);
    }
}
