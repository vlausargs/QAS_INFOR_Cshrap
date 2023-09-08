//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckIP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IRSQC_CheckIP
	{
		(int? ReturnCode, string Infobar) RSQC_CheckIPSp(string i_begjob,
		string i_endjob,
		string i_begsuffix,
		string i_endsuffix,
		DateTime? EarliestStartDate,
		DateTime? LatestStartDate,
		DateTime? EarliestJobEndDate,
		DateTime? LatestJobEndDate,
		int? EStartDateOffset = null,
		int? LStartDateOffset = null,
		int? EEndDateOffset = null,
		int? LEndDateOffset = null,
		string Infobar = null);
	}
}

