//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSArpmtdChgSroNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSArpmtdChgSroNum
	{
		(int? ReturnCode, string PArpmtdApplyCustNum,
		string PApplCustName,
		int? PFixedEuro,
		decimal? PArpmtdExchRate,
		int? PUpdateRate,
		decimal? PArpmtdForAmtApplied,
		decimal? PArpmtdForDiscAmt,
		decimal? PArpmtdDomAmtApplied,
		decimal? PArpmtdDomDiscAmt,
		string PArpmtdDiscAcct,
		string PArpmtdDiscAcctUnit1,
		string PArpmtdDiscAcctUnit2,
		string PArpmtdDiscAcctUnit3,
		string PArpmtdDiscAcctUnit4,
		string Infobar) SSSFSArpmtdChgSroNumSp(string PArpmtdSite,
		string PArpmtdSroNum,
		string PArpmtdInvNum,
		string PArpmtCustNum,
		string PDerCustCurrCode,
		int? PAddMode,
		int? PReApp,
		string POpenType,
		string PArpmtdType,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		decimal? PForAmtRem,
		string PArpmtdApplyCustNum,
		string PApplCustName,
		int? PFixedEuro,
		decimal? PArpmtdExchRate,
		int? PUpdateRate,
		decimal? PArpmtdForAmtApplied,
		decimal? PArpmtdForDiscAmt,
		decimal? PArpmtdDomAmtApplied,
		decimal? PArpmtdDomDiscAmt,
		string PArpmtdDiscAcct,
		string PArpmtdDiscAcctUnit1,
		string PArpmtdDiscAcctUnit2,
		string PArpmtdDiscAcctUnit3,
		string PArpmtdDiscAcctUnit4,
		string Infobar,
		string PArpmtBankCode,
		string PArpmtPaymentCurrCode,
		decimal? PArpmtPaymentExchRate);
	}
}

