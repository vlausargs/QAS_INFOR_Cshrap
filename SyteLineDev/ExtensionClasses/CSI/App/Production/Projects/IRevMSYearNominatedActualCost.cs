//PROJECT NAME: Production
//CLASS NAME: IRevMSYearNominatedActualCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSYearNominatedActualCost
	{
		decimal? RevMSYearNominatedActualCostFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd,
			int? Nominated);
	}
}

