//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSSRORpt_MatlRequirement.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSSRORpt_MatlRequirement
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSFSSRORpt_MatlRequirementSP(string PSRONumberStarting = null,
		string PSRONumberEnding = null,
		int? PSROLineNumberStarting = null,
		int? PSROLineNumberEnding = null,
		int? PSROOperNumberStarting = null,
		int? PSROOperNumberEnding = null,
		string PItemStarting = null,
		string PItemEnding = null,
		int? PIncludePostedPlanned = 0,
		string Infobar = null,
		int? PIncludeSRODemand = 1,
		string PCustNumStarting = null,
		string PCustNumEnding = null,
		string PProdCodeStarting = null,
		string PProdCodeEnding = null,
		DateTime? PSROLineDueDateStarting = null,
		DateTime? PSROLineDueDateEnding = null,
		int? PShowShortages = 0,
		string PSortby = "SRO",
		string pSite = null);
	}
}

