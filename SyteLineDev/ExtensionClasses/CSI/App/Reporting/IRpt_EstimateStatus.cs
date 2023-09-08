//PROJECT NAME: Reporting
//CLASS NAME: IRpt_EstimateStatus.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting
{
    public interface IRpt_EstimateStatus
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateStatusSp(string OrderStarting = null,
            string OrderEnding = null,
            string EstStatus = null,
            string CustomerStarting = null,
            string CustomerEnding = null,
            DateTime? QuoteDateStarting = null,
            DateTime? QuoteDateEnding = null,
            int? QuoteDateStartingOffset = null,
            int? QuoteDateEndingOffset = null,
            DateTime? ExpDateStarting = null,
            DateTime? ExpDateEnding = null,
            int? ExpDateStartingOffset = null,
            int? ExpDateEndingOffset = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string CustItemStarting = null,
            string CustItemEnding = null,
            DateTime? DueDateStarting = null,
            DateTime? DueDateEnding = null,
            int? DueDateStartingOffset = null,
            int? DueDateEndingOffset = null,
            int? PrintDetail = null,
            string SortBy = null,
            int? ShowCONotes = null,
            int? ShowLineRelNotes = null,
            int? ShowInternal = null,
            int? ShowExternal = null,
            int? PrintCost = 0,
            int? DisplayHeader = null,
            string StartProspect = null,
            string EndProspect = null,
            string BGSessionId = null,
            string pSite = null,
            string BGUser = null);
    }
}

