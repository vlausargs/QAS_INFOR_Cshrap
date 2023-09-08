//PROJECT NAME: Logistics
//CLASS NAME: IShipCoShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IShipCoShip
	{
		(int? ReturnCode, int? Posted,
		string Infobar) ShipCoShipSp(string PShipCoCoNum,
		DateTime? ShipProcGenDate,
		int? Posted,
		string Infobar,
		int? PBatchId,
		string PDoNum);
	}
}

