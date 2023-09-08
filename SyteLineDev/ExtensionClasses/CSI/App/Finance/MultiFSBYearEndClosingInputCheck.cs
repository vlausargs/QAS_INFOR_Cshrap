//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBYearEndClosingInputCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBYearEndClosingInputCheck
	{
		(int? ReturnCode, string Infobar) MultiFSBYearEndClosingInputCheckSp(string FSBName,
		string CurId = "General",
		string IncomeSummaryAccount = null,
		byte? DeleteCurrentJournalEntries = null,
		byte? UnitCodeDetail = null,
		DateTime? FiscalYearBegDate = null,
		DateTime? FiscalYearEndDate = null,
		string Infobar = null);
	}
	
	public class MultiFSBYearEndClosingInputCheck : IMultiFSBYearEndClosingInputCheck
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBYearEndClosingInputCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MultiFSBYearEndClosingInputCheckSp(string FSBName,
		string CurId = "General",
		string IncomeSummaryAccount = null,
		byte? DeleteCurrentJournalEntries = null,
		byte? UnitCodeDetail = null,
		DateTime? FiscalYearBegDate = null,
		DateTime? FiscalYearEndDate = null,
		string Infobar = null)
		{
			FSBNameType _FSBName = FSBName;
			JournalIdType _CurId = CurId;
			AcctType _IncomeSummaryAccount = IncomeSummaryAccount;
			Flag _DeleteCurrentJournalEntries = DeleteCurrentJournalEntries;
			Flag _UnitCodeDetail = UnitCodeDetail;
			DateType _FiscalYearBegDate = FiscalYearBegDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBYearEndClosingInputCheckSp";
				
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurId", _CurId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncomeSummaryAccount", _IncomeSummaryAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteCurrentJournalEntries", _DeleteCurrentJournalEntries, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCodeDetail", _UnitCodeDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYearBegDate", _FiscalYearBegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYearEndDate", _FiscalYearEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
