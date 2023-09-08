//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetSupplyUsage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetSupplyUsage
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ApsGetSupplyUsageSp(
            string SupplyType,
            string SupplyID,
            int? SupplyMatltag,
            Guid? SupplyRowPtr,
            string Item,
            DateTime? DueDate,
            string WildCardChar,
            int? AltNo,
            string FilterString);
    }
}

