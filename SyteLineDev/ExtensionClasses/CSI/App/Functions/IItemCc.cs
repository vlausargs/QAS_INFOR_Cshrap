//PROJECT NAME: Data
//CLASS NAME: IItemCc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemCc
	{
		(int? ReturnCode,
			decimal? NewUnitCost,
			decimal? NewMatlCost,
			decimal? NewLbrCost,
			decimal? NewFovhdCost,
			decimal? NewVovhdCost,
			decimal? NewOutCost,
			decimal? NewAvgUCost,
			decimal? NewAvgMatlCost,
			decimal? NewAvgLbrCost,
			decimal? NewAvgFovhdCost,
			decimal? NewAvgVovhdCost,
			decimal? NewAvgOutCost,
			string Infobar) ItemCcSp(
			int? LotTracked,
			int? AddMode,
			Guid? ItemRowPointer,
			string OldCostMethod,
			string OldCostType,
			decimal? OldUnitCost,
			decimal? OldMatlCost,
			decimal? OldLbrCost,
			decimal? OldFovhdCost,
			decimal? OldVovhdCost,
			decimal? OldOutCost,
			string NewCostMethod,
			string NewCostType,
			decimal? NewUnitCost,
			decimal? NewMatlCost,
			decimal? NewLbrCost,
			decimal? NewFovhdCost,
			decimal? NewVovhdCost,
			decimal? NewOutCost,
			decimal? NewAvgUCost,
			decimal? NewAvgMatlCost,
			decimal? NewAvgLbrCost,
			decimal? NewAvgFovhdCost,
			decimal? NewAvgVovhdCost,
			decimal? NewAvgOutCost,
			string Infobar,
			string Whse);
	}
}

