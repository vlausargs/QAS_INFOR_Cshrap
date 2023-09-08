//PROJECT NAME: ReportExt
//CLASS NAME: SLTransferOrderStatusReport.cs

using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLTransferOrderStatusReport")]
    public class SLTransferOrderStatusReport : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_TransferOrderStatusSp([Optional] string TransOrderStarting,
            [Optional] string TransOrderEnding,
            [Optional] string ExOptszTransferStat,
            [Optional] string ExOptszTrnitemStat,
            [Optional] int? ExOptprQtyLoss,
            [Optional] string ItemStarting,
            [Optional] string ItemEnding,
            [Optional] string FromSiteStarting,
            [Optional] string FromSiteEnding,
            [Optional] string ToSiteStarting,
            [Optional] string ToSiteEnding,
            [Optional] string FromWhseStarting,
            [Optional] string FromWhseEnding,
            [Optional] string TransitLocStarting,
            [Optional] string TransitLocEnding,
            [Optional] string ToWhseStarting,
            [Optional] string ToWhseEnding,
            [Optional] DateTime? SchRcptDateStarting,
            [Optional] DateTime? SchRcptDateEnding,
            [Optional] DateTime? SchShipDateStarting,
            [Optional] DateTime? SchShipDateEnding,
            [Optional] DateTime? LastRcptStarting,
            [Optional] DateTime? LastRcptEnding,
            [Optional] string OrderBy,
            [Optional] int? QuantityInTransitOnly,
            [Optional] int? SchRcptDateStartingOffset,
            [Optional] int? SchRcptDateEndingOffset,
            [Optional] int? SchShipDateStartingOffset,
            [Optional] int? SchShipDateEndingOffset,
            [Optional] int? LastRcptStartingOffset,
            [Optional] int? LastRcptEndingOffset,
            [Optional] DateTime? OrderDateStarting,
            [Optional] DateTime? OrderDateEnding,
            [Optional] int? OrderDateStartingOffset,
            [Optional] int? OrderDateEndingOffset,
            [Optional] int? DisplayHeader,
            [Optional] int? TaskId,
            [Optional] string pSite)
        {
            var iRpt_TransferOrderStatusExt = new Rpt_TransferOrderStatusFactory().Create(this, true);

            var result = iRpt_TransferOrderStatusExt.Rpt_TransferOrderStatusSp(TransOrderStarting,
                TransOrderEnding,
                ExOptszTransferStat,
                ExOptszTrnitemStat,
                ExOptprQtyLoss,
                ItemStarting,
                ItemEnding,
                FromSiteStarting,
                FromSiteEnding,
                ToSiteStarting,
                ToSiteEnding,
                FromWhseStarting,
                FromWhseEnding,
                TransitLocStarting,
                TransitLocEnding,
                ToWhseStarting,
                ToWhseEnding,
                SchRcptDateStarting,
                SchRcptDateEnding,
                SchShipDateStarting,
                SchShipDateEnding,
                LastRcptStarting,
                LastRcptEnding,
                OrderBy,
                QuantityInTransitOnly,
                SchRcptDateStartingOffset,
                SchRcptDateEndingOffset,
                SchShipDateStartingOffset,
                SchShipDateEndingOffset,
                LastRcptStartingOffset,
                LastRcptEndingOffset,
                OrderDateStarting,
                OrderDateEnding,
                OrderDateStartingOffset,
                OrderDateEndingOffset,
                DisplayHeader,
                TaskId,
                pSite);

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
