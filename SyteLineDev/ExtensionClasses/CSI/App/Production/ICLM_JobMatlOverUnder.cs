//PROJECT NAME: Production
//CLASS NAME: ICLM_JobMatlOverUnder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_JobMatlOverUnder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_JobMatlOverUnderSp(DateTime? CompletedDate = null,
		string PlanCode = "%",
		string FilterString = null,
		string SiteGroup = null);
	}
}

