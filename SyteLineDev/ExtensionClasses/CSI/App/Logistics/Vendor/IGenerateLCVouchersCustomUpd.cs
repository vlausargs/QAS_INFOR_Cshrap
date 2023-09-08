//PROJECT NAME: Logistics
//CLASS NAME: IGenerateLCVouchersCustomUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGenerateLCVouchersCustomUpd
	{
		int? GenerateLCVouchersCustomUpdSp(Guid? ProcessId,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string RefType,
		string LcType,
		DateTime? RcvdDate,
		string VendNum,
		decimal? DomAmtEstimate,
		decimal? AmtApplied,
		decimal? VchAmt,
		string GrnNum,
		int? RcptAmtOvrd,
		decimal? AmtFrnEst,
		int? DateSeq,
		decimal? UnitCost,
		decimal? DomUnitCost,
		decimal? QtyReceived);
	}
}

