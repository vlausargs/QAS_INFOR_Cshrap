//PROJECT NAME: ReportExt
//CLASS NAME: SLEstimateWorksheetReport.cs

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
	[IDOExtensionClass("SLEstimateWorksheetReport")]
	public class SLEstimateWorksheetReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_EstimateWorksheetSp([Optional, DefaultParameterValue("WQPH")] string EstimateStatus,
		[Optional] string EstimateStarting,
		[Optional] string EstimateEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] DateTime? QuoteDateStarting,
		[Optional] DateTime? QuoteDateEnding,
		[Optional] int? QuoteDateStartingOffset,
		[Optional] int? QuoteDateEndingOffset,
		[Optional] DateTime? ExpireDateStarting,
		[Optional] DateTime? ExpireDateEnding,
		[Optional] int? ExpireDateStartingOffset,
		[Optional] int? ExpireDateEndingOffset,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string CustItemStarting,
		[Optional] string CustItemEnding,
		[Optional] DateTime? DueDateStarting,
		[Optional] DateTime? DueDateEnding,
		[Optional] int? DueDateStartingOffset,
		[Optional] int? DueDateEndingOffset,
		[Optional, DefaultParameterValue(1)] int? CoitemShowInternal,
		[Optional, DefaultParameterValue(1)] int? CoitemShowExternal,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional] string StartProspect,
		[Optional] string EndProspect,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_EstimateWorksheetExt = new Rpt_EstimateWorksheetFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_EstimateWorksheetExt.Rpt_EstimateWorksheetSp(EstimateStatus,
				EstimateStarting,
				EstimateEnding,
				CustomerStarting,
				CustomerEnding,
				QuoteDateStarting,
				QuoteDateEnding,
				QuoteDateStartingOffset,
				QuoteDateEndingOffset,
				ExpireDateStarting,
				ExpireDateEnding,
				ExpireDateStartingOffset,
				ExpireDateEndingOffset,
				ItemStarting,
				ItemEnding,
				CustItemStarting,
				CustItemEnding,
				DueDateStarting,
				DueDateEnding,
				DueDateStartingOffset,
				DueDateEndingOffset,
				CoitemShowInternal,
				CoitemShowExternal,
				DisplayHeader,
				StartProspect,
				EndProspect,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
