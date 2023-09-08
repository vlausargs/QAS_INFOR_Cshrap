//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MaterialTransactionsReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_MaterialTransactionsReport
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Rpt_MaterialTransactionsReportSp(
            string SortBy = null,
            string OrderBy = null,
            string TransType = null,
            string RefType = null,
            int? Backflushed = null,
            int? NotBackflushed = null,
            int? DisplayHeader = null,
            int? PrintCost = null,
            string OrderType = null,
            decimal? TransNumStarting = null,
            decimal? TransNumEnding = null,
            string JobStarting = null,
            string JobEnding = null,
            int? SuffixStarting = null,
            int? SuffixEnding = null,
            DateTime? TransDateStarting = null,
            DateTime? TransDateEnding = null,
            string WhseStarting = null,
            string WhseEnding = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string LocationStarting = null,
            string LocationEnding = null,
            string ReasonCodeStarting = null,
            string ReasonCodeEnding = null,
            string CustomerOrderStarting = null,
            string CustomerOrderEnding = null,
            int? LineStarting = null,
            int? LineEnding = null,
            int? ReleaseStarting = null,
            int? ReleaseEnding = null,
            string StartingLot = null,
            string EndingLot = null,
            string StartingPO = null,
            string EndingPO = null,
            int? StartingPOLine = null,
            int? EndingPOLine = null,
            int? StartingPORelease = null,
            int? EndingPORelease = null,
            string StartingRMA = null,
            string EndingRMA = null,
            string StartingTransfer = null,
            string EndingTransfer = null,
            int? StartingTransferline = null,
            int? EndingTransferline = null,
            string WCStarting = null,
            string WCEnding = null,
            string PSNumStarting = null,
            string PSNumEnding = null,
            string PDocumentNumberStarting = null,
            string PDocumentNumberEnding = null,
            string SroStarting = null,
            string SroEnding = null,
            int? SroLineStarting = null,
            int? SroLineEnding = null,
            int? SroOperStarting = null,
            int? SroOperEnding = null,
            int? TransDateStartingOffset = null,
            int? TransDateEndingOffset = null,
            string PMessageLanguage = null,
            string pSite = null,
            string BGUser = null);
    }
}

