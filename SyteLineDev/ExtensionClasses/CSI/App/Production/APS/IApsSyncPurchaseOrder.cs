//PROJECT NAME: Production
//CLASS NAME: IApsSyncPurchaseOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncPurchaseOrder
	{
		int? ApsSyncPurchaseOrderSp(
			Guid? Partition);
	}
}

