//PROJECT NAME: Finance
//CLASS NAME: MultiFSBYearEndCreateJournal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBYearEndCreateJournal : IMultiFSBYearEndCreateJournal
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBYearEndCreateJournal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Summary,
			decimal? JournalDomAmount,
			string Infobar) MultiFSBYearEndCreateJournalSp(
			string FSBName,
			string PeriodName = null,
			string CurId = "General",
			DateTime? FiscalYearBegDate = null,
			DateTime? FiscalYearEndDate = null,
			string PAcctUnit1 = null,
			string PAcctUnit2 = null,
			string PAcctUnit3 = null,
			string PAcctUnit4 = null,
			string PSortFields = null,
			int? PSortMethod = null,
			string ChartAcct = null,
			string ChartType = null,
			string CurrCode = null,
			string Site = null,
			decimal? Summary = null,
			decimal? JournalDomAmount = null,
			string Infobar = null)
		{
			FSBNameType _FSBName = FSBName;
			FSBPeriodNameType _PeriodName = PeriodName;
			JournalIdType _CurId = CurId;
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
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBYearEndCreateJournalSp";
				
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Summary = _Summary;
				JournalDomAmount = _JournalDomAmount;
				Infobar = _Infobar;
				
				return (Severity, Summary, JournalDomAmount, Infobar);
			}
		}
	}
}
