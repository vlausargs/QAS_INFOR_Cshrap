//PROJECT NAME: Production
//CLASS NAME: IRevMSYearNominatedPlanRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSYearNominatedPlanRevenue
	{
		decimal? RevMSYearNominatedPlanRevenueFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd,
			int? Nominated);
	}
}

