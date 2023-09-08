//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsInventorySummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsInventorySummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsInventorySummarySp(DateTime? PStartDate,
		DateTime? PEndDate,
		string FilterString,
		int? AltNo);
	}
}

