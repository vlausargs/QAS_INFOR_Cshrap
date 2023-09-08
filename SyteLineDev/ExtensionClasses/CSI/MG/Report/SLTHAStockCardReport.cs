//PROJECT NAME: ReportExt
//CLASS NAME: SLTHAStockCardReport.cs

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
	[IDOExtensionClass("SLTHAStockCardReport")]
	public class SLTHAStockCardReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable THARpt_StockBalanceSp([Optional] DateTime? pStartDate,
		[Optional] DateTime? pEndDate,
		[Optional] string pStartItem,
		[Optional] string pEndItem,
		[Optional] string pWhseStarting,
		[Optional] string pWhseEnding,
		[Optional] string pLocStarting,
		[Optional] string pLocEnding,
		[Optional, DefaultParameterValue(0)] int? pSumDtl,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHARpt_StockBalanceExt = new THARpt_StockBalanceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHARpt_StockBalanceExt.THARpt_StockBalanceSp(pStartDate,
				pEndDate,
				pStartItem,
				pEndItem,
				pWhseStarting,
				pWhseEnding,
				pLocStarting,
				pLocEnding,
				pSumDtl,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
