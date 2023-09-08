//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PackingSlipDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PackingSlipDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PackingSlipDetailSp(string OrderStarting = null,
		string OrderEnding = null,
		int? OrderLineStarting = null,
		int? OrderLineEnding = null,
		int? OrderReleaseStarting = null,
		int? OrderReleaseEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? PackSlipStarting = null,
		int? PackSlipEnding = null,
		DateTime? PackDateStarting = null,
		DateTime? PackDateEnding = null,
		int? PackDateStartingOffset = null,
		int? PackDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

