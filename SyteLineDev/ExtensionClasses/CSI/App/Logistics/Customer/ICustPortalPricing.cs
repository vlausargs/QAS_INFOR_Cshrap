//PROJECT NAME: Logistics
//CLASS NAME: ICustPortalPricing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustPortalPricing
	{
		(int? ReturnCode, decimal? BrkQty1,
		decimal? BrkQty2,
		decimal? BrkQty3,
		decimal? BrkQty4,
		decimal? BrkQty5,
		decimal? UnitPrice1,
		decimal? UnitPrice2,
		decimal? UnitPrice3,
		decimal? UnitPrice4,
		decimal? UnitPrice5,
		decimal? ContactPrice,
		string ISOCurrCode,
		string Infobar) CustPortalPricingSp(string CustNum,
		string Item,
		string ItemIndicator,
		decimal? BrkQty1,
		decimal? BrkQty2,
		decimal? BrkQty3,
		decimal? BrkQty4,
		decimal? BrkQty5,
		decimal? UnitPrice1,
		decimal? UnitPrice2,
		decimal? UnitPrice3,
		decimal? UnitPrice4,
		decimal? UnitPrice5,
		decimal? ContactPrice,
		string ISOCurrCode,
		string Infobar);
	}
}

