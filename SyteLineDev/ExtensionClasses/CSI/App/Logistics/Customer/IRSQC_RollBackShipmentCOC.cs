//PROJECT NAME: Logistics
//CLASS NAME: IRSQC_RollBackShipmentCOC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRSQC_RollBackShipmentCOC
	{
		(int? ReturnCode, string Infobar) RSQC_RollBackShipmentCOCSp(decimal? ShipmentId,
		string Infobar);
	}
}

