//PROJECT NAME: ReportExt
//CLASS NAME: SLInventoryBalanceReport.cs

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
    [IDOExtensionClass("SLInventoryBalanceReport")]
    public class SLInventoryBalanceReport : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_InventoryBalanceSp([Optional] string ProductCodeStarting,
            [Optional] string ProductCodeEnding,
            [Optional] string ItemStarting,
            [Optional] string ItemEnding,
            [Optional] string WhseStarting,
            [Optional] string WhseEnding,
            [Optional] string LocStarting,
            [Optional] string LocEnding,
            [Optional] DateTime? TransDateStarting,
            [Optional] DateTime? TransDateEnding,
            [Optional] string ReasonCodeStarting,
            [Optional] string ReasonCodeEnding,
            [Optional, DefaultParameterValue(0)] int? SummaryDtl,
            [Optional] int? OneItmPerPg,
            [Optional] int? IncludeMoveTrn,
            [Optional] int? IncludeNonNetStk,
            [Optional] int? DisplayHeader,
            [Optional] int? TransDateStartingOffset,
            [Optional] int? TransDateEndingOffset,
            [Optional] string pSite,
            [Optional] string MessageLanguage,
            [Optional] string DocumentNumStarting,
            [Optional] string DocumentNumEnding,
            [Optional] Guid? ProcessId)
        {
            var iRpt_InventoryBalanceExt = new Rpt_InventoryBalanceFactory().Create(this, true);

            var result = iRpt_InventoryBalanceExt.Rpt_InventoryBalanceSp(ProductCodeStarting,
                ProductCodeEnding,
                ItemStarting,
                ItemEnding,
                WhseStarting,
                WhseEnding,
                LocStarting,
                LocEnding,
                TransDateStarting,
                TransDateEnding,
                ReasonCodeStarting,
                ReasonCodeEnding,
                SummaryDtl,
                OneItmPerPg,
                IncludeMoveTrn,
                IncludeNonNetStk,
                DisplayHeader,
                TransDateStartingOffset,
                TransDateEndingOffset,
                pSite,
                MessageLanguage,
                DocumentNumStarting,
                DocumentNumEnding,
                ProcessId);

            if (result.ReturnCode != 0)
            {
                throw new Exception();
            }

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
