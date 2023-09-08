//PROJECT NAME: Finance
//CLASS NAME: CHSGetPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSGetPeriod : ICHSGetPeriod
	{
		readonly IApplicationDB appDB;
		
		public CHSGetPeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? FiscalYear,
			int? Period,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			int? CurPer,
			int? Closed,
			string Infobar) CHSGetPeriodSp(
			DateTime? RefDate = null,
			int? FiscalYear = 0,
			int? Period = 0,
			DateTime? FiscalYearStartDate = null,
			DateTime? FiscalYearEndDate = null,
			int? CurPer = 0,
			int? Closed = 0,
			string Infobar = "")
		{
			DateType _RefDate = RefDate;
			FiscalYearType _FiscalYear = FiscalYear;
			FinPeriodType _Period = Period;
			DateType _FiscalYearStartDate = FiscalYearStartDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			FinPeriodType _CurPer = CurPer;
			ListYesNoType _Closed = Closed;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSGetPeriodSp";
				
				appDB.AddCommandParameter(cmd, "RefDate", _RefDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearStartDate", _FiscalYearStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearEndDate", _FiscalYearEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurPer", _CurPer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Closed", _Closed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FiscalYear = _FiscalYear;
				Period = _Period;
				FiscalYearStartDate = _FiscalYearStartDate;
				FiscalYearEndDate = _FiscalYearEndDate;
				CurPer = _CurPer;
				Closed = _Closed;
				Infobar = _Infobar;
				
				return (Severity, FiscalYear, Period, FiscalYearStartDate, FiscalYearEndDate, CurPer, Closed, Infobar);
			}
		}
	}
}
