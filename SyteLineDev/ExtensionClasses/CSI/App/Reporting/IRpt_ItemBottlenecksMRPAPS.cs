//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ItemBottlenecksMRPAPS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ItemBottlenecksMRPAPS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemBottlenecksMRPAPSSp(string SourceType = null,
		int? ListDelayedDemands = null,
		string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? DisplayHeader = null,
		int? ALTNO = null,
		string pSite = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		string BuyerStart = null,
		string BuyerEnd = null);
	}
}

