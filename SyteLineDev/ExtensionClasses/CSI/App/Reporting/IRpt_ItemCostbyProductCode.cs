//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ItemCostbyProductCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_ItemCostbyProductCode
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemCostbyProductCodeSp(string StartProdCode = null,
            string EndProdCode = null,
            string StartItem = null,
            string EndItem = null,
            string FromWarehouse = null,
            string ToWarehouse = null,
            string MatlStat = null,
            string MatlType = null,
            string Source = null,
            string Stocked = null,
            string ABCCode = null,
            int? PrintZeroQty = null,
            int? PrintCostDet = null,
            int? DisplayHeader = null,
            int? CostItemAtWhse = null,
            string pSite = null);
    }
}

