//PROJECT NAME: Production
//CLASS NAME: IRevMSYearPlanCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSYearPlanCost
	{
		decimal? RevMSYearPlanCostFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd);
	}
}

