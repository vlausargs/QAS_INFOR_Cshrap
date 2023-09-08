//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InventoryBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_InventoryBalance
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Rpt_InventoryBalanceSp(
            string ProductCodeStarting = null,
            string ProductCodeEnding = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string WhseStarting = null,
            string WhseEnding = null,
            string LocStarting = null,
            string LocEnding = null,
            DateTime? TransDateStarting = null,
            DateTime? TransDateEnding = null,
            string ReasonCodeStarting = null,
            string ReasonCodeEnding = null,
            int? SummaryDtl = 0,
            int? OneItmPerPg = null,
            int? IncludeMoveTrn = null,
            int? IncludeNonNetStk = null,
            int? DisplayHeader = null,
            int? TransDateStartingOffset = null,
            int? TransDateEndingOffset = null,
            string pSite = null,
            string MessageLanguage = null,
            string DocumentNumStarting = null,
            string DocumentNumEnding = null,
            Guid? ProcessId = null);
    }
}

