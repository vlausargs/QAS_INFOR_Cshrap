//PROJECT NAME: Data
//CLASS NAME: IMaxQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
	public interface IMaxQty
	{
		decimal? MaxQtyFn(decimal? Qty1,
		decimal? Qty2);

		decimal? MaxQtySp(
			decimal? Qty1,
			decimal? Qty2);
	}
}

