//PROJECT NAME: Logistics
//CLASS NAME: IGenerateShipment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateShipment
	{
		(int? ReturnCode, string InfoBar) GenerateShipmentSP(Guid? ProcessId,
		string ShipLoc,
		int? Packages,
		decimal? Weight,
		string WeightUm,
		string InfoBar,
		string ShipmentStatus = null);
	}
}

