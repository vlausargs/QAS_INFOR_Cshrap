//PROJECT NAME: Logistics
//CLASS NAME: IFTSLCheckBackflushNeeded.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLCheckBackflushNeeded
	{
		(int? ReturnCode, string Infobar,
		int? BflushLotNeeded,
		int? BflushSerialNeeded) FTSLCheckBackflushNeededSp(int? BackflushByLot,
		string TransClass = "J",
		decimal? TransNum = null,
		string Job = null,
		int? Suffix = null,
		int? OperNum = null,
		string JobItem = null,
		decimal? PhantomMulti = null,
		string PhantomUnits = null,
		decimal? PhantomScrap = null,
		DateTime? TransDate = null,
		string Whse = null,
		string Lot = null,
		decimal? RouteQtyComplete = null,
		decimal? RouteQtyScrapped = null,
		string EmpNum = null,
		string Infobar = null,
		int? BflushLotNeeded = null,
		int? BflushSerialNeeded = null);
	}
}

