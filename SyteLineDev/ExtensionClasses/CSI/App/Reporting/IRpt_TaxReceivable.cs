//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TaxReceivable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TaxReceivable
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxReceivableSp(string StartingTaxCode = null,
		string EndingTaxCode = null,
		DateTime? StartingInvoiceDate = null,
		DateTime? EndingInvoiceDate = null,
		int? StartingInvoiceDateOffset = null,
		int? EndingInvoiceDateOffset = null,
		string StartingCust = null,
		string EndingCust = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

