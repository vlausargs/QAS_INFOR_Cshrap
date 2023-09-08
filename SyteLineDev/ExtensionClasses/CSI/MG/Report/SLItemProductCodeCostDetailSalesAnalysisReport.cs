//PROJECT NAME: ReportExt
//CLASS NAME: SLItemProductCodeCostDetailSalesAnalysisReport.cs

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
    [IDOExtensionClass("SLItemProductCodeCostDetailSalesAnalysisReport")]
    public class SLItemProductCodeCostDetailSalesAnalysisReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemProductCodeCostDetailSalesAnalysisSp([Optional] DateTime? AsOfDate,
		                                                              [Optional] string ProductCodeStarting,
		                                                              [Optional] string ProductCodeEnding,
		                                                              [Optional] string ItemStarting,
		                                                              [Optional] string ItemEnding,
		                                                              [Optional] short? AsOfDateOffset,
		                                                              [Optional, DefaultParameterValue((byte)0)] byte? PrintPrice,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintCost,
		[Optional] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemProductCodeCostDetailSalesAnalysisExt = new Rpt_ItemProductCodeCostDetailSalesAnalysisFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemProductCodeCostDetailSalesAnalysisExt.Rpt_ItemProductCodeCostDetailSalesAnalysisSp(AsOfDate,
				                                                                                                         ProductCodeStarting,
				                                                                                                         ProductCodeEnding,
				                                                                                                         ItemStarting,
				                                                                                                         ItemEnding,
				                                                                                                         AsOfDateOffset,
				                                                                                                         PrintPrice,
				                                                                                                         PrintCost,
				                                                                                                         DisplayHeader,
				                                                                                                         pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
