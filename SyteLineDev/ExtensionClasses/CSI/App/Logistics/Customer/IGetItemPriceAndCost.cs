//PROJECT NAME: Logistics
//CLASS NAME: IGetItemPriceAndCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetItemPriceAndCost
	{
		(int? ReturnCode, decimal? PUnitPrice,
		decimal? PUnitCost,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		string Infobar,
		decimal? LineDisc) GetItemPriceAndCostSp(string PItem,
		string PCustNum,
		string PUM,
		string PCurrCode,
		decimal? PRate,
		int? PReprice,
		decimal? PQtyOrdered,
		DateTime? POrderDate,
		string PPriceCode,
		string PFeatStr,
		decimal? PUnitPrice,
		decimal? PUnitCost,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		string Infobar,
		string PCoNum,
		int? PCoLine,
		string PCustItem,
		decimal? LineDisc = 0);
	}
}

