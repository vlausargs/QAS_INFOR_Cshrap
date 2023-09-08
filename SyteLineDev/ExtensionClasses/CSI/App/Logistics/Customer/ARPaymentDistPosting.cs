//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentDistPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARPaymentDistPosting : IARPaymentDistPosting
	{
		readonly IApplicationDB appDB;
		
		
		public ARPaymentDistPosting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ARPaymentDistPostingSp(string CorpSite,
		string ReApplyType,
		string ReApplyBankCode,
		decimal? ReApplyDisc,
		decimal? WireExchangeRate,
		DateTime? TIssueDate,
		int? TInvSeq,
		string CorpSiteCurrCode,
		string CorpSiteName,
		Guid? ArpmtRowPointer,
		string ArpmtCustNum,
		string ArpmtBankCode,
		string ArpmtType,
		string ArpmtCreditMemoNum,
		int? ArpmtCheckNum,
		DateTime? ArpmtRecptDate,
		DateTime? ArpmtDueDate,
		string ArpmtRef,
		int? ArpmtNoteExistsFlag,
		string ArpmtDescription,
		int? ArpmtTransferCash,
		string ArpmtdInvNum,
		string ArpmtdSite,
		string ArpmtdApplyCustNum,
		decimal? ArpmtdExchRate,
		decimal? ArpmtdDomDiscAmt,
		decimal? ArpmtdForDiscAmt,
		decimal? ArpmtdDomAllowAmt,
		decimal? ArpmtdForAllowAmt,
		decimal? ArpmtdDomAmtApplied,
		decimal? ArpmtdForAmtApplied,
		string ArpmtdCoNum,
		string ArpmtdDoNum,
		string ArpmtdDiscAcct,
		string ArpmtdDiscAcctUnit1,
		string ArpmtdDiscAcctUnit2,
		string ArpmtdDiscAcctUnit3,
		string ArpmtdDiscAcctUnit4,
		string ArpmtdAllowAcct,
		string ArpmtdAllowAcctUnit1,
		string ArpmtdAllowAcctUnit2,
		string ArpmtdAllowAcctUnit3,
		string ArpmtdAllowAcctUnit4,
		string ArpmtdDepositAcct,
		string ArpmtdDepositAcctUnit1,
		string ArpmtdDepositAcctUnit2,
		string ArpmtdDepositAcctUnit3,
		string ArpmtdDepositAcctUnit4,
		string CorpCustaddrCurrCode,
		int? CorpCustaddrCorpCred,
		string CorpCustaddrCorpCust,
		int? UpdatePrepaidAmt,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber,
		string Infobar,
		decimal? ArpmtdForTaxAmt1,
		decimal? ArpmtdForTaxAmt2,
		decimal? ArpmtdDomTaxAmt1,
		decimal? ArpmtdDomTaxAmt2,
		int? ArpmtdFsSroDeposit = 0,
		string DepositDebitAcct = null,
		string DepositDebitUnit1 = null,
		string DepositDebitUnit2 = null,
		string DepositDebitUnit3 = null,
		string DepositDebitUnit4 = null,
		decimal? ArpmtdShipmentId = null,
		string TCoNum = null,
		int? TRma = 0,
		DateTime? OrigArpmtRecptDate = null,
		Guid? ArtranHoldNotesRowPointer = null,
        string ArpmtPaymentNumber = null,
        string ArpmtCurrCode = null)
		{
			SiteType _CorpSite = CorpSite;
			ArtranTypeType _ReApplyType = ReApplyType;
			BankCodeType _ReApplyBankCode = ReApplyBankCode;
			AmountType _ReApplyDisc = ReApplyDisc;
			ExchRateType _WireExchangeRate = WireExchangeRate;
			DateType _TIssueDate = TIssueDate;
			ArInvSeqType _TInvSeq = TInvSeq;
			CurrCodeType _CorpSiteCurrCode = CorpSiteCurrCode;
			NameType _CorpSiteName = CorpSiteName;
			RowPointerType _ArpmtRowPointer = ArpmtRowPointer;
			CustNumType _ArpmtCustNum = ArpmtCustNum;
			BankCodeType _ArpmtBankCode = ArpmtBankCode;
			ArpmtTypeType _ArpmtType = ArpmtType;
			InvNumType _ArpmtCreditMemoNum = ArpmtCreditMemoNum;
			ArCheckNumType _ArpmtCheckNum = ArpmtCheckNum;
			DateType _ArpmtRecptDate = ArpmtRecptDate;
			DateType _ArpmtDueDate = ArpmtDueDate;
			ReferenceType _ArpmtRef = ArpmtRef;
			ListYesNoType _ArpmtNoteExistsFlag = ArpmtNoteExistsFlag;
			DescriptionType _ArpmtDescription = ArpmtDescription;
			ListYesNoType _ArpmtTransferCash = ArpmtTransferCash;
			InvNumType _ArpmtdInvNum = ArpmtdInvNum;
			SiteType _ArpmtdSite = ArpmtdSite;
			CustNumType _ArpmtdApplyCustNum = ArpmtdApplyCustNum;
			ExchRateType _ArpmtdExchRate = ArpmtdExchRate;
			AmountType _ArpmtdDomDiscAmt = ArpmtdDomDiscAmt;
			AmountType _ArpmtdForDiscAmt = ArpmtdForDiscAmt;
			AmountType _ArpmtdDomAllowAmt = ArpmtdDomAllowAmt;
			AmountType _ArpmtdForAllowAmt = ArpmtdForAllowAmt;
			AmountType _ArpmtdDomAmtApplied = ArpmtdDomAmtApplied;
			AmountType _ArpmtdForAmtApplied = ArpmtdForAmtApplied;
			CoNumType _ArpmtdCoNum = ArpmtdCoNum;
			DoNumType _ArpmtdDoNum = ArpmtdDoNum;
			AcctType _ArpmtdDiscAcct = ArpmtdDiscAcct;
			UnitCode1Type _ArpmtdDiscAcctUnit1 = ArpmtdDiscAcctUnit1;
			UnitCode2Type _ArpmtdDiscAcctUnit2 = ArpmtdDiscAcctUnit2;
			UnitCode3Type _ArpmtdDiscAcctUnit3 = ArpmtdDiscAcctUnit3;
			UnitCode4Type _ArpmtdDiscAcctUnit4 = ArpmtdDiscAcctUnit4;
			AcctType _ArpmtdAllowAcct = ArpmtdAllowAcct;
			UnitCode1Type _ArpmtdAllowAcctUnit1 = ArpmtdAllowAcctUnit1;
			UnitCode2Type _ArpmtdAllowAcctUnit2 = ArpmtdAllowAcctUnit2;
			UnitCode3Type _ArpmtdAllowAcctUnit3 = ArpmtdAllowAcctUnit3;
			UnitCode4Type _ArpmtdAllowAcctUnit4 = ArpmtdAllowAcctUnit4;
			AcctType _ArpmtdDepositAcct = ArpmtdDepositAcct;
			UnitCode1Type _ArpmtdDepositAcctUnit1 = ArpmtdDepositAcctUnit1;
			UnitCode2Type _ArpmtdDepositAcctUnit2 = ArpmtdDepositAcctUnit2;
			UnitCode3Type _ArpmtdDepositAcctUnit3 = ArpmtdDepositAcctUnit3;
			UnitCode4Type _ArpmtdDepositAcctUnit4 = ArpmtdDepositAcctUnit4;
			CurrCodeType _CorpCustaddrCurrCode = CorpCustaddrCurrCode;
			ListYesNoType _CorpCustaddrCorpCred = CorpCustaddrCorpCred;
			CustNumType _CorpCustaddrCorpCust = CorpCustaddrCorpCust;
			ListYesNoType _UpdatePrepaidAmt = UpdatePrepaidAmt;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			Infobar _Infobar = Infobar;
			AmountType _ArpmtdForTaxAmt1 = ArpmtdForTaxAmt1;
			AmountType _ArpmtdForTaxAmt2 = ArpmtdForTaxAmt2;
			AmountType _ArpmtdDomTaxAmt1 = ArpmtdDomTaxAmt1;
			AmountType _ArpmtdDomTaxAmt2 = ArpmtdDomTaxAmt2;
			ListYesNoType _ArpmtdFsSroDeposit = ArpmtdFsSroDeposit;
			AcctType _DepositDebitAcct = DepositDebitAcct;
			UnitCode1Type _DepositDebitUnit1 = DepositDebitUnit1;
			UnitCode2Type _DepositDebitUnit2 = DepositDebitUnit2;
			UnitCode3Type _DepositDebitUnit3 = DepositDebitUnit3;
			UnitCode4Type _DepositDebitUnit4 = DepositDebitUnit4;
			ShipmentIDType _ArpmtdShipmentId = ArpmtdShipmentId;
			CoNumType _TCoNum = TCoNum;
			ListYesNoType _TRma = TRma;
			DateType _OrigArpmtRecptDate = OrigArpmtRecptDate;
			RowPointerType _ArtranHoldNotesRowPointer = ArtranHoldNotesRowPointer;
            PaymentNumberType _ArpmtPaymentNumber = ArpmtPaymentNumber;
            CurrCodeType _ArpmtCurrCode = ArpmtCurrCode;


            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPaymentDistPostingSp";
				
				appDB.AddCommandParameter(cmd, "CorpSite", _CorpSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReApplyType", _ReApplyType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReApplyBankCode", _ReApplyBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReApplyDisc", _ReApplyDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WireExchangeRate", _WireExchangeRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIssueDate", _TIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvSeq", _TInvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpSiteCurrCode", _CorpSiteCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpSiteName", _CorpSiteName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtRowPointer", _ArpmtRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCustNum", _ArpmtCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtBankCode", _ArpmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtType", _ArpmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCreditMemoNum", _ArpmtCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCheckNum", _ArpmtCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtRecptDate", _ArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtDueDate", _ArpmtDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtRef", _ArpmtRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtNoteExistsFlag", _ArpmtNoteExistsFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtDescription", _ArpmtDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtTransferCash", _ArpmtTransferCash, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdInvNum", _ArpmtdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdSite", _ArpmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdApplyCustNum", _ArpmtdApplyCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdExchRate", _ArpmtdExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDomDiscAmt", _ArpmtdDomDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdForDiscAmt", _ArpmtdForDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDomAllowAmt", _ArpmtdDomAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdForAllowAmt", _ArpmtdForAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDomAmtApplied", _ArpmtdDomAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdForAmtApplied", _ArpmtdForAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdCoNum", _ArpmtdCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDoNum", _ArpmtdDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDiscAcct", _ArpmtdDiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDiscAcctUnit1", _ArpmtdDiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDiscAcctUnit2", _ArpmtdDiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDiscAcctUnit3", _ArpmtdDiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDiscAcctUnit4", _ArpmtdDiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdAllowAcct", _ArpmtdAllowAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdAllowAcctUnit1", _ArpmtdAllowAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdAllowAcctUnit2", _ArpmtdAllowAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdAllowAcctUnit3", _ArpmtdAllowAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdAllowAcctUnit4", _ArpmtdAllowAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDepositAcct", _ArpmtdDepositAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDepositAcctUnit1", _ArpmtdDepositAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDepositAcctUnit2", _ArpmtdDepositAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDepositAcctUnit3", _ArpmtdDepositAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDepositAcctUnit4", _ArpmtdDepositAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCustaddrCurrCode", _CorpCustaddrCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCustaddrCorpCred", _CorpCustaddrCorpCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCustaddrCorpCust", _CorpCustaddrCorpCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdatePrepaidAmt", _UpdatePrepaidAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArpmtdForTaxAmt1", _ArpmtdForTaxAmt1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdForTaxAmt2", _ArpmtdForTaxAmt2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDomTaxAmt1", _ArpmtdDomTaxAmt1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdDomTaxAmt2", _ArpmtdDomTaxAmt2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdFsSroDeposit", _ArpmtdFsSroDeposit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitAcct", _DepositDebitAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitUnit1", _DepositDebitUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitUnit2", _DepositDebitUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitUnit3", _DepositDebitUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositDebitUnit4", _DepositDebitUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtdShipmentId", _ArpmtdShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoNum", _TCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRma", _TRma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigArpmtRecptDate", _OrigArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArtranHoldNotesRowPointer", _ArtranHoldNotesRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtPaymentNumber", _ArpmtPaymentNumber, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArpmtCurrCode", _ArpmtCurrCode, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
