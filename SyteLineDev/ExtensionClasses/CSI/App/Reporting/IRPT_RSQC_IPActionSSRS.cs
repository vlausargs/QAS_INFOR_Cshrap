//PROJECT NAME: Reporting
//CLASS NAME: IRPT_RSQC_IPActionSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_RSQC_IPActionSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_IPActionSSRSSp(string begjob = null,
		string endjob = null,
		int? begsuffix = null,
		int? endsuffix = null,
		string begpsnum = null,
		string endpsnum = null,
		string JustJobs = null,
		int? ShowDetail = null,
		int? DisplayHeader = null,
		string psite = null);
	}
}

