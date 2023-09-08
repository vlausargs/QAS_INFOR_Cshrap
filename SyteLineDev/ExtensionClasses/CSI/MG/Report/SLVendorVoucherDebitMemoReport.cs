//PROJECT NAME: ReportExt
//CLASS NAME: SLVendorVoucherDebitMemoReport.cs

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
    [IDOExtensionClass("SLVendorVoucherDebitMemoReport")]
    public class SLVendorVoucherDebitMemoReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VendorVoucherDebitMemoSp([Optional, DefaultParameterValue(0)] int? DetailPurchaseOrder,
		[Optional, DefaultParameterValue(0)] int? DetailItem,
		[Optional, DefaultParameterValue(0)] int? DetailVendorItem,
		[Optional, DefaultParameterValue(0)] int? VendorProfileUseProfile,
		[Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] int? VoucherStarting,
		[Optional] int? VoucherEnding,
		[Optional] string PoNumStarting,
		[Optional] string PoNumEnding,
		[Optional] string InvNumStarting,
		[Optional] string InvNumEnding,
		[Optional] DateTime? VoucherDateStarting,
		[Optional] DateTime? VoucherDateEnding,
		[Optional] int? VoucherDateStartingOffset,
		[Optional] int? VoucherDateEndingOffset,
		[Optional, DefaultParameterValue(0)] int? VoucherDateIncrement,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional, DefaultParameterValue(0)] int? ShowInternal,
		[Optional, DefaultParameterValue(0)] int? ShowExternal,
		[Optional, DefaultParameterValue(0)] int? PrintItemOverview,
		[Optional] int? TaskID,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_VendorVoucherDebitMemoExt = new Rpt_VendorVoucherDebitMemoFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_VendorVoucherDebitMemoExt.Rpt_VendorVoucherDebitMemoSp(DetailPurchaseOrder,
				DetailItem,
				DetailVendorItem,
				VendorProfileUseProfile,
				VendorStarting,
				VendorEnding,
				VoucherStarting,
				VoucherEnding,
				PoNumStarting,
				PoNumEnding,
				InvNumStarting,
				InvNumEnding,
				VoucherDateStarting,
				VoucherDateEnding,
				VoucherDateStartingOffset,
				VoucherDateEndingOffset,
				VoucherDateIncrement,
				DisplayHeader,
				ShowInternal,
				ShowExternal,
				PrintItemOverview,
				TaskID,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
