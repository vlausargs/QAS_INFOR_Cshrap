//PROJECT NAME: Logistics
//CLASS NAME: IPurgeTmpCoShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPurgeTmpCoShip
	{
		int? PurgeTmpCoShipSp(Guid? ProcessId);
	}
}

