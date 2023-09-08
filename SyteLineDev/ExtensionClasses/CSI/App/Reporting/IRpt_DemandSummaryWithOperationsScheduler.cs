//PROJECT NAME: Reporting
//CLASS NAME: IRpt_DemandSummaryWithOperationsScheduler.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_DemandSummaryWithOperationsScheduler
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_DemandSummaryWithOperationsSchedulerSp(string ItemStarting = null,
		string ItemEnding = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		int? AltNum = 0,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

