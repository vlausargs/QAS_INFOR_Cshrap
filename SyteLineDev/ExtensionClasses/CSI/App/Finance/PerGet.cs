//PROJECT NAME: Finance
//CLASS NAME: PerGet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class PerGet : IPerGet
	{
		readonly IApplicationDB appDB;
		
		
		public PerGet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CurrentPeriod,
		Guid? PeriodsRowPointer,
		string Infobar,
		int? PeriodsFiscalYear,
		string CurPeriodStatus) PerGetSp(DateTime? Date,
		int? CurrentPeriod = null,
		Guid? PeriodsRowPointer = null,
		string Infobar = null,
		string Site = null,
		int? PeriodsFiscalYear = null,
		string CurPeriodStatus = null)
		{
			DateType _Date = Date;
			FinPeriodType _CurrentPeriod = CurrentPeriod;
			RowPointerType _PeriodsRowPointer = PeriodsRowPointer;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			FiscalYearType _PeriodsFiscalYear = PeriodsFiscalYear;
			PeriodStatusType _CurPeriodStatus = CurPeriodStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PerGetSp";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentPeriod", _CurrentPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PeriodsRowPointer", _PeriodsRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodsFiscalYear", _PeriodsFiscalYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurPeriodStatus", _CurPeriodStatus, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrentPeriod = _CurrentPeriod;
				PeriodsRowPointer = _PeriodsRowPointer;
				Infobar = _Infobar;
				PeriodsFiscalYear = _PeriodsFiscalYear;
				CurPeriodStatus = _CurPeriodStatus;
				
				return (Severity, CurrentPeriod, PeriodsRowPointer, Infobar, PeriodsFiscalYear, CurPeriodStatus);
			}
		}
	}
}
