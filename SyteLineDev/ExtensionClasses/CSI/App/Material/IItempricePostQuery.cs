//PROJECT NAME: Material
//CLASS NAME: IItempricePostQuery.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItempricePostQuery
	{
		(int? ReturnCode, decimal? DerUnitPrice1,
		decimal? DerUnitPrice2,
		decimal? DerUnitPrice3,
		decimal? DerUnitPrice4,
		decimal? DerUnitPrice5) ItempricePostQuerySp(decimal? UnitPrice1,
		decimal? UnitPrice2,
		decimal? UnitPrice3,
		decimal? UnitPrice4,
		decimal? UnitPrice5,
		decimal? UnitPrice6,
		decimal? UnitCost,
		string CurItem,
		string CurCurrCode,
		DateTime? CurEffectDate,
		string DolPercent1,
		string DolPercent2,
		string DolPercent3,
		string DolPercent4,
		string DolPercent5,
		string BaseCode1,
		string BaseCode2,
		string BaseCode3,
		string BaseCode4,
		string BaseCode5,
		decimal? BrkQty1,
		decimal? BrkQty2,
		decimal? BrkQty3,
		decimal? BrkQty4,
		decimal? BrkQty5,
		decimal? BrkPrice1,
		decimal? BrkPrice2,
		decimal? BrkPrice3,
		decimal? BrkPrice4,
		decimal? BrkPrice5,
		decimal? DerUnitPrice1,
		decimal? DerUnitPrice2,
		decimal? DerUnitPrice3,
		decimal? DerUnitPrice4,
		decimal? DerUnitPrice5);
	}
}

