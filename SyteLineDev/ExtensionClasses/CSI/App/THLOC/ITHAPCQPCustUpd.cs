//PROJECT NAME: THLOC
//CLASS NAME: ITHAPCQPCustUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.THLOC
{
	public interface ITHAPCQPCustUpd
	{
		int? THAPCQPCustUpdSp(Guid? SessionId,
		int? DerSelected,
		string DerAptrxpTypeDesc,
		int? Voucher,
		string SiteRef,
		string VendNum,
		decimal? DerDomAmtPaid,
		DateTime? DueDate,
		string DerBankCode,
		int? DerCheckSeq,
		string DerApplyVendNum,
		int? CheckNum,
		decimal? ExchRate,
		Guid? DerAppmtRowPointer,
		decimal? DerForAmtPaid,
		decimal? DerDomAmtDisc,
		decimal? DerForAmtDisc,
		string DerDiscAcct,
		string DerDiscAcctUnit1,
		string DerDiscAcctUnit2,
		string DerDiscAcctUnit3,
		string DerDiscAcctUnit4,
		decimal? AmtPaid,
		decimal? AmtDisc,
		string PoNum,
		string GrnNum,
		string InvNum);
	}
}

