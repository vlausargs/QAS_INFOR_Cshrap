//PROJECT NAME: Data
//CLASS NAME: THAApSitPmtp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAApSitPmtp : ITHAApSitPmtp
	{
		readonly IApplicationDB appDB;
		
		public THAApSitPmtp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			Guid? PAppmtRowPointer = null)
		{
			SiteType _PFromSite = PFromSite;
			VendNumType _AppmtdApplyVendNum = AppmtdApplyVendNum;
			SiteType _AppmtdSite = AppmtdSite;
			AmountType _AppmtdDomAmtPaid = AppmtdDomAmtPaid;
			AmountType _AppmtdDomAmtDisc = AppmtdDomAmtDisc;
			AmountType _AppmtdForAmtPaid = AppmtdForAmtPaid;
			AmountType _AppmtdForAmtDisc = AppmtdForAmtDisc;
			ExchRateType _AppmtdExchRate = AppmtdExchRate;
			AppmtdTypeType _AppmtdType = AppmtdType;
			VoucherType _AppmtdVoucher = AppmtdVoucher;
			AcctType _AppmtdDiscAcct = AppmtdDiscAcct;
			UnitCode1Type _AppmtdDiscAcctUnit1 = AppmtdDiscAcctUnit1;
			UnitCode2Type _AppmtdDiscAcctUnit2 = AppmtdDiscAcctUnit2;
			UnitCode3Type _AppmtdDiscAcctUnit3 = AppmtdDiscAcctUnit3;
			UnitCode4Type _AppmtdDiscAcctUnit4 = AppmtdDiscAcctUnit4;
			VendInvNumType _AppmtdInvNum = AppmtdInvNum;
			PoNumType _AppmtdPoNum = AppmtdPoNum;
			VendNumType _AppmtVendNum = AppmtVendNum;
			ReferenceType _AppmtRef = AppmtRef;
			DateType _AppmtCheckDate = AppmtCheckDate;
			BankCodeType _AppmtBankCode = AppmtBankCode;
			ApCheckNumType _AppmtCheckNum = AppmtCheckNum;
			DescriptionType _AppmtTxt = AppmtTxt;
			AppmtPayTypeType _AppmtPayType = AppmtPayType;
			CurrCodeType _BankHdrCurrCode = BankHdrCurrCode;
			JournalSeqType _PJournalSeq = PJournalSeq;
			FlagNyType _PCheckPosting = PCheckPosting;
			ExchRateType _PWireExchangeRate = PWireExchangeRate;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			GenericDecimalType _PCorpAmountPosted = PCorpAmountPosted;
			FlagNyType _PTTransDom = PTTransDom;
			InfobarType _Infobar = Infobar;
			AmountType _AppmtdForAmtTax1 = AppmtdForAmtTax1;
			AmountType _AppmtdForAmtTax2 = AppmtdForAmtTax2;
			AmountType _AppmtdDomAmtTax1 = AppmtdDomAmtTax1;
			AmountType _AppmtdDomAmtTax2 = AppmtdDomAmtTax2;
			TaxCodeType _PAppmtdTaxCode = PAppmtdTaxCode;
			RowPointerType _PAppmtRowPointer = PAppmtRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAApSitPmtpSp";
				
				appDB.AddCommandParameter(cmd, "PFromSite", _PFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdApplyVendNum", _AppmtdApplyVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdSite", _AppmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdDomAmtPaid", _AppmtdDomAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdDomAmtDisc", _AppmtdDomAmtDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdForAmtPaid", _AppmtdForAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdForAmtDisc", _AppmtdForAmtDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdExchRate", _AppmtdExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdType", _AppmtdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdVoucher", _AppmtdVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdDiscAcct", _AppmtdDiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdDiscAcctUnit1", _AppmtdDiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdDiscAcctUnit2", _AppmtdDiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdDiscAcctUnit3", _AppmtdDiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdDiscAcctUnit4", _AppmtdDiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdInvNum", _AppmtdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdPoNum", _AppmtdPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtVendNum", _AppmtVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtRef", _AppmtRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtCheckDate", _AppmtCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtBankCode", _AppmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtCheckNum", _AppmtCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtTxt", _AppmtTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtPayType", _AppmtPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankHdrCurrCode", _BankHdrCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJournalSeq", _PJournalSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckPosting", _PCheckPosting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWireExchangeRate", _PWireExchangeRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCorpAmountPosted", _PCorpAmountPosted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTTransDom", _PTTransDom, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AppmtdForAmtTax1", _AppmtdForAmtTax1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdForAmtTax2", _AppmtdForAmtTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdDomAmtTax1", _AppmtdDomAmtTax1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtdDomAmtTax2", _AppmtdDomAmtTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAppmtdTaxCode", _PAppmtdTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAppmtRowPointer", _PAppmtRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCorpAmountPosted = _PCorpAmountPosted;
				PTTransDom = _PTTransDom;
				Infobar = _Infobar;
				
				return (Severity, PCorpAmountPosted, PTTransDom, Infobar);
			}
		}
	}
}
