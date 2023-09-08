//PROJECT NAME: Logistics
//CLASS NAME: IHome_TrialBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHome_TrialBalance
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Home_TrialBalanceSp(string FilterString = null,
            DateTime? AsOfDate = null,
            string SiteGroup = null);
    }
}

