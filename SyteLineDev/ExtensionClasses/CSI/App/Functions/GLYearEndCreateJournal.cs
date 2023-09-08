//PROJECT NAME: Data
//CLASS NAME: GLYearEndCreateJournal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GLYearEndCreateJournal : IGLYearEndCreateJournal
	{
		readonly IApplicationDB appDB;
		
		public GLYearEndCreateJournal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Summary,
			decimal? JournalDomAmount,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar) GLYearEndCreateJournalSp(
			string CurId,
			DateTime? FiscalYearBegDate,
			DateTime? FiscalYearEndDate,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PSortFields,
			int? PSortMethod,
			string ChartAcct,
			string ChartType,
			string CurrCode,
			string Site,
			decimal? Summary,
			decimal? JournalDomAmount,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar)
		{
			AcctType _CurId = CurId;
			DateType _FiscalYearBegDate = FiscalYearBegDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			StringType _PSortFields = PSortFields;
			SortMethodType _PSortMethod = PSortMethod;
			AcctType _ChartAcct = ChartAcct;
			ChartTypeType _ChartType = ChartType;
			CurrCodeType _CurrCode = CurrCode;
			SiteType _Site = Site;
			AmountType _Summary = Summary;
			AmountType _JournalDomAmount = JournalDomAmount;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GLYearEndCreateJournalSp";
				
				appDB.AddCommandParameter(cmd, "CurId", _CurId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYearBegDate", _FiscalYearBegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYearEndDate", _FiscalYearEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortFields", _PSortFields, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortMethod", _PSortMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartAcct", _ChartAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChartType", _ChartType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Summary", _Summary, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JournalDomAmount", _JournalDomAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Summary = _Summary;
				JournalDomAmount = _JournalDomAmount;
				ControlPrefix = _ControlPrefix;
				ControlSite = _ControlSite;
				ControlYear = _ControlYear;
				ControlPeriod = _ControlPeriod;
				ControlNumber = _ControlNumber;
				Infobar = _Infobar;
				
				return (Severity, Summary, JournalDomAmount, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, Infobar);
			}
		}
	}
}
