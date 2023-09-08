//PROJECT NAME: Logistics
//CLASS NAME: IShipmentPackageUnMerge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IShipmentPackageUnMerge
	{
		(int? ReturnCode, string Infobar) ShipmentPackageUnMergeSp(Guid? ProcessId,
		string Infobar);
	}
}

