//PROJECT NAME: Data
//CLASS NAME: IMoveInventoryForUnPickedItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMoveInventoryForUnPickedItem
	{
		(int? ReturnCode,
			string Infobar) MoveInventoryForUnPickedItemSp(
			decimal? ShipmentID,
			string ShipLoc,
			string Infobar);
	}
}

