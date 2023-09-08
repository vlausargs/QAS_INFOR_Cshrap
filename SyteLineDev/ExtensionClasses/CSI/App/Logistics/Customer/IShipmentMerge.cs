//PROJECT NAME: Logistics
//CLASS NAME: IShipmentMerge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IShipmentMerge
	{
		(int? ReturnCode, string Infobar) ShipmentMergeSp(decimal? OldShipment,
		decimal? NewShipment,
		string Infobar);
	}
}

