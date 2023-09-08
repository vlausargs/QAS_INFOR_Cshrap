//PROJECT NAME: Logistics
//CLASS NAME: IShipmentSplitting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IShipmentSplitting
	{
		(int? ReturnCode, decimal? NewShipment,
		int? NewLine,
		string Infobar) ShipmentSplittingSp(int? Package = null,
		decimal? OldShipment = null,
		int? OldLine = null,
		int? OldSeq = null,
		int? CreateNewLine = null,
		decimal? NewShipment = null,
		int? NewLine = null,
		string Infobar = null);
	}
}

