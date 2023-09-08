//PROJECT NAME: ReportExt
//CLASS NAME: SLCycleCountVarianceReport.cs

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
    [IDOExtensionClass("SLCycleCountVarianceReport")]
    public class SLCycleCountVarianceReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CycleCountVarianceSp([Optional] string ABCCode,
		                                          [Optional] string SortBy,
		                                          [Optional] byte? ShowOnlyItemWithVar,
		                                          [Optional] string ItemStarting,
		                                          [Optional] string ItemEnding,
		                                          [Optional] string LocStarting,
		                                          [Optional] string LocEnding,
		                                          [Optional] string ProductCodeStarting,
		                                          [Optional] string ProductCodeEnding,
		                                          [Optional] string PlanCodeStarting,
		                                          [Optional] string PlanCodeEnding,
		                                          [Optional, DefaultParameterValue((byte)0)] byte? PrintCost,
		[Optional, DefaultParameterValue((byte)1)] byte? DisplayHeader,
		[Optional] string ForWhse,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CycleCountVarianceExt = new Rpt_CycleCountVarianceFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CycleCountVarianceExt.Rpt_CycleCountVarianceSp(ABCCode,
				                                                                 SortBy,
				                                                                 ShowOnlyItemWithVar,
				                                                                 ItemStarting,
				                                                                 ItemEnding,
				                                                                 LocStarting,
				                                                                 LocEnding,
				                                                                 ProductCodeStarting,
				                                                                 ProductCodeEnding,
				                                                                 PlanCodeStarting,
				                                                                 PlanCodeEnding,
				                                                                 PrintCost,
				                                                                 DisplayHeader,
				                                                                 ForWhse,
				                                                                 BGSessionId,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
