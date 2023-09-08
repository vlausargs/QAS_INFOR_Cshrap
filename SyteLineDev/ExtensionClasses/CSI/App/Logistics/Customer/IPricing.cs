//PROJECT NAME: Logistics
//CLASS NAME: IPricing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPricing
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
		decimal? ContPrice,
		string PricingBasis,
		string Infobar) PricingSP(string CustNum,
		string Item,
		string CustItem = null,
		string CurrCode = null,
		decimal? BrkQty1 = null,
		decimal? BrkQty2 = null,
		decimal? BrkQty3 = null,
		decimal? BrkQty4 = null,
		decimal? BrkQty5 = null,
		decimal? UnitPrice1 = null,
		decimal? UnitPrice2 = null,
		decimal? UnitPrice3 = null,
		decimal? UnitPrice4 = null,
		decimal? UnitPrice5 = null,
		decimal? ContPrice = null,
		string PricingBasis = null,
		string Infobar = null);
	}
}

