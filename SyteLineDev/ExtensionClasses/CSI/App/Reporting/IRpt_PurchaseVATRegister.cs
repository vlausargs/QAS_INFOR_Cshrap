//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchaseVATRegister.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PurchaseVATRegister
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseVATRegisterSp(string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		DateTime? TaxPeriodDateStarting = null,
		DateTime? TaxPeriodDateEnding = null,
		string InvoiceStarting = null,
		string InvoiceEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		int? TaxPeriodDateStartingOffset = null,
		int? TaxPeriodDateEndingOffset = null,
		string Description = null,
		int? DisplayHeader = null,
		int? DisplaySummaryInvoice = null,
		string ECCodeStarting = null,
		string ECCodeEnding = null,
		string ReportType = null,
		string SortBy = null,
		string pSite = null);
	}
}

