//PROJECT NAME: Finance
//CLASS NAME: PeriodsYTDAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class PeriodsYTDAll : IPeriodsYTDAll
	{
		readonly IApplicationDB appDB;
		
		public PeriodsYTDAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? YearStart,
			DateTime? YearEnd,
			DateTime? PeriodStart,
			DateTime? PeriodEnd,
			DateTime? LastYearStart,
			DateTime? LastYearEnd,
			DateTime? FiscalYearStart,
			DateTime? FiscalYearEnd,
			DateTime? FiscalPeriodStart,
			DateTime? FiscalPeriodEnd,
			DateTime? FiscalLastYearStart,
			DateTime? FiscalLastYearEnd) PeriodsYTDAllSp(
			DateTime? YearStart,
			DateTime? YearEnd,
			DateTime? PeriodStart,
			DateTime? PeriodEnd,
			DateTime? LastYearStart,
			DateTime? LastYearEnd,
			DateTime? FiscalYearStart,
			DateTime? FiscalYearEnd,
			DateTime? FiscalPeriodStart,
			DateTime? FiscalPeriodEnd,
			DateTime? FiscalLastYearStart,
			DateTime? FiscalLastYearEnd,
			string Site = null)
		{
			DateType _YearStart = YearStart;
			DateType _YearEnd = YearEnd;
			DateType _PeriodStart = PeriodStart;
			DateType _PeriodEnd = PeriodEnd;
			DateType _LastYearStart = LastYearStart;
			DateType _LastYearEnd = LastYearEnd;
			DateType _FiscalYearStart = FiscalYearStart;
			DateType _FiscalYearEnd = FiscalYearEnd;
			DateType _FiscalPeriodStart = FiscalPeriodStart;
			DateType _FiscalPeriodEnd = FiscalPeriodEnd;
			DateType _FiscalLastYearStart = FiscalLastYearStart;
			DateType _FiscalLastYearEnd = FiscalLastYearEnd;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PeriodsYTDAllSp";
				
				appDB.AddCommandParameter(cmd, "YearStart", _YearStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "YearEnd", _YearEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStart", _PeriodStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEnd", _PeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastYearStart", _LastYearStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastYearEnd", _LastYearEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearStart", _FiscalYearStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalYearEnd", _FiscalYearEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalPeriodStart", _FiscalPeriodStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalPeriodEnd", _FiscalPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalLastYearStart", _FiscalLastYearStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FiscalLastYearEnd", _FiscalLastYearEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				YearStart = _YearStart;
				YearEnd = _YearEnd;
				PeriodStart = _PeriodStart;
				PeriodEnd = _PeriodEnd;
				LastYearStart = _LastYearStart;
				LastYearEnd = _LastYearEnd;
				FiscalYearStart = _FiscalYearStart;
				FiscalYearEnd = _FiscalYearEnd;
				FiscalPeriodStart = _FiscalPeriodStart;
				FiscalPeriodEnd = _FiscalPeriodEnd;
				FiscalLastYearStart = _FiscalLastYearStart;
				FiscalLastYearEnd = _FiscalLastYearEnd;
				
				return (Severity, YearStart, YearEnd, PeriodStart, PeriodEnd, LastYearStart, LastYearEnd, FiscalYearStart, FiscalYearEnd, FiscalPeriodStart, FiscalPeriodEnd, FiscalLastYearStart, FiscalLastYearEnd);
			}
		}
	}
}
