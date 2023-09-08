//PROJECT NAME: ReportExt
//CLASS NAME: SLInventorySummaryComparisonReport.cs

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
    [IDOExtensionClass("SLInventorySummaryComparisonReport")]
    public class SLInventorySummaryComparisonReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InventorySummaryComparisonSp(string ItemStarting,
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
				
				var iRpt_InventorySummaryComparisonExt = new Rpt_InventorySummaryComparisonFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InventorySummaryComparisonExt.Rpt_InventorySummaryComparisonSp(ItemStarting,
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
