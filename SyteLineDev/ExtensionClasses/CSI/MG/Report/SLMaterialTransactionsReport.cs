//PROJECT NAME: ReportExt
//CLASS NAME: SLMaterialTransactionsReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLMaterialTransactionsReport")]
    public class SLMaterialTransactionsReport : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_MaterialTransactionsReportSp([Optional] string SortBy,
             [Optional] string OrderBy,
             [Optional] string TransType,
             [Optional] string RefType,
             [Optional] int? Backflushed,
             [Optional] int? NotBackflushed,
             [Optional] int? DisplayHeader,
             [Optional] int? PrintCost,
             [Optional] string OrderType,
             [Optional] decimal? TransNumStarting,
             [Optional] decimal? TransNumEnding,
             [Optional] string JobStarting,
             [Optional] string JobEnding,
             [Optional] int? SuffixStarting,
             [Optional] int? SuffixEnding,
             [Optional] DateTime? TransDateStarting,
             [Optional] DateTime? TransDateEnding,
             [Optional] string WhseStarting,
             [Optional] string WhseEnding,
             [Optional] string ItemStarting,
             [Optional] string ItemEnding,
             [Optional] string LocationStarting,
             [Optional] string LocationEnding,
             [Optional] string ReasonCodeStarting,
             [Optional] string ReasonCodeEnding,
             [Optional] string CustomerOrderStarting,
             [Optional] string CustomerOrderEnding,
             [Optional] int? LineStarting,
             [Optional] int? LineEnding,
             [Optional] int? ReleaseStarting,
             [Optional] int? ReleaseEnding,
             [Optional] string StartingLot,
             [Optional] string EndingLot,
             [Optional] string StartingPO,
             [Optional] string EndingPO,
             [Optional] int? StartingPOLine,
             [Optional] int? EndingPOLine,
             [Optional] int? StartingPORelease,
             [Optional] int? EndingPORelease,
             [Optional] string StartingRMA,
             [Optional] string EndingRMA,
             [Optional] string StartingTransfer,
             [Optional] string EndingTransfer,
             [Optional] int? StartingTransferline,
             [Optional] int? EndingTransferline,
             [Optional] string WCStarting,
             [Optional] string WCEnding,
             [Optional] string PSNumStarting,
             [Optional] string PSNumEnding,
             [Optional] string PDocumentNumberStarting,
             [Optional] string PDocumentNumberEnding,
             [Optional] string SroStarting,
             [Optional] string SroEnding,
             [Optional] int? SroLineStarting,
             [Optional] int? SroLineEnding,
             [Optional] int? SroOperStarting,
             [Optional] int? SroOperEnding,
             [Optional] int? TransDateStartingOffset,
             [Optional] int? TransDateEndingOffset,
             [Optional] string PMessageLanguage,
             [Optional] string pSite,
             [Optional] string BGUser)
        {
            var iRpt_MaterialTransactionsReportExt = new Rpt_MaterialTransactionsReportFactory().Create(this, true);

            var result = iRpt_MaterialTransactionsReportExt.Rpt_MaterialTransactionsReportSp(SortBy,
                OrderBy,
                TransType,
                RefType,
                Backflushed,
                NotBackflushed,
                DisplayHeader,
                PrintCost,
                OrderType,
                TransNumStarting,
                TransNumEnding,
                JobStarting,
                JobEnding,
                SuffixStarting,
                SuffixEnding,
                TransDateStarting,
                TransDateEnding,
                WhseStarting,
                WhseEnding,
                ItemStarting,
                ItemEnding,
                LocationStarting,
                LocationEnding,
                ReasonCodeStarting,
                ReasonCodeEnding,
                CustomerOrderStarting,
                CustomerOrderEnding,
                LineStarting,
                LineEnding,
                ReleaseStarting,
                ReleaseEnding,
                StartingLot,
                EndingLot,
                StartingPO,
                EndingPO,
                StartingPOLine,
                EndingPOLine,
                StartingPORelease,
                EndingPORelease,
                StartingRMA,
                EndingRMA,
                StartingTransfer,
                EndingTransfer,
                StartingTransferline,
                EndingTransferline,
                WCStarting,
                WCEnding,
                PSNumStarting,
                PSNumEnding,
                PDocumentNumberStarting,
                PDocumentNumberEnding,
                SroStarting,
                SroEnding,
                SroLineStarting,
                SroLineEnding,
                SroOperStarting,
                SroOperEnding,
                TransDateStartingOffset,
                TransDateEndingOffset,
                PMessageLanguage,
                pSite,
                BGUser);


            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }
    }
}
