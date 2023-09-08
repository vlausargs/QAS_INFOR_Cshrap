//PROJECT NAME: CSIFinance
//CLASS NAME: GLYearEndClosing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IGLYearEndClosing
	{
		(int? ReturnCode, string Infobar) GLYearEndClosingSp(string CurId,
		string IncomeSummaryAccount,
		string IncomeSummaryAccountUnit1 = null,
		string IncomeSummaryAccountUnit2 = null,
		string IncomeSummaryAccountUnit3 = null,
		string IncomeSummaryAccountUnit4 = null,
		byte? DeleteCurrentJournalEntries = null,
		byte? UnitCodeDetail = null,
		DateTime? FiscalYearBegDate = null,
		DateTime? FiscalYearEndDate = null,
		string Infobar = null);
	}
	
	public class GLYearEndClosing : IGLYearEndClosing
	{
		readonly IApplicationDB appDB;
		
		public GLYearEndClosing(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GLYearEndClosingSp(string CurId,
		string IncomeSummaryAccount,
		string IncomeSummaryAccountUnit1 = null,
		string IncomeSummaryAccountUnit2 = null,
		string IncomeSummaryAccountUnit3 = null,
		string IncomeSummaryAccountUnit4 = null,
		byte? DeleteCurrentJournalEntries = null,
		byte? UnitCodeDetail = null,
		DateTime? FiscalYearBegDate = null,
		DateTime? FiscalYearEndDate = null,
		string Infobar = null)
		{
			JournalIdType _CurId = CurId;
			AcctType _IncomeSummaryAccount = IncomeSummaryAccount;
			UnitCode1Type _IncomeSummaryAccountUnit1 = IncomeSummaryAccountUnit1;
			UnitCode2Type _IncomeSummaryAccountUnit2 = IncomeSummaryAccountUnit2;
			UnitCode3Type _IncomeSummaryAccountUnit3 = IncomeSummaryAccountUnit3;
			UnitCode4Type _IncomeSummaryAccountUnit4 = IncomeSummaryAccountUnit4;
			Flag _DeleteCurrentJournalEntries = DeleteCurrentJournalEntries;
			Flag _UnitCodeDetail = UnitCodeDetail;
			DateType _FiscalYearBegDate = FiscalYearBegDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GLYearEndClosingSp";
				
				appDB.AddCommandParameter(cmd, "CurId", _CurId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncomeSummaryAccount", _IncomeSummaryAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncomeSummaryAccountUnit1", _IncomeSummaryAccountUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncomeSummaryAccountUnit2", _IncomeSummaryAccountUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncomeSummaryAccountUnit3", _IncomeSummaryAccountUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncomeSummaryAccountUnit4", _IncomeSummaryAccountUnit4, ParameterDirection.Input);
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
