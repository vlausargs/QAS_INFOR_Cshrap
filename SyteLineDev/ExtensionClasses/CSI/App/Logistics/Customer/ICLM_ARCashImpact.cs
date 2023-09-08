//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ARCashImpact.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface ICLM_ARCashImpact
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ARCashImpactSp(
            string TransactionType = null,
            string FilterString = null);
    }
}

