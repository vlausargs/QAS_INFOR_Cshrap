//PROJECT NAME: Finance
//CLASS NAME: CHSGetPeriodStartAndEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSGetPeriodStartAndEndDate : ICHSGetPeriodStartAndEndDate
	{
		readonly IApplicationDB appDB;
		
		
		public CHSGetPeriodStartAndEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? FiscalYearStartDate,
		DateTime? FiscalYearEndDate,
		string Infobar) CHSGetPeriodStartAndEndDateSp(int? FiscalYear,
		int? FiscalPeriod,
		DateTime? FiscalYearStartDate = null,
		DateTime? FiscalYearEndDate = null,
		string Infobar = null)
		{
			FiscalYearType _FiscalYear = FiscalYear;
			FinPeriodType _FiscalPeriod = FiscalPeriod;
			DateType _FiscalYearStartDate = FiscalYearStartDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSGetPeriodStartAndEndDateSp";
				
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalPeriod", _FiscalPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYearStartDate", _FiscalYearStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearEndDate", _FiscalYearEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FiscalYearStartDate = _FiscalYearStartDate;
				FiscalYearEndDate = _FiscalYearEndDate;
				Infobar = _Infobar;
				
				return (Severity, FiscalYearStartDate, FiscalYearEndDate, Infobar);
			}
		}
	}
}
