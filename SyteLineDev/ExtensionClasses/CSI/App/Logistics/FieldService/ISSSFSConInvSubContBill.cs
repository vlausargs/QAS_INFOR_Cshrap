//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubContBill.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubContBill
	{
		(int? ReturnCode,
			int? iOrigStartDay,
			DateTime? oBegDate,
			DateTime? oEndDate,
			decimal? oAmount,
			int? oFinished,
			string Infobar) SSSFSConInvSubContBillSp(
			DateTime? iBillingThruDate,
			string iContract,
			int? iContLine,
			int? iFirstTime,
			int? iPlaces,
			string iBillingFreq,
			string iUnitOfRate,
			string iProrateUnitOfRate,
			int? iRatePeriods,
			int? iOrigStartDay,
			DateTime? iActStartDate,
			DateTime? iActEndDate,
			DateTime? iActBilledThruDate,
			decimal? iRate,
			decimal? iProrateRate,
			decimal? iQty,
			DateTime? iBegDate,
			DateTime? oBegDate,
			DateTime? oEndDate,
			decimal? oAmount,
			int? oFinished,
			string Infobar);
	}
}

