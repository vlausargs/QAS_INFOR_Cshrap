//PROJECT NAME: Production
//CLASS NAME: IRevMSPeriodPlanRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSPeriodPlanRevenue
	{
		decimal? RevMSPeriodPlanRevenueFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd);
	}
}

