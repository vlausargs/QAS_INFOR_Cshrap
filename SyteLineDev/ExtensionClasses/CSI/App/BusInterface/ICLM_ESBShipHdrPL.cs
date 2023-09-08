//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBShipHdrPL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBShipHdrPL
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBShipHdrPLSp(string RefNum,
		DateTime? ShippedDateTime,
		string RefType,
		decimal? ShipmentID = null,
		string ShipmentStatus = null);
	}
}

