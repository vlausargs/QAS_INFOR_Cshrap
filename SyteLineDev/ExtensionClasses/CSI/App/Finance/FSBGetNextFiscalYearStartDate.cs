//PROJECT NAME: Finance
//CLASS NAME: FSBGetNextFiscalYearStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FSBGetNextFiscalYearStartDate : IFSBGetNextFiscalYearStartDate
	{
		readonly IApplicationDB appDB;
		
		
		public FSBGetNextFiscalYearStartDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NextFiscalYear,
		DateTime? NextStartDate) FSBGetNextFiscalYearStartDateSp(string PeriodName,
		int? NextFiscalYear,
		DateTime? NextStartDate)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			FiscalYearType _NextFiscalYear = NextFiscalYear;
			DateType _NextStartDate = NextStartDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FSBGetNextFiscalYearStartDateSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextFiscalYear", _NextFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NextStartDate", _NextStartDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextFiscalYear = _NextFiscalYear;
				NextStartDate = _NextStartDate;
				
				return (Severity, NextFiscalYear, NextStartDate);
			}
		}
	}
}
