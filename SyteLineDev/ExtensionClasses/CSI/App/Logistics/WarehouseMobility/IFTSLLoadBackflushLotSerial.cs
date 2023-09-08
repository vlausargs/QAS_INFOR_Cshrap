//PROJECT NAME: Logistics
//CLASS NAME: IFTSLLoadBackflushLotSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLLoadBackflushLotSerial
	{
		(int? ReturnCode,
			string Infobar,
			int? BflushNeeded) FTSLLoadBackflushLotSerialSp(
			int? BackflushByLot,
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
			int? BflushNeeded = 0);
	}
}

