//PROJECT NAME: Reporting
//CLASS NAME: IRPT_MaterialConstraintInquery.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_MaterialConstraintInquery
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_MaterialConstraintInquerySP(
			string pSite,
			DateTime? DateStarting,
			DateTime? DateEnding,
			string ItemStarting,
			string ItemEnding,
			int? ShowTop,
			string PlannerCodeStarting,
			string PlannerCodeEnding,
			string SourceType,
			int? ListDelayedDemands,
			string NotebookTab,
			string Period,
			int? Interval);
	}
}

