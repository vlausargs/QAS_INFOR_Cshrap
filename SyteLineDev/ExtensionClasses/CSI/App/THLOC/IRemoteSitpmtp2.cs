//PROJECT NAME: THLOC
//CLASS NAME: IRemoteSitpmtp2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.THLOC
{
	public interface IRemoteSitpmtp2
	{
		int? RemoteSitpmtp2Sp(int? pTtVchpckVoucher,
		string pTtVchpckAptrxpType,
		string pTtVchpckDiscAcct,
		string pTtVchpckDiscAcctUnit1,
		string pTtVchpckDiscAcctUnit2,
		string pTtVchpckDiscAcctUnit3,
		string pTtVchpckDiscAcctUnit4,
		DateTime? pAppmtCheckDate,
		int? pAppmtCheckNum,
		string pAppmtBankCode,
		string pToVendNum,
		decimal? pTLoss,
		string pFromParmsSite,
		decimal? pDomesticAmtPaid,
		decimal? pDomesticAmtDisc,
		decimal? pForeignAmtPaid,
		decimal? pForeignAmtDisc,
		string pTAppmtRef,
		decimal? pVendorExchangeRate,
		string pBankHdrCurrCode,
		decimal? ptdombal,
		decimal? ptforbal,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber);
	}
}

