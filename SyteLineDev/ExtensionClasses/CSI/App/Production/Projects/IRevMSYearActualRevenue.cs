//PROJECT NAME: Production
//CLASS NAME: IRevMSYearActualRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSYearActualRevenue
	{
		decimal? RevMSYearActualRevenueFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd);
	}
}

