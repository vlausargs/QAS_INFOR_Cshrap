//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPItemHistory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPItemHistory
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPItemHistorySp(
			string begjob = null,
			string endjob = null,
			int? begsuffix = null,
			int? endsuffix = null,
			string begpsnum = null,
			string endpsnum = null,
			DateTime? begtdate = null,
			DateTime? endtdate = null,
			int? PageBetweenItems = null,
			int? DisplayHeader = null);
	}
}

