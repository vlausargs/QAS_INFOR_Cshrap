//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPAction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPAction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPActionSp(
			string begjob = null,
			string endjob = null,
			int? begsuffix = null,
			int? endsuffix = null,
			string begpsnum = null,
			string endpsnum = null,
			string JustJobs = null,
			int? ShowDetail = null,
			int? DisplayHeader = null);
	}
}

