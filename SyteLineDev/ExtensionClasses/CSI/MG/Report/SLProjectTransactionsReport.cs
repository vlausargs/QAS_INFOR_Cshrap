//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectTransactionsReport.cs

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
    [IDOExtensionClass("SLProjectTransactionsReport")]
    public class SLProjectTransactionsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectTransactionsSp([Optional] string StartingProject,
		[Optional] string EndingProject,
		[Optional] string CostClass,
		[Optional] string ProjectStatus,
		[Optional] int? StartingTask,
		[Optional] int? EndingTask,
		[Optional] DateTime? StartingTransDate,
		[Optional] int? StartingTransDateOffset,
		[Optional] DateTime? EndingTransDate,
		[Optional] int? EndingTransDateOffset,
		[Optional] string StartingCostCode,
		[Optional] string EndingCostCode,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional, DefaultParameterValue(1)] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] string DocumentNumStarting,
		[Optional] string DocumentNumEnding)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjectTransactionsExt = new Rpt_ProjectTransactionsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectTransactionsExt.Rpt_ProjectTransactionsSp(StartingProject,
				EndingProject,
				CostClass,
				ProjectStatus,
				StartingTask,
				EndingTask,
				StartingTransDate,
				StartingTransDateOffset,
				EndingTransDate,
				EndingTransDateOffset,
				StartingCostCode,
				EndingCostCode,
				PrintCost,
				DisplayHeader,
				pSite,
				DocumentNumStarting,
				DocumentNumEnding);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
