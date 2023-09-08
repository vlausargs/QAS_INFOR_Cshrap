//PROJECT NAME: Data
//CLASS NAME: IItemWhseQtyOnHand3.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemWhseQtyOnHand3
	{
		decimal? ItemWhseQtyOnHand3Fn(
			string Item,
			string Whse);
	}
}

