//PROJECT NAME: Production
//CLASS NAME: IApSitPmtp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApSitPmtp
	{
		(int? ReturnCode,
			decimal? PCorpAmountPosted,
			int? PTTransDom,
			string Infobar,
			decimal? PTcAmtCr,
			decimal? PTcDomesticAmtCr) ApSitPmtpSp(
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
			Guid? PAppmtRowPointer = null,
			int? Misc1099Reportable = 0,
			int? AppmtFactor = 0,
			string PAppmtdTaxCode = null,
			Guid? AppmtdRowPointer = null,
			string AppmtTHPaymentNumber = null,
			int? IsBuffer = 0,
			decimal? PTcAmtCr = null,
			decimal? PTcDomesticAmtCr = null);
	}
}

