//PROJECT NAME: Data
//CLASS NAME: IItemAvailTotalQtyOnHand.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemAvailTotalQtyOnHand
	{
		decimal? ItemAvailTotalQtyOnHandFn(
			string Item);
	}
}

