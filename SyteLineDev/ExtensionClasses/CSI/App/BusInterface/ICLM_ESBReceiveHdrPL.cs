//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReceiveHdrPL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReceiveHdrPL
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBReceiveHdrPLSp(string RefNum,
		DateTime? ReceivedDateTime,
		string RefType,
		decimal? ShipmentID = null);
	}
}

