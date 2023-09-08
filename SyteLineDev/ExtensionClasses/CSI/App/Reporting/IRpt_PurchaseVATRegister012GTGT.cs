//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchaseVATRegister012GTGT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PurchaseVATRegister012GTGT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseVATRegister012GTGTSp(string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		DateTime? TaxPeriodDateStarting = null,
		DateTime? TaxPeriodDateEnding = null,
		string InvoiceStarting = null,
		string InvoiceEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		int? TaxPeriodDateStartingOffset = null,
		int? TaxPeriodDateEndingOffset = null,
		string AccountPrefix = null,
		string pSite = null);
	}
}

