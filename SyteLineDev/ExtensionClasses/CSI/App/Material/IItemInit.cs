//PROJECT NAME: Material
//CLASS NAME: IItemInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemInit
	{
		int? ItemInitSp(string PItem,
		string PRecordDate,
		decimal? PLastUnitCost,
		decimal? PAvgMatlCost,
		decimal? PAvgLbrCost,
		decimal? PAvgFovhdCost,
		decimal? PAvgVovhdCost,
		decimal? PAvgOutCost,
		decimal? PAvgUnitCost,
		int? PNextConfig,
		decimal? PUsedYTD,
		decimal? PMfgYTD);
	}
}

