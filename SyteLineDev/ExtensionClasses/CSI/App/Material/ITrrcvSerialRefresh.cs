//PROJECT NAME: Material
//CLASS NAME: ITrrcvSerialRefresh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITrrcvSerialRefresh
	{
		(ICollectionLoadResponse Data, int? ReturnCode) TrrcvSerialRefreshSp(string Item,
		decimal? QtyReceived,
		string FromSite,
		string FromWhse,
		string TrnLoc,
		string FromLot,
		string ToSite,
		string ToWhse,
		string ToLoc,
		string ToLot,
		string FobSite,
		string TrnNum,
		int? TrnLine,
		string StartSerNum,
		string ImportDocId);
	}
}

