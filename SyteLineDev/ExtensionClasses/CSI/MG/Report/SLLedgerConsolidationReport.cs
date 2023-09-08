//PROJECT NAME: ReportExt
//CLASS NAME: SLLedgerConsolidationReport.cs

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
	[IDOExtensionClass("SLLedgerConsolidationReport")]
	public class SLLedgerConsolidationReport : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable LedgerConsolSp([Optional] string pConsolidated,
		[Optional] DateTime? pCutoffDate,
		[Optional] DateTime? pCTADate,
		[Optional] int? pPostTrx,
		[Optional] string pMode,
		[Optional] int? pSummaryOrDetail,
		[Optional] int? pYearEnd,
		[Optional] int? pUseCTADate,
		[Optional] int? FASB52Override,
		[Optional] decimal? UserID,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLedgerConsolExt = new LedgerConsolFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLedgerConsolExt.LedgerConsolSp(pConsolidated,
				pCutoffDate,
				pCTADate,
				pPostTrx,
				pMode,
				pSummaryOrDetail,
				pYearEnd,
				pUseCTADate,
				FASB52Override,
				UserID,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
