//PROJECT NAME: ReportExt
//CLASS NAME: SLItemSalespersonSalesAnalysisReport.cs

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
    [IDOExtensionClass("SLItemSalespersonSalesAnalysisReport")]
    public class SLItemSalespersonSalesAnalysisReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemSalespersonSalesAnalysisSP([Optional] string ExBegSlsman,
		                                                    [Optional] string ExEndSlsman,
		                                                    [Optional] DateTime? ExOptacAsOfDate,
		                                                    [Optional] short? ExOptacAsOfDateOffset,
		                                                    [Optional] byte? ExOptprPageItems,
		                                                    [Optional] byte? DisplayHeader,
		                                                    [Optional] int? TaskId,
		                                                    [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_ItemSalespersonSalesAnalysisExt = new Rpt_ItemSalespersonSalesAnalysisFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_ItemSalespersonSalesAnalysisExt.Rpt_ItemSalespersonSalesAnalysisSP(ExBegSlsman,
				                                                                                     ExEndSlsman,
				                                                                                     ExOptacAsOfDate,
				                                                                                     ExOptacAsOfDateOffset,
				                                                                                     ExOptprPageItems,
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
