//PROJECT NAME: Production
//CLASS NAME: IRevMSPeriodPlanCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSPeriodPlanCost
	{
		decimal? RevMSPeriodPlanCostFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd);
	}
}

