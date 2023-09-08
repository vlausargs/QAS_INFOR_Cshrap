//PROJECT NAME: Production
//CLASS NAME: IRevMSPeriodNominatedPlanCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSPeriodNominatedPlanCost
	{
		decimal? RevMSPeriodNominatedPlanCostFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd,
			int? Nominated);
	}
}

