//PROJECT NAME: ReportExt
//CLASS NAME: SLProductSalesAnalysisReport.cs

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
    [IDOExtensionClass("SLProductSalesAnalysisReport")]
    public class SLProductSalesAnalysisReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProductSalesAnalysisSp([Optional] string StartProdCode,
		[Optional] string EndProdCode,
		[Optional] string StartFamCode,
		[Optional] string EndFamCode,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] DateTime? AsOfDate,
		[Optional] string UsePriceOrQty,
		[Optional] string SortBy,
		[Optional] int? AsOfDateOffset,
		[Optional, DefaultParameterValue(0)] int? PrintPrice,
		[Optional] int? DisplayHeader,
		[Optional] int? DisplayNonInventoryItem,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProductSalesAnalysisExt = new Rpt_ProductSalesAnalysisFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProductSalesAnalysisExt.Rpt_ProductSalesAnalysisSp(StartProdCode,
				EndProdCode,
				StartFamCode,
				EndFamCode,
				StartItem,
				EndItem,
				AsOfDate,
				UsePriceOrQty,
				SortBy,
				AsOfDateOffset,
				PrintPrice,
				DisplayHeader,
				DisplayNonInventoryItem,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
