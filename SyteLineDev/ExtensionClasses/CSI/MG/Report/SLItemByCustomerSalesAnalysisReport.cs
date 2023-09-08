//PROJECT NAME: ReportExt
//CLASS NAME: SLItemByCustomerSalesAnalysisReport.cs

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
    [IDOExtensionClass("SLItemByCustomerSalesAnalysisReport")]
    public class SLItemByCustomerSalesAnalysisReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItembyCustomerSalesAnalysisSP([Optional] string CustNumStarting,
		                                                   [Optional] string CustNumEnding,
		                                                   [Optional] DateTime? AsOfDate,
		                                                   [Optional] short? AsOfDateOffset,
		                                                   [Optional] byte? ShowDetail,
		                                                   [Optional] byte? PageBetweenItems,
		                                                   [Optional, DefaultParameterValue((byte)0)] byte? PrintPrice,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintCost,
		[Optional] byte? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItembyCustomerSalesAnalysisExt = new Rpt_ItembyCustomerSalesAnalysisFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItembyCustomerSalesAnalysisExt.Rpt_ItembyCustomerSalesAnalysisSP(CustNumStarting,
				                                                                                   CustNumEnding,
				                                                                                   AsOfDate,
				                                                                                   AsOfDateOffset,
				                                                                                   ShowDetail,
				                                                                                   PageBetweenItems,
				                                                                                   PrintPrice,
				                                                                                   PrintCost,
				                                                                                   DisplayHeader,
				                                                                                   TaskId,
				                                                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
