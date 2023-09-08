//PROJECT NAME: Data
//CLASS NAME: IItemWhseQtyOnHand2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemWhseQtyOnHand2
	{
		decimal? ItemWhseQtyOnHand2Fn(
			string Item);
	}
}

