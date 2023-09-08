//PROJECT NAME: MG
//CLASS NAME: SLSalesVATRegister011GTGT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLSalesVATRegister011GTGT")]
	public class SLSalesVATRegister011GTGT : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SalesVATRegister011GTGTSp([Optional] string TaxCodeStarting,
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
			var iRpt_SalesVATRegister011GTGTExt = new Rpt_SalesVATRegister011GTGTFactory().Create(this, true);
			
			var result = iRpt_SalesVATRegister011GTGTExt.Rpt_SalesVATRegister011GTGTSp(TaxCodeStarting,
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
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
