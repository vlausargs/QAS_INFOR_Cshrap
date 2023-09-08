//PROJECT NAME: Data
//CLASS NAME: IPriceCalReorderVariables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPriceCalReorderVariables
	{
		(int? ReturnCode,
			decimal? BrkQty1,
			decimal? BrkQty2,
			decimal? BrkQty3,
			decimal? BrkQty4,
			decimal? BrkQty5,
			decimal? BrkQty6,
			decimal? UnitPrice1,
			decimal? UnitPrice2,
			decimal? UnitPrice3,
			decimal? UnitPrice4,
			decimal? UnitPrice5,
			decimal? UnitPrice6) PriceCalReorderVariablesSP(
			decimal? BrkQty1,
			decimal? BrkQty2,
			decimal? BrkQty3,
			decimal? BrkQty4,
			decimal? BrkQty5,
			decimal? BrkQty6,
			decimal? UnitPrice1,
			decimal? UnitPrice2,
			decimal? UnitPrice3,
			decimal? UnitPrice4,
			decimal? UnitPrice5,
			decimal? UnitPrice6);
	}
}

