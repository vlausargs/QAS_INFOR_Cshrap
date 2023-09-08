//PROJECT NAME: Data
//CLASS NAME: IItemAvailTotalQtyOnHandForTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemAvailTotalQtyOnHandForTrans
	{
		decimal? ItemAvailTotalQtyOnHandForTransFn(
			string Item,
			string Whse,
			string Loc,
			string Lot);
	}
}

