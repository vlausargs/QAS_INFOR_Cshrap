using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.CRUD;

namespace CSI.Reporting
{
    public interface IRpt_VouchersPayableSub
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_VouchersPayableSubSp(string POType = null,
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
            string BGSessionId = null,
            int? TaskId = null,
            string Infobar = null,
            int? PrintItemOverview = null,
            int? UseSite = 0,
            int? recordCapOverwrite = null);
    }
}
