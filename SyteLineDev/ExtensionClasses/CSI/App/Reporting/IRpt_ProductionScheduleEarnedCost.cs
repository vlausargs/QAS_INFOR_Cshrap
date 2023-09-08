//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductionScheduleEarnedCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductionScheduleEarnedCost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleEarnedCostSp(DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		string ScheduleIdStarting = null,
		string ScheduleIdEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? TransDateStartingOffset = null,
		int? TransDateEndingOffset = null,
		int? PrintCost = 0,
		string pSite = null);
	}
}

