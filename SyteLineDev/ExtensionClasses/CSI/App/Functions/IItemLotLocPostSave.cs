//PROJECT NAME: Data
//CLASS NAME: IItemLotLocPostSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemLotLocPostSave
	{
		(int? ReturnCode,
			string Infobar) ItemLotLocPostSaveSp(
			string Item,
			string Whse,
			string Lot,
			string Loc,
			decimal? OldUnitCost,
			decimal? OldMatlCost,
			decimal? OldLbrCost,
			decimal? OldFovhdCost,
			decimal? OldVovhdCost,
			decimal? OldOutCost,
			decimal? UnitCost,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovhdCost,
			decimal? VovhdCost,
			decimal? OutCost,
			decimal? QtyOnHand,
			string Infobar);
	}
}

