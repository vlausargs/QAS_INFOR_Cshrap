//PROJECT NAME: Data
//CLASS NAME: ArSitpmtp2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArSitpmtp2 : IArSitpmtp2
	{
		readonly IApplicationDB appDB;
		
		public ArSitpmtp2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string ArpmtPaymentNumber = null)
		{
			SiteType _FromSite = FromSite;
			CurrCodeType _FromCurrCode = FromCurrCode;
			CurrCodeType _FromArtranCurrCode = FromArtranCurrCode;
			AcctType _FromArparmsArAcct = FromArparmsArAcct;
			UnitCode1Type _FromArparmsArAcctUnit1 = FromArparmsArAcctUnit1;
			UnitCode2Type _FromArparmsArAcctUnit2 = FromArparmsArAcctUnit2;
			UnitCode3Type _FromArparmsArAcctUnit3 = FromArparmsArAcctUnit3;
			UnitCode4Type _FromArparmsArAcctUnit4 = FromArparmsArAcctUnit4;
			CustNumType _FromArpmtCustNum = FromArpmtCustNum;
			DateType _FromArpmtRecptDate = FromArpmtRecptDate;
			ReferenceType _FromArpmtRef = FromArpmtRef;
			ArpmtTypeType _FromArpmtType = FromArpmtType;
			BankCodeType _FromArpmtBankCode = FromArpmtBankCode;
			DescriptionType _FromArpmtDescription = FromArpmtDescription;
			DateType _FromArpmtDueDate = FromArpmtDueDate;
			ArCheckNumType _FromArpmtCheckNum = FromArpmtCheckNum;
			ExchRateType _FromArpmtExchRate = FromArpmtExchRate;
			ListYesNoType _FromArpmtTransferCash = FromArpmtTransferCash;
			CurrCodeType _FromBankHdrCurrCode = FromBankHdrCurrCode;
			DateType _FromArtranInvDate = FromArtranInvDate;
			DateType _FromArtranDueDate = FromArtranDueDate;
			InvNumType _TOPmtpckInvNum = TOPmtpckInvNum;
			AmountType _TOPmtpckDomAmtApplied = TOPmtpckDomAmtApplied;
			AmountType _TOPmtpckDomDiscAmt = TOPmtpckDomDiscAmt;
			AmountType _TOPmtpckDomAllowAmt = TOPmtpckDomAllowAmt;
			AmountType _TOPmtpckForAmtApplied = TOPmtpckForAmtApplied;
			AmountType _TOPmtpckForDiscAmt = TOPmtpckForDiscAmt;
			AmountType _TOPmtpckForAllowAmt = TOPmtpckForAllowAmt;
			ArInvSeqType _TOPmtpckInvSeq = TOPmtpckInvSeq;
			ArCheckNumType _TOPmtpckCheckSeq = TOPmtpckCheckSeq;
			AmountType _TIPmtpckDomAmtApplied = TIPmtpckDomAmtApplied;
			AmountType _TIPmtpckDomDiscAmt = TIPmtpckDomDiscAmt;
			AmountType _TIPmtpckDomAllowAmt = TIPmtpckDomAllowAmt;
			AmountType _TIPmtpckForAmtApplied = TIPmtpckForAmtApplied;
			AmountType _TIPmtpckForDiscAmt = TIPmtpckForDiscAmt;
			AmountType _TIPmtpckForAllowAmt = TIPmtpckForAllowAmt;
			CustNumType _TIPmtpckApplyCustNum = TIPmtpckApplyCustNum;
			CustNumType _TIPmtpckCustNum = TIPmtpckCustNum;
			BankCodeType _TIPmtpckBankCode = TIPmtpckBankCode;
			ArCheckNumType _TIPmtpckCheckNum = TIPmtpckCheckNum;
			CoNumType _TIPmtpckCoNum = TIPmtpckCoNum;
			InvNumType _TIPmtpckInvNum = TIPmtpckInvNum;
			SiteType _TIPmtpckSite = TIPmtpckSite;
			ExchRateType _TIPmtpckExchRate = TIPmtpckExchRate;
			AcctType _TIPmtpckDiscAcct = TIPmtpckDiscAcct;
			UnitCode1Type _TIPmtpckDiscAcctUnit1 = TIPmtpckDiscAcctUnit1;
			UnitCode2Type _TIPmtpckDiscAcctUnit2 = TIPmtpckDiscAcctUnit2;
			UnitCode3Type _TIPmtpckDiscAcctUnit3 = TIPmtpckDiscAcctUnit3;
			UnitCode4Type _TIPmtpckDiscAcctUnit4 = TIPmtpckDiscAcctUnit4;
			ArtranTypeType _ReApplyType = ReApplyType;
			BankCodeType _ReApplyBankCode = ReApplyBankCode;
			GenericDecimalType _ReApplyDisc = ReApplyDisc;
			ExchRateType _WireExchangeRate = WireExchangeRate;
			DateType _TIssueDate = TIssueDate;
			ArInvSeqType _TInvSeq = TInvSeq;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _Infobar = Infobar;
			ListYesNoType _TIPmtpckRma = TIPmtpckRma;
			CurrCodeType _TIPmtpckCurrCode = TIPmtpckCurrCode;
			PaymentNumberType _ArpmtPaymentNumber = ArpmtPaymentNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArSitpmtp2Sp";
				
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArtranCurrCode", _FromArtranCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArparmsArAcct", _FromArparmsArAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArparmsArAcctUnit1", _FromArparmsArAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArparmsArAcctUnit2", _FromArparmsArAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArparmsArAcctUnit3", _FromArparmsArAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArparmsArAcctUnit4", _FromArparmsArAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtCustNum", _FromArpmtCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtRecptDate", _FromArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtRef", _FromArpmtRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtType", _FromArpmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtBankCode", _FromArpmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtDescription", _FromArpmtDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtDueDate", _FromArpmtDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtCheckNum", _FromArpmtCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtExchRate", _FromArpmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArpmtTransferCash", _FromArpmtTransferCash, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromBankHdrCurrCode", _FromBankHdrCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArtranInvDate", _FromArtranInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromArtranDueDate", _FromArtranDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOPmtpckInvNum", _TOPmtpckInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOPmtpckDomAmtApplied", _TOPmtpckDomAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOPmtpckDomDiscAmt", _TOPmtpckDomDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOPmtpckDomAllowAmt", _TOPmtpckDomAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOPmtpckForAmtApplied", _TOPmtpckForAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOPmtpckForDiscAmt", _TOPmtpckForDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOPmtpckForAllowAmt", _TOPmtpckForAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOPmtpckInvSeq", _TOPmtpckInvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOPmtpckCheckSeq", _TOPmtpckCheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckDomAmtApplied", _TIPmtpckDomAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckDomDiscAmt", _TIPmtpckDomDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckDomAllowAmt", _TIPmtpckDomAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckForAmtApplied", _TIPmtpckForAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckForDiscAmt", _TIPmtpckForDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckForAllowAmt", _TIPmtpckForAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckApplyCustNum", _TIPmtpckApplyCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckCustNum", _TIPmtpckCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckBankCode", _TIPmtpckBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckCheckNum", _TIPmtpckCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckCoNum", _TIPmtpckCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckInvNum", _TIPmtpckInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckSite", _TIPmtpckSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckExchRate", _TIPmtpckExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckDiscAcct", _TIPmtpckDiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckDiscAcctUnit1", _TIPmtpckDiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckDiscAcctUnit2", _TIPmtpckDiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckDiscAcctUnit3", _TIPmtpckDiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckDiscAcctUnit4", _TIPmtpckDiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReApplyType", _ReApplyType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReApplyBankCode", _ReApplyBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReApplyDisc", _ReApplyDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WireExchangeRate", _WireExchangeRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIssueDate", _TIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvSeq", _TInvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TIPmtpckRma", _TIPmtpckRma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIPmtpckCurrCode", _TIPmtpckCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtPaymentNumber", _ArpmtPaymentNumber, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
