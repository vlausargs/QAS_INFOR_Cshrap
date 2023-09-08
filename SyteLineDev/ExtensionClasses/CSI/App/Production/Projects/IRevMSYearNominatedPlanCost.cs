//PROJECT NAME: Production
//CLASS NAME: IRevMSYearNominatedPlanCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSYearNominatedPlanCost
	{
		decimal? RevMSYearNominatedPlanCostFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd,
			int? Nominated);
	}
}

