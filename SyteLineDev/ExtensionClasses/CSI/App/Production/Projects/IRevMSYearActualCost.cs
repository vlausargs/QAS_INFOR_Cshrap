//PROJECT NAME: Production
//CLASS NAME: IRevMSYearActualCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSYearActualCost
	{
		decimal? RevMSYearActualCostFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd);
	}
}

