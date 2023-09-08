//PROJECT NAME: Production
//CLASS NAME: IRevMSPeriodNominatedPlanRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSPeriodNominatedPlanRevenue
	{
		decimal? RevMSPeriodNominatedPlanRevenueFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd,
			int? Nominated);
	}
}

