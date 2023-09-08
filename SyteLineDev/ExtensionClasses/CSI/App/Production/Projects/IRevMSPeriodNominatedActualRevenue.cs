//PROJECT NAME: Production
//CLASS NAME: IRevMSPeriodNominatedActualRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSPeriodNominatedActualRevenue
	{
		decimal? RevMSPeriodNominatedActualRevenueFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd,
			int? Nominated);
	}
}

