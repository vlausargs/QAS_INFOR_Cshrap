//PROJECT NAME: ReportExt
//CLASS NAME: SLGeneralLedgerTransactionWithMatlTransReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;


namespace CSI.MG.Report
{
    [IDOExtensionClass("SLGeneralLedgerTransactionWithMatlTransReport")]
    public class SLGeneralLedgerTransactionWithMatlTransReport : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable rpt_generalLedgertransactionSp([Optional] decimal? ExOptStartingTrans,
            [Optional] decimal? ExOptEndingTrans,
            [Optional] string ExOptStartingRef,
            [Optional] string ExOptEndingRef,
            [Optional] int? TAnalyticalLedger,
            [Optional] DateTime? ExOptStartingTransDate,
            [Optional] DateTime? ExOptEndingTransDate,
            [Optional] string ExOptStartingAcc,
            [Optional] string ExOptEndingAcc,
            [Optional] string ExOptacChartType,
            [Optional] string ExOptBegAcctUnit1,
            [Optional] string ExOptEndAcctUnit1,
            [Optional] string ExOptBegAcctUnit2,
            [Optional] string ExOptEndAcctUnit2,
            [Optional] string ExOptBegAcctUnit3,
            [Optional] string ExOptEndAcctUnit3,
            [Optional] string ExOptBegAcctUnit4,
            [Optional] string ExOptEndAcctUnit4,
            [Optional] string ExOptSortBy,
            [Optional] int? StartingTransDateOffset,
            [Optional] int? EndingTransDateOffset,
            [Optional] int? DisplayHeader,
            [Optional] int? ShowInternal,
            [Optional] int? ShowExternal,
            [Optional] string pSite)
        {
            var iRpt_GeneralLedgerTransactionExt = new Rpt_GeneralLedgerTransactionFactory().Create(this, true);

            var result = iRpt_GeneralLedgerTransactionExt.Rpt_GeneralLedgerTransactionSp(ExOptStartingTrans,
                ExOptEndingTrans,
                ExOptStartingRef,
                ExOptEndingRef,
                TAnalyticalLedger,
                ExOptStartingTransDate,
                ExOptEndingTransDate,
                ExOptStartingAcc,
                ExOptEndingAcc,
                ExOptacChartType,
                ExOptBegAcctUnit1,
                ExOptEndAcctUnit1,
                ExOptBegAcctUnit2,
                ExOptEndAcctUnit2,
                ExOptBegAcctUnit3,
                ExOptEndAcctUnit3,
                ExOptBegAcctUnit4,
                ExOptEndAcctUnit4,
                ExOptSortBy,
                StartingTransDateOffset,
                EndingTransDateOffset,
                DisplayHeader,
                ShowInternal,
                ShowExternal,
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
