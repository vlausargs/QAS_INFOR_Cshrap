//PROJECT NAME: Production
//CLASS NAME: IApsSyncCustomerOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncCustomerOrder
	{
		int? ApsSyncCustomerOrderSp(
			Guid? Partition);
	}
}

