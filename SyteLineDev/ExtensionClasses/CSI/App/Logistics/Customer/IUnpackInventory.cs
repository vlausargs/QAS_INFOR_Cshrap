//PROJECT NAME: Logistics
//CLASS NAME: IUnpackInventory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUnpackInventory
	{
		(int? ReturnCode, string Infobar) UnpackInventorySp(Guid? ProcessId,
		int? ReturnToPickList,
		int? ReduceQuantityOnly,
		string Infobar,
		int? DeleteEmptyShipment = 0);
	}
}

