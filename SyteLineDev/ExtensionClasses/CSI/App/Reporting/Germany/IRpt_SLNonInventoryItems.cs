//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLNonInventoryItems.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLNonInventoryItems : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLNonInventoryItemsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}