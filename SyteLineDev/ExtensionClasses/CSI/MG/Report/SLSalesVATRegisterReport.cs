//PROJECT NAME: ReportExt
//CLASS NAME: SLSalesVATRegisterReport.cs

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
    [IDOExtensionClass("SLSalesVATRegisterReport")]
    public class SLSalesVATRegisterReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SalesVATRegisterSp([Optional] string TaxCodeStarting,
			[Optional] string TaxCodeEnding,
			[Optional] DateTime? TaxPeriodDateStarting,
			[Optional] DateTime? TaxPeriodDateEnding,
			[Optional] string InvoiceStarting,
			[Optional] string InvoiceEnding,
			[Optional] int? TaxPeriodDateStartingOffset,
			[Optional] int? TaxPeriodDateEndingOffset,
			[Optional] string Description,
			[Optional] int? DisplayHeader,
			[Optional] string ECCodeStarting,
			[Optional] string ECCodeEnding,
			string ReportType,
			[Optional] int? DisplaySummaryInvoice,
			[Optional] string SortBy,
			[Optional] string pSite)
		{
			var iRpt_SalesVATRegisterExt = new Rpt_SalesVATRegisterFactory().Create(this, true);

			var result = iRpt_SalesVATRegisterExt.Rpt_SalesVATRegisterSp(TaxCodeStarting,
				TaxCodeEnding,
				TaxPeriodDateStarting,
				TaxPeriodDateEnding,
				InvoiceStarting,
				InvoiceEnding,
				TaxPeriodDateStartingOffset,
				TaxPeriodDateEndingOffset,
				Description,
				DisplayHeader,
				ECCodeStarting,
				ECCodeEnding,
				ReportType,
				DisplaySummaryInvoice,
				SortBy,
				pSite);


			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
	}
}
