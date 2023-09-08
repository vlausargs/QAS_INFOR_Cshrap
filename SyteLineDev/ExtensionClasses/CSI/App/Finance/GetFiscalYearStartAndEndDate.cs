//PROJECT NAME: Finance
//CLASS NAME: GetFiscalYearStartAndEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetFiscalYearStartAndEndDate : IGetFiscalYearStartAndEndDate
	{
		readonly IApplicationDB appDB;
		
		
		public GetFiscalYearStartAndEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? FiscalYearStartDate,
		DateTime? FiscalYearEndDate,
		int? FiscalYear,
		string Infobar) GetFiscalYearStartAndEndDateSp(DateTime? FiscalYearStartDate,
		DateTime? FiscalYearEndDate,
		int? FiscalYear,
		string Infobar)
		{
			DateType _FiscalYearStartDate = FiscalYearStartDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			FiscalYearType _FiscalYear = FiscalYear;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFiscalYearStartAndEndDateSp";
				
				appDB.AddCommandParameter(cmd, "FiscalYearStartDate", _FiscalYearStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearEndDate", _FiscalYearEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FiscalYearStartDate = _FiscalYearStartDate;
				FiscalYearEndDate = _FiscalYearEndDate;
				FiscalYear = _FiscalYear;
				Infobar = _Infobar;
				
				return (Severity, FiscalYearStartDate, FiscalYearEndDate, FiscalYear, Infobar);
			}
		}
	}
}
