//PROJECT NAME: Finance
//CLASS NAME: MultiFSBGetRangeStartAndEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBGetRangeStartAndEndDate : IMultiFSBGetRangeStartAndEndDate
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBGetRangeStartAndEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string FSBName,
			int? StartingFiscalYear,
			int? EndingFiscalYear,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			string Infobar) MultiFSBGetRangeStartAndEndDateSp(
			string FSBName,
			int? StartingFiscalYear,
			int? EndingFiscalYear,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			string Infobar)
		{
			FSBNameType _FSBName = FSBName;
			FiscalYearType _StartingFiscalYear = StartingFiscalYear;
			FiscalYearType _EndingFiscalYear = EndingFiscalYear;
			DateType _FiscalYearStartDate = FiscalYearStartDate;
			DateType _FiscalYearEndDate = FiscalYearEndDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBGetRangeStartAndEndDateSp";
				
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingFiscalYear", _StartingFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndingFiscalYear", _EndingFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearStartDate", _FiscalYearStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearEndDate", _FiscalYearEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FSBName = _FSBName;
				StartingFiscalYear = _StartingFiscalYear;
				EndingFiscalYear = _EndingFiscalYear;
				FiscalYearStartDate = _FiscalYearStartDate;
				FiscalYearEndDate = _FiscalYearEndDate;
				Infobar = _Infobar;
				
				return (Severity, FSBName, StartingFiscalYear, EndingFiscalYear, FiscalYearStartDate, FiscalYearEndDate, Infobar);
			}
		}
	}
}
