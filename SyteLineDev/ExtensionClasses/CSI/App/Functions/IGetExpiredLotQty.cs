//PROJECT NAME: Data
//CLASS NAME: IGetExpiredLotQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetExpiredLotQty
	{
		decimal? GetExpiredLotQtyFn(
			string Item,
			DateTime? CutoffDate,
			string Whse);
	}
}

