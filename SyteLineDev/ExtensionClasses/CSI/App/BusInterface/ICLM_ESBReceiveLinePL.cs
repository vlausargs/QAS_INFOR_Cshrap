//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBReceiveLinePL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBReceiveLinePL
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBReceiveLinePLSp(string RefNum,
		DateTime? ReceivedDateTime,
		string RefType,
		decimal? ShipmentID = null);
	}
}

