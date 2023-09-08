//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ApprovedNotInvoiced.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ApprovedNotInvoiced
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ApprovedNotInvoicedSp(string OrderStarting = null,
		string OrderEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? DateApprovedStarting = null,
		DateTime? DateApprovedEnding = null,
		int? DateApprovedStartingOffset = null,
		int? DateApprovedEndingOffset = null,
		int? DisplayReportHeader = 1,
		string pSite = null);
	}
}

