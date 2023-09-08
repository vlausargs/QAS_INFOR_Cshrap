//PROJECT NAME: Logistics
//CLASS NAME: ICLM_CustomerOrderPriceHistory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface ICLM_CustomerOrderPriceHistory
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_CustomerOrderPriceHistorySp(
            string CustNum,
            string Item,
            string FilterString,
            string PSiteGroup = null);
    }
}

