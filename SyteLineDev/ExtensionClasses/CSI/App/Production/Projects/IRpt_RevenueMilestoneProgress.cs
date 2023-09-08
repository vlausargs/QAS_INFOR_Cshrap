//PROJECT NAME: Production
//CLASS NAME: IRpt_RevenueMilestoneProgress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRpt_RevenueMilestoneProgress
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RevenueMilestoneProgressSp(string PProjectNumStarting,
		string PProjectNumEnding,
		string PRevMSNumStarting,
		string PRevMSNumEnding,
		string PSite = null);
	}
}

