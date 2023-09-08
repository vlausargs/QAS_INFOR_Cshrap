//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PlanningBOMNextLevel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PlanningBOMNextLevel
	{
		int? Rpt_PlanningBOMNextLevelSp(
			int? Level,
			string Item,
			string Orig_Item,
			DateTime? EffectiveDate,
			int? IndentedLevelView,
			int? ShowPrice,
			int? TErr);
	}
}

