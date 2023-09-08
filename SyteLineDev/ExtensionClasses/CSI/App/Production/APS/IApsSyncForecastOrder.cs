//PROJECT NAME: Production
//CLASS NAME: IApsSyncForecastOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncForecastOrder
	{
		int? ApsSyncForecastOrderSp(
			Guid? Partition);
	}
}

