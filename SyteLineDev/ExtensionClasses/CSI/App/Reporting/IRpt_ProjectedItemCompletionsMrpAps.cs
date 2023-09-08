//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectedItemCompletionsMrpAps.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectedItemCompletionsMrpAps
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectedItemCompletionsMrpApsSp(string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		int? StartDateOffSet = null,
		int? EndDateOffSet = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

