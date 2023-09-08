//PROJECT NAME: Production
//CLASS NAME: IApsSyncTransferOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncTransferOrder
	{
		int? ApsSyncTransferOrderSp(
			Guid? Partition);
	}
}
