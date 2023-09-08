//PROJECT NAME: ReportExt
//CLASS NAME: SLDemandSummaryComparisonAPSReport.cs

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
    [IDOExtensionClass("SLDemandSummaryComparisonAPSReport")]
    public class SLDemandSummaryComparisonAPSReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DemandSummaryComparisonAPSSp(string ItemStarting,
		                                                  string ItemEnding,
		                                                  DateTime? StartDate,
		                                                  DateTime? EndDate,
		                                                  short? AltNum,
		                                                  short? AltNum2,
		                                                  [Optional] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_DemandSummaryComparisonAPSExt = new Rpt_DemandSummaryComparisonAPSFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_DemandSummaryComparisonAPSExt.Rpt_DemandSummaryComparisonAPSSp(ItemStarting,
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
