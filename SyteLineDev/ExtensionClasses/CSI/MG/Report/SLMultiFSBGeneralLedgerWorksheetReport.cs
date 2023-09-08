//PROJECT NAME: ReportExt
//CLASS NAME: SLMultiFSBGeneralLedgerWorksheetReport.cs

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
    [IDOExtensionClass("SLMultiFSBGeneralLedgerWorksheetReport")]
    public class SLMultiFSBGeneralLedgerWorksheetReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MultiFSBGeneralLedgerWorksheetSp([Optional] DateTime? ExOptacAsOfDate,
		[Optional] string ExStartingAccount,
		[Optional] string ExEndingAccount,
		[Optional] string ExOptacChartType,
		[Optional] int? TAnalyticalLedger,
		[Optional] int? DateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string FSBName,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MultiFSBGeneralLedgerWorksheetExt = new Rpt_MultiFSBGeneralLedgerWorksheetFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MultiFSBGeneralLedgerWorksheetExt.Rpt_MultiFSBGeneralLedgerWorksheetSp(ExOptacAsOfDate,
				ExStartingAccount,
				ExEndingAccount,
				ExOptacChartType,
				TAnalyticalLedger,
				DateOffset,
				DisplayHeader,
				FSBName,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
