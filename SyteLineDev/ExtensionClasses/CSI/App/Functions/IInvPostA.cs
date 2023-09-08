//PROJECT NAME: Data
//CLASS NAME: IInvPostA.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvPostA
	{
		(int? ReturnCode,
			string PInvNum,
			int? PPrintFlag,
			int? TAcctError,
			string Infobar) InvPostASp(
			string PRecIdCo,
			decimal? PMiscCharges,
			decimal? PSalesTax,
			decimal? PFreight,
			string PDest,
			string PInvOrCm,
			int? PNonDraftCust,
			int? PProgBillText,
			string PLineRelText,
			int? PPlanItemMtls,
			int? PLCR,
			int? PSerNums,
			string PConfDets,
			int? PPRTVals,
			int? POrdNums,
			int? PTransToDomCur,
			int? PEuroTotal,
			string PInvNum,
			DateTime? PInvDate,
			string PCustNumStart,
			string PCustNumEnd,
			string PCoNumStart,
			string PCoNumEnd,
			DateTime? PLastShipDateStart,
			DateTime? PLastShipDateEnd,
			string PDoNumStart,
			string PDoNumEnd,
			string PCustPOStart,
			string PCustPOEnd,
			string PInvNumRepStart,
			string PInvNumRepEnd,
			DateTime? PInvDateRepStart,
			DateTime? PInvDateRepEnd,
			int? PItemTypeItem,
			int? PItemTypeCust,
			int? PTextOrd,
			int? PTextStandOrd,
			int? PTextCustMast,
			int? PTextBillTo,
			int? PTextNone,
			string TOpt,
			int? TDispFLine,
			int? TDispFInv,
			string TCustPT,
			string TInvStart,
			string TInvEnd,
			int? PPrintFlag,
			int? TAcctError,
			string Infobar,
			Guid? pProcessId = null,
			string PApplyToInvNum = null);
	}
}

