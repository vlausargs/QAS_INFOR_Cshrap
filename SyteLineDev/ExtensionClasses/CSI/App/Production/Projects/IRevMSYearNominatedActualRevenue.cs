//PROJECT NAME: Production
//CLASS NAME: IRevMSYearNominatedActualRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSYearNominatedActualRevenue
	{
		decimal? RevMSYearNominatedActualRevenueFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd,
			int? Nominated);
	}
}

