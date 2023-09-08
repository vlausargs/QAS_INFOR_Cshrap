//PROJECT NAME: Logistics
//CLASS NAME: IFTSLGetShipmentLines.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetShipmentLines
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) FTSLGetShipmentLinesSp(decimal? ShipmentId,
		decimal? PickListId,
		string Infobar);
	}
}

