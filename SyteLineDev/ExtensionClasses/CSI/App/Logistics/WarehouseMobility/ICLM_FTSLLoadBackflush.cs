//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLLoadBackflush.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLLoadBackflush
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLLoadBackflushSp(int? BackflushByLot,
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
		string ERPQueryJobMatResponseString = null,
		string ERPQueryJobSerResponseString = null,
		string Infobar = null);
	}
}

