//PROJECT NAME: Reporting
//CLASS NAME: IRpt_TaxableRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_TaxableRevenue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxableRevenueSP(string TaxCodeStarting = null,
		string TaxCodeEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		int? InvoiceDateStartingOffset = null,
		int? InvoiceDateEndingOffset = null,
		int? ShowDetail = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

