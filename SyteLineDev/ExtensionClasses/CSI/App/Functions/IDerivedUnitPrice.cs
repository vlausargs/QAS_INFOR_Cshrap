//PROJECT NAME: Data
//CLASS NAME: IDerivedUnitPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDerivedUnitPrice
	{
		decimal? DerivedUnitPriceFn(
			string DolPercent,
			decimal? CurrRate,
			decimal? ConvertedRate,
			string BaseCode,
			decimal? BrkPrice,
			decimal? UnitPrice1,
			decimal? UnitPrice2,
			decimal? UnitPrice3,
			decimal? UnitPrice4,
			decimal? UnitPrice5,
			decimal? UnitPrice6,
			decimal? UnitCost,
			int? RateIsDivisor,
			decimal? BrkQty);
	}
}

