//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MRPOrderAction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MRPOrderAction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MRPOrderActionSp(string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		int? StartDateOffSet = null,
		int? EndDateOffSet = null,
		string Source = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

