//PROJECT NAME: Logistics
//CLASS NAME: IFTSLGetShipments.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetShipments
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) FTSLGetShipmentsSp(decimal? ShipmentId,
		string ShipLoc,
		string PackLoc,
		string Order,
		string ShipTo,
		string Infobar);
	}
}

