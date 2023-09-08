//PROJECT NAME: Material
//CLASS NAME: IGetUnitPricing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetUnitPricing
	{
		(int? ReturnCode, decimal? UnitPrice,
		decimal? DiscPercent,
		decimal? DiscUnitPrice,
		string Infobar,
		string ErrorMessage) GetUnitPricingSp(string CustNum,
		string Item,
		decimal? UnitPrice,
		decimal? DiscPercent,
		decimal? DiscUnitPrice,
		string Infobar,
		string ErrorMessage = null);
	}
}

