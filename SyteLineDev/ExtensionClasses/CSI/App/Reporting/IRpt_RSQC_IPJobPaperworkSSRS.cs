//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPJobPaperworkSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPJobPaperworkSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPJobPaperworkSSRSSp(string begjob = null,
		string endjob = null,
		int? begsuffix = null,
		int? endsuffix = null,
		string begpsnum = null,
		string endpsnum = null,
		int? DisplayHeader = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null);
	}
}

