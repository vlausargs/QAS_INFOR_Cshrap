//PROJECT NAME: ReportExt
//CLASS NAME: SLCustomerByItemSalesAnalysisReport.cs

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
	[IDOExtensionClass("SLCustomerByItemSalesAnalysisReport")]
	public class SLCustomerByItemSalesAnalysisReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CustomerByItemSalesAnalysisSp([Optional] string COStatus,
		[Optional] string Source,
		[Optional] int? PageBetweenItems,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional] DateTime? OrderDateStarting,
		[Optional] DateTime? OrderDateEnding,
		[Optional] int? OrderDateStartingOffset,
		[Optional] int? OrderDateEndingOffset,
		[Optional, DefaultParameterValue(0)] int? PrintPrice,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_CustomerByItemSalesAnalysisExt = new Rpt_CustomerByItemSalesAnalysisFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_CustomerByItemSalesAnalysisExt.Rpt_CustomerByItemSalesAnalysisSp(COStatus,
				Source,
				PageBetweenItems,
				CustomerStarting,
				CustomerEnding,
				ItemStarting,
				ItemEnding,
				ProductCodeStarting,
				ProductCodeEnding,
				OrderDateStarting,
				OrderDateEnding,
				OrderDateStartingOffset,
				OrderDateEndingOffset,
				PrintPrice,
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
