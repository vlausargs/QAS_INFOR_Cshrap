//PROJECT NAME: Logistics
//CLASS NAME: IArpmtdChgCoNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtdChgCoNum
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
		string Infobar,
		int? PArpmtdDiscIsControl) ArpmtdChgCoNumSp(string PArpmtdSite,
		string PArpmtdCoNum,
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
		int? PArpmtdDiscIsControl,
		string PArpmtBankCode = null,
		string PArpmtPaymentCurrCode = null,
		decimal? PArpmtPaymentExchRate = null);
	}
}

