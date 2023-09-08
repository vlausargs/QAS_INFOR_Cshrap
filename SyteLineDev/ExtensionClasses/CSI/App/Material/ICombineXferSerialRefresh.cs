//PROJECT NAME: Material
//CLASS NAME: ICombineXferSerialRefresh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICombineXferSerialRefresh
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CombineXferSerialRefreshSp(string Item,
		decimal? QtyShipped,
		string FromSite,
		string FromWhse,
		string FromLoc,
		string FromLot,
		string ToSite,
		string ToWhse,
		string ToLoc,
		string ToLot,
		string StartSerNum,
		string ImportDocId,
		string TrnNum,
		int? TrnLine,
		int? PreassignSerials);
	}
}

