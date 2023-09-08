//PROJECT NAME: Material
//CLASS NAME: ICOShippingSerialRefresh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICOShippingSerialRefresh
	{
		(ICollectionLoadResponse Data, int? ReturnCode) COShippingSerialRefreshSp(string Item,
		decimal? QtyShipped,
		int? UbCRRt,
		string Whse,
		string Loc,
		string Lot,
		string StartSerNum,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string DoNum,
		int? DoLine,
		decimal? ShipmentID,
		int? ShipmentLine,
		int? ShipmentSeq,
		int? Gen,
		decimal? GenQty,
		string ImportDocId,
		int? TransType,
		string StartingSerial,
		string EndingSerial,
		string ContainerNum);
	}
}

