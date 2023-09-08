//PROJECT NAME: Logistics
//CLASS NAME: IArpmtdChgArpmtdType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtdChgArpmtdType
	{
		(int? ReturnCode, string PArpmtdInvNum,
		decimal? PArpmtdExchRate,
		int? PUpdateRate,
		string PArpmtdDepositAcct,
		string PArpmtdDepositAcctUnit1,
		string PArpmtdDepositAcctUnit2,
		string PArpmtdDepositAcctUnit3,
		string PArpmtdDepositAcctUnit4,
		decimal? PArpmtdForAmtApplied,
		decimal? PArpmtdDomAmtApplied,
		string Infobar,
		int? PArpmtdDepositIsControl) ArpmtdChgArpmtdTypeSp(string PArpmtCustNum,
		int? PArpmtCheckNum,
		string PArpmtCreditMemoNum,
		string PArpmtdType,
		string PArpmtBankCode,
		string PArpmtdSite,
		int? PAddMode,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		string PCustCurrCode,
		int? PReApp,
		string POpenType,
		decimal? PDerPayAmtRem,
		decimal? PDerForAmtRem,
		decimal? PDerDomAmtRem,
		string PArpmtdInvNum,
		decimal? PArpmtdExchRate,
		int? PUpdateRate,
		string PArpmtdDepositAcct,
		string PArpmtdDepositAcctUnit1,
		string PArpmtdDepositAcctUnit2,
		string PArpmtdDepositAcctUnit3,
		string PArpmtdDepositAcctUnit4,
		decimal? PArpmtdForAmtApplied,
		decimal? PArpmtdDomAmtApplied,
		string Infobar,
		int? PArpmtdDepositIsControl,
		string PArpmtPaymentCurrCode = null,
		decimal? PArpmtPaymentExchRate = null);
	}
}

