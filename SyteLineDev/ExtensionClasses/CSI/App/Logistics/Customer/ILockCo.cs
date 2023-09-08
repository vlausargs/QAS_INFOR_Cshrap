//PROJECT NAME: Logistics
//CLASS NAME: ILockCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ILockCo
	{
		int? LockCoSp(string CoNum,
		int? Lock);
	}
}

