//PROJECT NAME: Production
//CLASS NAME: IRevMSPeriodActualCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSPeriodActualCost
	{
		decimal? RevMSPeriodActualCostFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd);
	}
}

