//PROJECT NAME: Data
//CLASS NAME: ITHAApSitPmtp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApSitPmtp
	{
		(int? ReturnCode,
			decimal? PCorpAmountPosted,
			int? PTTransDom,
			string Infobar) THAApSitPmtpSp(
			string PFromSite,
			string AppmtdApplyVendNum,
			string AppmtdSite,
			decimal? AppmtdDomAmtPaid,
			decimal? AppmtdDomAmtDisc,
			decimal? AppmtdForAmtPaid,
			decimal? AppmtdForAmtDisc,
			decimal? AppmtdExchRate,
			string AppmtdType,
			int? AppmtdVoucher,
			string AppmtdDiscAcct,
			string AppmtdDiscAcctUnit1,
			string AppmtdDiscAcctUnit2,
			string AppmtdDiscAcctUnit3,
			string AppmtdDiscAcctUnit4,
			string AppmtdInvNum,
			string AppmtdPoNum,
			string AppmtVendNum,
			string AppmtRef,
			DateTime? AppmtCheckDate,
			string AppmtBankCode,
			int? AppmtCheckNum,
			string AppmtTxt,
			string AppmtPayType,
			string BankHdrCurrCode,
			int? PJournalSeq,
			int? PCheckPosting,
			decimal? PWireExchangeRate,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			decimal? PCorpAmountPosted,
			int? PTTransDom,
			string Infobar,
			decimal? AppmtdForAmtTax1,
			decimal? AppmtdForAmtTax2,
			decimal? AppmtdDomAmtTax1,
			decimal? AppmtdDomAmtTax2,
			string PAppmtdTaxCode,
			Guid? PAppmtRowPointer = null);
	}
}

