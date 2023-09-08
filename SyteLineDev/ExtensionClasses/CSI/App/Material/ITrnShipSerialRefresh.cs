//PROJECT NAME: Material
//CLASS NAME: ITrnShipSerialRefresh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITrnShipSerialRefresh
	{
		(ICollectionLoadResponse Data, int? ReturnCode) TrnShipSerialRefreshSp(string Item,
		decimal? QtyShipped,
		string FromSite,
		string FromWhse,
		string FromLoc,
		string FromLot,
		string ToSite,
		string ToWhse,
		string ToLoc,
		string ToLot,
		string FobSite,
		string TrnNum,
		int? TrnLine,
		string StartSerNum,
		string ImportDocId,
		int? PreassignSerials);
	}
}

