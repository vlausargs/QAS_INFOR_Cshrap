//PROJECT NAME: Data
//CLASS NAME: IItemWhseNotRsvdOnHand.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemWhseNotRsvdOnHand
	{
		decimal? ItemWhseNotRsvdOnHandFn(
			string Item,
			string Whse);
	}
}

