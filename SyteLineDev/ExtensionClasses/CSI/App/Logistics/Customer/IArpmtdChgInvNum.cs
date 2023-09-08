//PROJECT NAME: Logistics
//CLASS NAME: IArpmtdChgInvNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtdChgInvNum
	{
		(int? ReturnCode, string PDerTransctionCurrCode,
		string PArpmtdApplyCustNum,
		string PApplCustName,
		int? PFixedEuro,
		string PArpmtdCoNum,
		string PArpmtdDoNum,
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
		decimal? DfltTax1Val,
		decimal? DfltTax2Val,
		decimal? PArpmtdShipmentId,
		int? PArpmtdDiscIsControl,
		int? PFixedRate,
		string Infobar) ArpmtdChgInvNumSp(string PArpmtdSite,
		string PArpmtdInvNum,
		string PArpmtCustNum,
		string PBankCurrCode,
		string PDerTransctionCurrCode,
		int? PAddMode,
		int? PReApp,
		string POpenType,
		string PArpmtdType,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		decimal? PForAmtRem,
		decimal? PAllowAmt,
		string PArpmtdApplyCustNum,
		string PApplCustName,
		int? PFixedEuro,
		string PArpmtdCoNum,
		string PArpmtdDoNum,
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
		decimal? DfltTax1Val,
		decimal? DfltTax1Var,
		decimal? DfltTax2Val,
		decimal? DfltTax2Var,
		decimal? PArpmtdShipmentId,
		int? PArpmtdDiscIsControl,
		string Infobar,
		string PArpmtBankCode = null,
		string PArpmtPaymentCurrCode = null,
		decimal? PArpmtPaymentExchRate = null,
		int? PFixedRate = null);
	}
}

