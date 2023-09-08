//PROJECT NAME: Reporting
//CLASS NAME: ITHARpt_SalesTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ITHARpt_SalesTax
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THARpt_SalesTaxSp(int? TranslateToDomesticCurrency = null,
		string InvoiceStarting = null,
		string InvoiceEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? InvoiceDateStartingOffset = null,
		int? InvoiceDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null,
		int? UnPostedVAT = 0,
		int? PostedVAT = 1,
		string BranchId = null);
	}
}

