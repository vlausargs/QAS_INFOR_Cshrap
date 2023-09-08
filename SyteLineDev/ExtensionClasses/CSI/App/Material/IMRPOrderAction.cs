//PROJECT NAME: Material
//CLASS NAME: IMRPOrderAction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMRPOrderAction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MRPOrderActionSp(
			string PlannerCodeStarting,
			string PlannerCodeEnding,
			string ItemStarting,
			string ItemEnding,
			DateTime? StartDate,
			DateTime? EndDate,
			string Source,
			int? TempPlannerCode,
			int? IncludeNull);
	}
}

