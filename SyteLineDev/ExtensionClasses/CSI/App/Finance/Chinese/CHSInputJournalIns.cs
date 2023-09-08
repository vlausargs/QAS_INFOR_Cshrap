//PROJECT NAME: Finance
//CLASS NAME: CHSInputJournalIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSInputJournalIns : ICHSInputJournalIns
	{
		readonly IApplicationDB appDB;
		
		
		public CHSInputJournalIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CHSInputJournalInsSp(decimal? TransNum,
		string Acct,
		DateTime? TransDate,
		decimal? DomAmt,
		string Ref,
		string VendNum,
		string Voucher,
		int? CheckNum,
		DateTime? CheckDate,
		string FromSite,
		string FromId,
		decimal? VouchSeq,
		string RefType,
		decimal? MatlTransNum,
		decimal? DTransNum,
		string BankCode,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string CurrCode,
		decimal? ExchRate,
		decimal? ForAmount,
		string Site,
		string Hierarchy,
		string Consolidated,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber,
		int? Year,
		int? Period,
		string CHVouNum,
		int? Line,
		Guid? SessionId,
		string Infobar)
		{
			LastTranType _TransNum = TransNum;
			AcctType _Acct = Acct;
			DateType _TransDate = TransDate;
			AmountType _DomAmt = DomAmt;
			ReferenceType _Ref = Ref;
			VendNumType _VendNum = VendNum;
			InvNumVoucherType _Voucher = Voucher;
			GenericIntType _CheckNum = CheckNum;
			DateType _CheckDate = CheckDate;
			SiteType _FromSite = FromSite;
			RptIdType _FromId = FromId;
			SequenceType _VouchSeq = VouchSeq;
			ConfigStatusType _RefType = RefType;
			LastTranType _MatlTransNum = MatlTransNum;
			LastTranType _DTransNum = DTransNum;
			BankCodeType _BankCode = BankCode;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			CurrCodeType _CurrCode = CurrCode;
			ExchRateType _ExchRate = ExchRate;
			AmountType _ForAmount = ForAmount;
			SiteType _Site = Site;
			DescriptionType _Hierarchy = Hierarchy;
			ConfigStatusType _Consolidated = Consolidated;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			FiscalYearType _Year = Year;
			FinPeriodType _Period = Period;
			GenericMedCodeType _CHVouNum = CHVouNum;
			GenericIntType _Line = Line;
			RowPointerType _SessionId = SessionId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSInputJournalInsSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAmt", _DomAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref", _Ref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromId", _FromId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VouchSeq", _VouchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlTransNum", _MatlTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DTransNum", _DTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmount", _ForAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Hierarchy", _Hierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Consolidated", _Consolidated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Year", _Year, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CHVouNum", _CHVouNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Line", _Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
