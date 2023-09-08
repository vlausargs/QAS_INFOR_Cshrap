//PROJECT NAME: Logistics
//CLASS NAME: IShipConfirmation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IShipConfirmation
	{
		(int? ReturnCode, string InfoBar) ShipConfirmationSp(decimal? ShipmentId,
		DateTime? Curdate,
		int? IgnoreLCR,
		int? IgnoreCount,
		string InfoBar);
	}
}

