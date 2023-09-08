//PROJECT NAME: Data
//CLASS NAME: IItemAvailTotalQtyAvail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemAvailTotalQtyAvail
	{
		decimal? ItemAvailTotalQtyAvailFn(
			string Item,
			string Site);
	}
}

