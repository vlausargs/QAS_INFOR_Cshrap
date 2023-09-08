//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBShipLinePL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBShipLinePL
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBShipLinePLSp(string RefNum,
		DateTime? ShippedDateTime,
		string RefType,
		decimal? ShipmentID = null,
		string ShipmentStatus = null);
	}
}

