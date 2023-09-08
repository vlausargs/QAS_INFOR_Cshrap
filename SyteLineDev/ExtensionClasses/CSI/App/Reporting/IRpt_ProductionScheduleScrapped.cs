//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProductionScheduleScrapped.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProductionScheduleScrapped
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionScheduleScrappedSp(DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		string ScheduleIdStarting = null,
		string ScheduleIdEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? TransDateStartingOffset = null,
		int? TransDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null);
	}
}

