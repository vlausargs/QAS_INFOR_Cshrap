//PROJECT NAME: MG
//CLASS NAME: SLBudgetConsolidationReport.cs

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
	[IDOExtensionClass("SLBudgetConsolidationReport")]
	public class SLBudgetConsolidationReport : ExtensionClassBase
	{


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GLBudgetConsbpSp(DateTime? pCutoffDate,
		int? pPostTrx,
		int? pSummaryOrDetail,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGLBudgetConsbpExt = new GLBudgetConsbpFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGLBudgetConsbpExt.GLBudgetConsbpSp(pCutoffDate,
				pPostTrx,
				pSummaryOrDetail,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
