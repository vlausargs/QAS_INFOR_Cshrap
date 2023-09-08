//PROJECT NAME: Data
//CLASS NAME: IItemWhseQtyOnHand.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemWhseQtyOnHand
	{
		decimal? ItemWhseQtyOnHandFn(
			string Item);
	}
}

