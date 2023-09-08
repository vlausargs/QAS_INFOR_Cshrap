//PROJECT NAME: Data
//CLASS NAME: GetRangeStartAndEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetRangeStartAndEndDate : IGetRangeStartAndEndDate
	{
		readonly IApplicationDB appDB;
		
		public GetRangeStartAndEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? StartingFiscalYear,
			int? EndingFiscalYear,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			string Infobar) GetRangeStartAndEndDateSp(
			int? StartingFiscalYear,
			int? EndingFiscalYear,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			string Infobar)
		{
			FiscalYearType _StartingFiscalYear = StartingFiscalYear;
			FiscalYearType _EndingFiscalYear = EndingFiscalYear;
			DateType _FiscalYearStartDate = FiscalYearStartDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetRangeStartAndEndDateSp";
				
				appDB.AddCommandParameter(cmd, "StartingFiscalYear", _StartingFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndingFiscalYear", _EndingFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearStartDate", _FiscalYearStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearEndDate", _FiscalYearEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartingFiscalYear = _StartingFiscalYear;
				EndingFiscalYear = _EndingFiscalYear;
				FiscalYearStartDate = _FiscalYearStartDate;
				FiscalYearEndDate = _FiscalYearEndDate;
				Infobar = _Infobar;
				
				return (Severity, StartingFiscalYear, EndingFiscalYear, FiscalYearStartDate, FiscalYearEndDate, Infobar);
			}
		}
	}
}
