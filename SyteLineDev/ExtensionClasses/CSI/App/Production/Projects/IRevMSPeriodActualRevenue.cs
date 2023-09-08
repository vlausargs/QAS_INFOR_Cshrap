//PROJECT NAME: Production
//CLASS NAME: IRevMSPeriodActualRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSPeriodActualRevenue
	{
		decimal? RevMSPeriodActualRevenueFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd);
	}
}

