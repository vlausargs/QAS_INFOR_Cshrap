//PROJECT NAME: Production
//CLASS NAME: IRevMSPeriodNominatedActualCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSPeriodNominatedActualCost
	{
		decimal? RevMSPeriodNominatedActualCostFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd,
			int? Nominated);
	}
}

