//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectedItemCompletionsbyResourceGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectedItemCompletionsbyResourceGroup
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectedItemCompletionsbyResourceGroupSp(string ScheduleTypes = null,
		string StartingResource = null,
		string EndingResource = null,
		string StartingResourceGroup = null,
		string EndingResourceGroup = null,
		DateTime? StartingDate = null,
		DateTime? EndingDate = null,
		int? StartingDateOffset = null,
		int? EndingDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

