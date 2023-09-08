//PROJECT NAME: Logistics
//CLASS NAME: IARBalanceByPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARBalanceByPeriod
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) ARBalanceByPeriodSp(
			int? FiscalYear,
			int? Period,
			string SiteGroup = null,
			string Infobar = null);
	}
}

