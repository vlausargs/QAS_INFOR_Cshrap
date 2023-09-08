//PROJECT NAME: ReportExt
//CLASS NAME: SLPurchaseVATRegisterReport.cs

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
    [IDOExtensionClass("SLPurchaseVATRegisterReport")]
    public class SLPurchaseVATRegisterReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PurchaseVATRegisterSp([Optional] string TaxCodeStarting,
		[Optional] string TaxCodeEnding,
		[Optional] DateTime? TaxPeriodDateStarting,
		[Optional] DateTime? TaxPeriodDateEnding,
		[Optional] string InvoiceStarting,
		[Optional] string InvoiceEnding,
		[Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] int? TaxPeriodDateStartingOffset,
		[Optional] int? TaxPeriodDateEndingOffset,
		[Optional] string Description,
		[Optional] int? DisplayHeader,
		[Optional] int? DisplaySummaryInvoice,
		[Optional] string ECCodeStarting,
		[Optional] string ECCodeEnding,
		string ReportType,
		[Optional] string SortBy,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PurchaseVATRegisterExt = new Rpt_PurchaseVATRegisterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PurchaseVATRegisterExt.Rpt_PurchaseVATRegisterSp(TaxCodeStarting,
				TaxCodeEnding,
				TaxPeriodDateStarting,
				TaxPeriodDateEnding,
				InvoiceStarting,
				InvoiceEnding,
				VendorStarting,
				VendorEnding,
				TaxPeriodDateStartingOffset,
				TaxPeriodDateEndingOffset,
				Description,
				DisplayHeader,
				DisplaySummaryInvoice,
				ECCodeStarting,
				ECCodeEnding,
				ReportType,
				SortBy,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
