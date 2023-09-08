//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TransferOrderStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_TransferOrderStatus
    {
            (ICollectionLoadResponse Data, int? ReturnCode) 
        Rpt_TransferOrderStatusSp(
                string TransOrderStarting = null,
            string TransOrderEnding = null,
            string ExOptszTransferStat = null,
            string ExOptszTrnitemStat = null,
            int? ExOptprQtyLoss = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string FromSiteStarting = null,
            string FromSiteEnding = null,
            string ToSiteStarting = null,
            string ToSiteEnding = null,
            string FromWhseStarting = null,
            string FromWhseEnding = null,
            string TransitLocStarting = null,
            string TransitLocEnding = null,
            string ToWhseStarting = null,
            string ToWhseEnding = null,
            DateTime? SchRcptDateStarting = null,
            DateTime? SchRcptDateEnding = null,
            DateTime? SchShipDateStarting = null,
            DateTime? SchShipDateEnding = null,
            DateTime? LastRcptStarting = null,
            DateTime? LastRcptEnding = null,
            string OrderBy = null,
            int? QuantityInTransitOnly = null,
            int? SchRcptDateStartingOffset = null,
            int? SchRcptDateEndingOffset = null,
            int? SchShipDateStartingOffset = null,
            int? SchShipDateEndingOffset = null,
            int? LastRcptStartingOffset = null,
            int? LastRcptEndingOffset = null,
            DateTime? OrderDateStarting = null,
            DateTime? OrderDateEnding = null,
            int? OrderDateStartingOffset = null,
            int? OrderDateEndingOffset = null,
            int? DisplayHeader = null,
            int? TaskId = null,
            string pSite = null);
    }
}

