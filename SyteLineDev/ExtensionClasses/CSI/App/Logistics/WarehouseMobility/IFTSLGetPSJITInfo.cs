//PROJECT NAME: Logistics
//CLASS NAME: IFTSLGetPSJITInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetPSJITInfo
	{
		(int? ReturnCode, string ItemDescription,
		string ItemUM,
		int? ItemLotTracked,
		int? ItemSerialTracked,
		string WcDescription,
		string Whse,
		string Loc,
		decimal? QtyExpected,
		decimal? QtyCompleted,
		decimal? QtyScrapped,
		string SymixJob,
		int? IsLastOper,
		decimal? QtyRemaining,
		DateTime? DueDate,
		int? SymixSuffix) FTSLGetPSJITInfoSp(string Item,
		string PsNum,
		string Wc,
		int? OperNum,
		string ItemDescription,
		string ItemUM,
		int? ItemLotTracked,
		int? ItemSerialTracked,
		string WcDescription,
		string Whse,
		string Loc,
		decimal? QtyExpected,
		decimal? QtyCompleted,
		decimal? QtyScrapped,
		string SymixJob = null,
		int? IsLastOper = 0,
		decimal? QtyRemaining = null,
		DateTime? DueDate = null,
		int? SymixSuffix = 0);
	}
}

