//PROJECT NAME: Data
//CLASS NAME: IResetUc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IResetUc
	{
		(int? ReturnCode,
			string Infobar) ResetUcSp(
			string Item,
			string Whse,
			string Lot,
			string Loc,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovhdCost,
			decimal? VovhdCost,
			decimal? OutCost,
			decimal? Qty,
			decimal? UnitCost,
			int? ProcessLotLocUnitCost = 1,
			string Infobar = null);
	}
}

