//PROJECT NAME: ReportExt
//CLASS NAME: SLDemandSummaryComparisonSchedulerReport.cs

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
    [IDOExtensionClass("SLDemandSummaryComparisonSchedulerReport")]
    public class SLDemandSummaryComparisonSchedulerReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DemandSummaryComparisonSchedulerSp([Optional] string ItemStarting,
		                                                        [Optional] string ItemEnding,
		                                                        [Optional] DateTime? StartDate,
		                                                        [Optional] DateTime? EndDate,
		                                                        [Optional, DefaultParameterValue((short)0)] short? AltNum,
		[Optional, DefaultParameterValue((short)0)] short? AltNum2,
		[Optional] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_DemandSummaryComparisonSchedulerExt = new Rpt_DemandSummaryComparisonSchedulerFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_DemandSummaryComparisonSchedulerExt.Rpt_DemandSummaryComparisonSchedulerSp(ItemStarting,
				                                                                                             ItemEnding,
				                                                                                             StartDate,
				                                                                                             EndDate,
				                                                                                             AltNum,
				                                                                                             AltNum2,
				                                                                                             DisplayHeader,
				                                                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
