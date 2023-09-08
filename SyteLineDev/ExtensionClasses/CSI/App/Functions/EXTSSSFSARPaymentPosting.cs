//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSARPaymentPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSARPaymentPosting : IEXTSSSFSARPaymentPosting
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSARPaymentPosting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? SkipDist,
			string Infobar) EXTSSSFSARPaymentPostingSp(
			string CorpSite,
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
			Guid? ArpmtdRowPointer,
			string TAcct,
			string TUnit1,
			string TUnit2,
			string TUnit3,
			string TUnit4,
			int? SkipDist,
			string Infobar,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null)
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
			FlagNyType _ArpmtNoteExistsFlag = ArpmtNoteExistsFlag;
			DescriptionType _ArpmtDescription = ArpmtDescription;
			ListYesNoType _ArpmtTransferCash = ArpmtTransferCash;
			RowPointerType _ArpmtdRowPointer = ArpmtdRowPointer;
			AcctType _TAcct = TAcct;
			UnitCode1Type _TUnit1 = TUnit1;
			UnitCode2Type _TUnit2 = TUnit2;
			UnitCode3Type _TUnit3 = TUnit3;
			UnitCode4Type _TUnit4 = TUnit4;
			ListYesNoType _SkipDist = SkipDist;
			InfobarType _Infobar = Infobar;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSARPaymentPostingSp";
				
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
				appDB.AddCommandParameter(cmd, "ArpmtdRowPointer", _ArpmtdRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAcct", _TAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUnit1", _TUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUnit2", _TUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUnit3", _TUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUnit4", _TUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipDist", _SkipDist, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SkipDist = _SkipDist;
				Infobar = _Infobar;
				
				return (Severity, SkipDist, Infobar);
			}
		}
	}
}
