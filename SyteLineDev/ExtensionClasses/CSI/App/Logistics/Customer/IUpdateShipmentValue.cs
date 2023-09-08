//PROJECT NAME: Logistics
//CLASS NAME: IUpdateShipmentValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUpdateShipmentValue
	{
		(int? ReturnCode, string Infobar) UpdateShipmentValueSp(decimal? Shipment,
		string Infobar);
	}
}

