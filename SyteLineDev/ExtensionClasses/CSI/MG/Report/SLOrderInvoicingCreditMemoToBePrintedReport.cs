//PROJECT NAME: ReportExt
//CLASS NAME: SLOrderInvoicingCreditMemoToBePrintedReport.cs

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
    [IDOExtensionClass("SLOrderInvoicingCreditMemoToBePrintedReport")]
    public class SLOrderInvoicingCreditMemoToBePrintedReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_OrderInvoicingCreditMemoToBePrintedSp(string CustomerStarting,
		string CustomerEnding,
		string OrderStarting,
		string OrderEnding,
		int? OrderLineStarting,
		int? OrderLineEnding,
		int? OrderReleaseStarting,
		int? OrderReleaseEnding,
		DateTime? ShipDateStarting,
		DateTime? ShipDateEnding,
		int? CreateFromPackSlip,
		int? PackNumStarting,
		int? PackNumEnding,
		int? CreateFromShipment,
		decimal? ShipmentIdStarting,
		decimal? ShipmentIdEnding,
		DateTime? InvDate,
		string InvoiceType,
		string PrintCustomerItemItem,
		string InvoiceOrCreditMemo,
		int? PrintStandardOrderText,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_OrderInvoicingCreditMemoToBePrintedExt = new Rpt_OrderInvoicingCreditMemoToBePrintedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_OrderInvoicingCreditMemoToBePrintedExt.Rpt_OrderInvoicingCreditMemoToBePrintedSp(CustomerStarting,
				CustomerEnding,
				OrderStarting,
				OrderEnding,
				OrderLineStarting,
				OrderLineEnding,
				OrderReleaseStarting,
				OrderReleaseEnding,
				ShipDateStarting,
				ShipDateEnding,
				CreateFromPackSlip,
				PackNumStarting,
				PackNumEnding,
				CreateFromShipment,
				ShipmentIdStarting,
				ShipmentIdEnding,
				InvDate,
				InvoiceType,
				PrintCustomerItemItem,
				InvoiceOrCreditMemo,
				PrintStandardOrderText,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
