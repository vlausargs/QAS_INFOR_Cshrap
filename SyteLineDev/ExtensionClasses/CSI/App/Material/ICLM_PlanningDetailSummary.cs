//PROJECT NAME: Material
//CLASS NAME: ICLM_PlanningDetailSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_PlanningDetailSummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PlanningDetailSummarySp(string Item,
		string FilterString = null);
	}
}

