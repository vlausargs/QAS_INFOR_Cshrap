//PROJECT NAME: Production
//CLASS NAME: IApsSyncProjectOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncProjectOrder
	{
		int? ApsSyncProjectOrderSp(
			Guid? Partition);
	}
}

