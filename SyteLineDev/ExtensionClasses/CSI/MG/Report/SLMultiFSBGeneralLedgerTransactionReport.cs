//PROJECT NAME: ReportExt
//CLASS NAME: SLMultiFSBGeneralLedgerTransactionReport.cs

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
    [IDOExtensionClass("SLMultiFSBGeneralLedgerTransactionReport")]
    public class SLMultiFSBGeneralLedgerTransactionReport : ExtensionClassBase
    {

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Rpt_MultiFSBGeneralLedgerTransactionSp([Optional] decimal? ExOptStartingTrans,
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
        [Optional] string FSBName,
        [Optional] string pSite)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var mgInvoker = new MGInvoker(this.Context);

                var iRpt_MultiFSBGeneralLedgerTransactionExt = new Rpt_MultiFSBGeneralLedgerTransactionFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iRpt_MultiFSBGeneralLedgerTransactionExt.Rpt_MultiFSBGeneralLedgerTransactionSp(ExOptStartingTrans,
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
                FSBName,
                pSite);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }
    }
}
