//PROJECT NAME: Production
//CLASS NAME: IApsSyncMpsOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncMpsOrder
	{
		int? ApsSyncMpsOrderSp(
			Guid? Partition);
	}
}

