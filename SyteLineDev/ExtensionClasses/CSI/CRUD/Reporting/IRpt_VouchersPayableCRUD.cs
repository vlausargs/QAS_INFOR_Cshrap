using CSI.Data.CRUD;
using System;

namespace CSI.Reporting
{
    public interface IRpt_VouchersPayableCRUD
    {
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_VouchersPayableSp(
            string AltExtGenSp,
            string POType = null,
            int? TransDomCurr = null,
            int? ShowDetail = null,
            DateTime? CutoffDate = null,
            string PoStarting = null,
            string PoEnding = null,
            string VendorStarting = null,
            string VendorEnding = null,
            int? CutoffDateOffset = null,
            int? DisplayHeader = null,
            string SiteGroup = null,
            string BuilderPoStarting = null,
            string BuilderPoEnding = null,
            int? TaskId = null,
            int? PrintItemOverview = null,
            string BGSessionId = null,
            string pSite = null);

        ICollectionLoadResponse AddSummaryFields(int? Severity);
    }
}