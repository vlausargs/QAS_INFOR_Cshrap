//PROJECT NAME: ReportExt
//CLASS NAME: SLPurchaseOrderHistorybyVendorReport.cs

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
    [IDOExtensionClass("SLPurchaseOrderHistorybyVendorReport")]
    public class SLPurchaseOrderHistorybyVendorReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PurchaseOrderHistorybyVendorSp([Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] DateTime? OrderDateStarting,
		[Optional] DateTime? OrderDateEnding,
		[Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] string VendOrderStarting,
		[Optional] string VendOrderEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string VendItemStarting,
		[Optional] string VendItemEnding,
		[Optional] DateTime? DueDateStarting,
		[Optional] DateTime? DueDateEnding,
		[Optional] DateTime? LastRcvdDateStarting,
		[Optional] DateTime? LastRcvdDateEnding,
		[Optional] string WhseStarting,
		[Optional] string WhseEnding,
		[Optional] string POType,
		[Optional] int? IncludeGRN,
		[Optional] int? TranslateToDomesticCurrency,
		[Optional] int? OrderDateStartingOffset,
		[Optional] int? OrderDateEndingOffset,
		[Optional] int? LastRcvdDateStartingOffset,
		[Optional] int? LastRcvdDateEndingOffset,
		[Optional] int? DueDateStartingOffset,
		[Optional] int? DueDateEndingOffset,
		[Optional] int? ShowCost,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PurchaseOrderHistorybyVendorExt = new Rpt_PurchaseOrderHistorybyVendorFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PurchaseOrderHistorybyVendorExt.Rpt_PurchaseOrderHistorybyVendorSp(OrderStarting,
				OrderEnding,
				OrderDateStarting,
				OrderDateEnding,
				VendorStarting,
				VendorEnding,
				VendOrderStarting,
				VendOrderEnding,
				ItemStarting,
				ItemEnding,
				VendItemStarting,
				VendItemEnding,
				DueDateStarting,
				DueDateEnding,
				LastRcvdDateStarting,
				LastRcvdDateEnding,
				WhseStarting,
				WhseEnding,
				POType,
				IncludeGRN,
				TranslateToDomesticCurrency,
				OrderDateStartingOffset,
				OrderDateEndingOffset,
				LastRcvdDateStartingOffset,
				LastRcvdDateEndingOffset,
				DueDateStartingOffset,
				DueDateEndingOffset,
				ShowCost,
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
