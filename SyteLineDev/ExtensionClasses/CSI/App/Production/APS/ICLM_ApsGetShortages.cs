//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetShortages.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetShortages
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) CLM_ApsGetShortagesSp(
            string DemandType,
            string DemandRef,
            string Item,
            string PlannerCode,
            DateTime? StartDate,
            DateTime? DueDate,
            int? AltNo,
            string ProductCode = null,
            string FilterString = null);
    }
}
