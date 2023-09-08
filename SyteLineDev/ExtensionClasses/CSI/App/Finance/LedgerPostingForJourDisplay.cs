//PROJECT NAME: CSIFinance
//CLASS NAME: LedgerPostingForJourDisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface ILedgerPostingForJourDisplay
	{
		int LedgerPostingForJourDisplaySp(ref DateTime? RStartDate,
		                                  ref DateTime? REndDate,
		                                  ref string Infobar,
		                                  ref short? StartingFiscalYear,
		                                  ref short? EndingFiscalYear,
		                                  ref DateTime? FiscalYearStartDate,
		                                  ref DateTime? FiscalYearEndDate,
		                                  ref byte? AvailChinFin);
	}
	
	public class LedgerPostingForJourDisplay : ILedgerPostingForJourDisplay
	{
		readonly IApplicationDB appDB;
		
		public LedgerPostingForJourDisplay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LedgerPostingForJourDisplaySp(ref DateTime? RStartDate,
		                                         ref DateTime? REndDate,
		                                         ref string Infobar,
		                                         ref short? StartingFiscalYear,
		                                         ref short? EndingFiscalYear,
		                                         ref DateTime? FiscalYearStartDate,
		                                         ref DateTime? FiscalYearEndDate,
		                                         ref byte? AvailChinFin)
		{
			DateType _RStartDate = RStartDate;
			DateType _REndDate = REndDate;
			InfobarType _Infobar = Infobar;
			FiscalYearType _StartingFiscalYear = StartingFiscalYear;
			FiscalYearType _EndingFiscalYear = EndingFiscalYear;
			DateType _FiscalYearStartDate = FiscalYearStartDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			FlagNyType _AvailChinFin = AvailChinFin;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LedgerPostingForJourDisplaySp";
				
				appDB.AddCommandParameter(cmd, "RStartDate", _RStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "REndDate", _REndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingFiscalYear", _StartingFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndingFiscalYear", _EndingFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearStartDate", _FiscalYearStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearEndDate", _FiscalYearEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AvailChinFin", _AvailChinFin, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RStartDate = _RStartDate;
				REndDate = _REndDate;
				Infobar = _Infobar;
				StartingFiscalYear = _StartingFiscalYear;
				EndingFiscalYear = _EndingFiscalYear;
				FiscalYearStartDate = _FiscalYearStartDate;
				FiscalYearEndDate = _FiscalYearEndDate;
				AvailChinFin = _AvailChinFin;
				
				return Severity;
			}
		}
	}
}
