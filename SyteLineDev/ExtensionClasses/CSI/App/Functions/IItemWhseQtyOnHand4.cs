//PROJECT NAME: Data
//CLASS NAME: IItemWhseQtyOnHand4.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemWhseQtyOnHand4
	{
		decimal? ItemWhseQtyOnHand4Fn(
			string Item,
			string Whse);
	}
}

