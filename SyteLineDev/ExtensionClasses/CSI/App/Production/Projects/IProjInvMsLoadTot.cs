//PROJECT NAME: Production
//CLASS NAME: IProjInvMsLoadTot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjInvMsLoadTot
	{
		(int? ReturnCode, decimal? PTotPerPlanInvAmt,
		decimal? PTotPerActInvAmt,
		decimal? PTotPerNomPlanInvAmt,
		decimal? PTotPerNomActInvAmt,
		decimal? PTotYrPlanInvAmt,
		decimal? PTotYrActInvAmt,
		decimal? PTotYrNomPlanInvAmt,
		decimal? PTotYrNomActInvAmt) ProjInvMsLoadTotSp(DateTime? PCurrentPeriodStart,
		DateTime? PCurrentPeriodEnd,
		decimal? PTotPerPlanInvAmt,
		decimal? PTotPerActInvAmt,
		decimal? PTotPerNomPlanInvAmt,
		decimal? PTotPerNomActInvAmt,
		decimal? PTotYrPlanInvAmt,
		decimal? PTotYrActInvAmt,
		decimal? PTotYrNomPlanInvAmt,
		decimal? PTotYrNomActInvAmt);
	}
}

