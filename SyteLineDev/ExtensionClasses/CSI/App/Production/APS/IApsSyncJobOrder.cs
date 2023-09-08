//PROJECT NAME: Production
//CLASS NAME: IApsSyncJobOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncJobOrder
	{
		int? ApsSyncJobOrderSp(
			Guid? Partition);
	}
}

