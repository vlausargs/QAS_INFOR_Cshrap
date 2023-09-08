//PROJECT NAME: Material
//CLASS NAME: ICLM_LoadBackflush.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_LoadBackflush
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_LoadBackflushSp(int? BackflushByLot,
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
		int? NESTLEVEL = 0);
	}
}

