//PROJECT NAME: Data
//CLASS NAME: IArSitpmtp2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArSitpmtp2
	{
		(int? ReturnCode,
			string Infobar) ArSitpmtp2Sp(
			string FromSite,
			string FromCurrCode,
			string FromArtranCurrCode,
			string FromArparmsArAcct,
			string FromArparmsArAcctUnit1,
			string FromArparmsArAcctUnit2,
			string FromArparmsArAcctUnit3,
			string FromArparmsArAcctUnit4,
			string FromArpmtCustNum,
			DateTime? FromArpmtRecptDate,
			string FromArpmtRef,
			string FromArpmtType,
			string FromArpmtBankCode,
			string FromArpmtDescription,
			DateTime? FromArpmtDueDate,
			int? FromArpmtCheckNum,
			decimal? FromArpmtExchRate,
			int? FromArpmtTransferCash,
			string FromBankHdrCurrCode,
			DateTime? FromArtranInvDate,
			DateTime? FromArtranDueDate,
			string TOPmtpckInvNum,
			decimal? TOPmtpckDomAmtApplied,
			decimal? TOPmtpckDomDiscAmt,
			decimal? TOPmtpckDomAllowAmt,
			decimal? TOPmtpckForAmtApplied,
			decimal? TOPmtpckForDiscAmt,
			decimal? TOPmtpckForAllowAmt,
			int? TOPmtpckInvSeq,
			int? TOPmtpckCheckSeq,
			decimal? TIPmtpckDomAmtApplied,
			decimal? TIPmtpckDomDiscAmt,
			decimal? TIPmtpckDomAllowAmt,
			decimal? TIPmtpckForAmtApplied,
			decimal? TIPmtpckForDiscAmt,
			decimal? TIPmtpckForAllowAmt,
			string TIPmtpckApplyCustNum,
			string TIPmtpckCustNum,
			string TIPmtpckBankCode,
			int? TIPmtpckCheckNum,
			string TIPmtpckCoNum,
			string TIPmtpckInvNum,
			string TIPmtpckSite,
			decimal? TIPmtpckExchRate,
			string TIPmtpckDiscAcct,
			string TIPmtpckDiscAcctUnit1,
			string TIPmtpckDiscAcctUnit2,
			string TIPmtpckDiscAcctUnit3,
			string TIPmtpckDiscAcctUnit4,
			string ReApplyType,
			string ReApplyBankCode,
			decimal? ReApplyDisc,
			decimal? WireExchangeRate,
			DateTime? TIssueDate,
			int? TInvSeq,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar,
			int? TIPmtpckRma = 0,
			string TIPmtpckCurrCode = null,
			string ArpmtPaymentNumber = null);
	}
}

