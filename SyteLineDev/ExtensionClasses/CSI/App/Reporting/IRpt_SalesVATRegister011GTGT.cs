//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SalesVATRegister011GTGT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SalesVATRegister011GTGT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SalesVATRegister011GTGTSp(string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		DateTime? TaxPeriodDateStarting = null,
		DateTime? TaxPeriodDateEnding = null,
		string InvoiceStarting = null,
		string InvoiceEnding = null,
		int? TaxPeriodDateStartingOffset = null,
		int? TaxPeriodDateEndingOffset = null,
		string Description = null,
		int? DisplayHeader = null,
		string ECCodeStarting = null,
		string ECCodeEnding = null,
		string ReportType = null,
		int? DisplaySummaryInvoice = null,
		string SortBy = null,
		string pSite = null);
	}
}

