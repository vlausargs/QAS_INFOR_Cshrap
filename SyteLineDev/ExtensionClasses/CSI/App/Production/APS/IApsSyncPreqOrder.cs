//PROJECT NAME: Production
//CLASS NAME: IApsSyncPreqOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncPreqOrder
	{
		int? ApsSyncPreqOrderSp(
			Guid? Partition);
	}
}

