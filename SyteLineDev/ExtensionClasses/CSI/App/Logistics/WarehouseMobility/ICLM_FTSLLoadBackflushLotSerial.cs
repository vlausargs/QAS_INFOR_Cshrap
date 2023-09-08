//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLLoadBackflushLotSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLLoadBackflushLotSerial
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar,
		int? BflushNeeded) CLM_FTSLLoadBackflushLotSerialSp(int? BackflushByLot,
		string TransClass,
		decimal? TransNum,
		string Job,
		int? Suffix,
		int? OperNum,
		string JobItem,
		decimal? PhantomMulti,
		string PhantomUnits,
		decimal? PhantomScrap,
		DateTime? TransDate,
		string Whse,
		string Lot,
		decimal? RouteQtyComplete,
		decimal? RouteQtyScrapped,
		string EmpNum,
		string Infobar,
		int? BflushNeeded = 0,
		int? ReverseQty = 0,
		int? FDALotTraceability = 0);
	}
}

