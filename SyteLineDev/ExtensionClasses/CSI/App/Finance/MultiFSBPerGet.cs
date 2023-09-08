//PROJECT NAME: Finance
//CLASS NAME: MultiFSBPerGet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBPerGet
	{
		(int? ReturnCode, int? CurrentPeriod,
		Guid? PeriodsRowPointer,
		string Infobar,
		short? PeriodsFiscalYear,
		DateTime? PeriodStartDate,
		DateTime? PeriodEndDate) MultiFSBPerGetSp(string PeriodName,
		DateTime? Date,
		int? CurrentPeriod = null,
		Guid? PeriodsRowPointer = null,
		string Infobar = null,
		string Site = null,
		short? PeriodsFiscalYear = null,
		DateTime? PeriodStartDate = null,
		DateTime? PeriodEndDate = null);
	}
	
	public class MultiFSBPerGet : IMultiFSBPerGet
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBPerGet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CurrentPeriod,
		Guid? PeriodsRowPointer,
		string Infobar,
		short? PeriodsFiscalYear,
		DateTime? PeriodStartDate,
		DateTime? PeriodEndDate) MultiFSBPerGetSp(string PeriodName,
		DateTime? Date,
		int? CurrentPeriod = null,
		Guid? PeriodsRowPointer = null,
		string Infobar = null,
		string Site = null,
		short? PeriodsFiscalYear = null,
		DateTime? PeriodStartDate = null,
		DateTime? PeriodEndDate = null)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			DateType _Date = Date;
			FSBFinPeriodType _CurrentPeriod = CurrentPeriod;
			RowPointerType _PeriodsRowPointer = PeriodsRowPointer;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			FiscalYearType _PeriodsFiscalYear = PeriodsFiscalYear;
			DateType _PeriodStartDate = PeriodStartDate;
			DateType _PeriodEndDate = PeriodEndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBPerGetSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentPeriod", _CurrentPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodsRowPointer", _PeriodsRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodsFiscalYear", _PeriodsFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodStartDate", _PeriodStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodEndDate", _PeriodEndDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrentPeriod = _CurrentPeriod;
				PeriodsRowPointer = _PeriodsRowPointer;
				Infobar = _Infobar;
				PeriodsFiscalYear = _PeriodsFiscalYear;
				PeriodStartDate = _PeriodStartDate;
				PeriodEndDate = _PeriodEndDate;
				
				return (Severity, CurrentPeriod, PeriodsRowPointer, Infobar, PeriodsFiscalYear, PeriodStartDate, PeriodEndDate);
			}
		}
	}
}
